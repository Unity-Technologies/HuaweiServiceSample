using UnityEngine;
using System.Reflection;
using System;
using System.Linq;

using Mono.Cecil;
using Mono.Cecil.Cil;
using HuaweiService.apm;

namespace HuaweiService
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AddCustomTrace : Attribute
    {
        string m_name;
        bool m_enable;

        public AddCustomTrace(string name, bool enable = true){
            m_name = name;
            m_enable = enable;
        }

        public string name{
            get{
                return m_name;
            }
        }
        public bool enable{
            get{
                return m_enable;
            }
            set{
                m_enable = value;
            }
        }
    }

    public class TraceInjector
    {
        public static void Inject(string assemblyPath)
        {
            //Debug.Log("inject custom trace Start");
            // 按路径读取程序集, 如果文件不存在则返回错误信息
            if(!System.IO.File.Exists(assemblyPath)){
                Debug.LogError(string.Format("{0} is not Exists",
                    assemblyPath));
            }

            var readerParameters = new ReaderParameters { ReadSymbols = true };
            var assembly = AssemblyDefinition.ReadAssembly(assemblyPath, readerParameters);
            if (assembly == null)
            {
                Debug.LogError(string.Format("InjectTool Inject Load assembly failed: {0}",
                    assemblyPath));
                return;
            }

            try
            {
                var module = assembly.MainModule;
                foreach (var type in module.Types)
                {
                    foreach (var method in type.Methods)
                    {
                        // 找到method中需要注入的类型
                        var needInjectAttr = typeof(AddCustomTrace).FullName;
                        bool needInject = method.CustomAttributes.Any(typeAttribute => typeAttribute.AttributeType.FullName == needInjectAttr);
                        if (!needInject)
                        {
                            continue;
                        }

                        // 只对公有方法进行注入
                        if (method.IsConstructor || method.IsGetter || method.IsSetter || !method.IsPublic)
                            continue;
                        Inject(module, method, type);
                    }
                }
                assembly.Write(assemblyPath, new WriterParameters { WriteSymbols = true });
            }
            catch (System.Exception ex)
            {
                Debug.LogError(string.Format("InjectTool Inject failed: {0}", ex));
                throw;
            }
            finally
            {
                if (assembly.MainModule.SymbolReader != null)
                {
                    assembly.MainModule.SymbolReader.Dispose();
                }
            }
        }

        private static void Inject(ModuleDefinition module, MethodDefinition method, TypeDefinition type)
        {
            if(module == null){
                throw new ArgumentNullException("input argument invalid, module is null");
            }
            if(method == null){
                throw new ArgumentNullException("input argument invalid, method is null");
            }
            if(type == null){
                throw new ArgumentNullException("input argument invalid, type is null");
            }

            //获取方法AddCustomTrace
            AddCustomTrace attr = getTraceAttribute(type, method);
            //判断功能是否开启
            if(attr.enable != true){
                //Debug.Log(method.Name + " close add custom trace attribute.");
                return;
            }
            //获取特性名称
            String name = attr.name;

            //更改待注入函数局部变量表
            method.Body.InitLocals = true;
            var customTraceType = module.ImportReference(typeof(CustomTrace));
            var customTraceTypeDef = new VariableDefinition(customTraceType);
            method.Body.Variables.Add(customTraceTypeDef);
            //准备注入的函数
            MethodReference getInstance = module.ImportReference(typeof(APMS).GetMethod("getInstance"));
            MethodReference createInstance = module.ImportReference(typeof(APMS).GetMethod("createCustomTrace", new Type[] {typeof(string)}));
            MethodReference customTraceStart = module.ImportReference(typeof(CustomTrace).GetMethod("start"));
            MethodReference customTraceEnd = module.ImportReference(typeof(CustomTrace).GetMethod("stop"));
            //设置一些标签用于语句跳转
            Instruction first = method.Body.Instructions[0];

            // 开始注入IL代码
            var ilProcessor = method.Body.GetILProcessor();
            ilProcessor.InsertBefore(first, ilProcessor.Create(OpCodes.Nop));
            ilProcessor.InsertBefore(first, Instruction.Create(OpCodes.Call, getInstance));

            ilProcessor.InsertBefore(first, Instruction.Create(OpCodes.Ldstr, name));
            ilProcessor.InsertBefore(first, Instruction.Create(OpCodes.Callvirt, createInstance));
            ilProcessor.InsertBefore(first, Instruction.Create(OpCodes.Stloc, customTraceTypeDef));

            ilProcessor.InsertBefore(first, Instruction.Create(OpCodes.Ldloc, customTraceTypeDef));
            ilProcessor.InsertBefore(first, Instruction.Create(OpCodes.Callvirt, customTraceStart));
            ilProcessor.InsertBefore(first, ilProcessor.Create(OpCodes.Nop));

            //在每一个返回的地方插入stop函数，注意插入指令之后，method.Body.Instructions.Count会增加，需要调整i值
            for(int i=0;i<method.Body.Instructions.Count;i++){
                Instruction ins = method.Body.Instructions[i];
                OpCode code = ins.OpCode;
                if(ins.OpCode.Equals(OpCodes.Ret) || ins.OpCode.Equals(OpCodes.Throw)){
                    //Debug.Log("method: " + method.Name  + "i: " + i + " code: " + code);
                    ilProcessor.InsertBefore(ins, ilProcessor.Create(OpCodes.Nop));
                    ilProcessor.InsertBefore(ins, Instruction.Create(OpCodes.Ldloc, customTraceTypeDef));
                    ilProcessor.InsertBefore(ins, Instruction.Create(OpCodes.Callvirt, customTraceEnd));
                    ilProcessor.InsertBefore(ins, ilProcessor.Create(OpCodes.Nop));
                    i+=4;
                }
            }
        }

        //获取函数的特性
        private static AddCustomTrace getTraceAttribute(TypeDefinition type, MethodDefinition method){
            Type inejectClassType = Type.GetType(type.FullName);
            if(inejectClassType == null){
              throw new NullReferenceException("Class Type is null, Attribute: " + type.FullName);
            }

            MethodInfo methodinfo = inejectClassType.GetMethod(method.Name);
            if(methodinfo == null){
                throw new NullReferenceException("methodinfo in class " + type.FullName + " is null, method name: " + method.Name);
            }

            AddCustomTrace attr = (AddCustomTrace)methodinfo.GetCustomAttributes(typeof(AddCustomTrace), true)[0] ;
            if(attr == null){
                throw new NullReferenceException("attr AddCustomTrace on method "+ method.Name + " is null");
            }

            return attr;
        }
    }
}
