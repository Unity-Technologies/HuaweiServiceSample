using UnityEditor;
using UnityEditor.Compilation;

using UnityEngine;
using System.Reflection;
using System;
using System.Linq;

using Mono.Cecil;
using Mono.Cecil.Cil;

using HuaweiService.apm;

namespace HuaweiService{
    [InitializeOnLoad]
    public class TraceInjectPostProecess{
        static TraceInjectPostProecess(){
            CompilationPipeline.assemblyCompilationFinished     += onFinished;
        }

        private static void onFinished(string arg1, CompilerMessage[] arg2){
            TraceInjector.Inject(arg1);
        }
    }

    public class TraceInjector
    {
        public static void Inject(string assemblyPath)
        {
            //Debug.Log("inject custom trace Start");
            //Read the assembly according to the path, if the file does not exist, return an error message
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
                        //Find the type that needs to be injected in the method
                        var needInjectAttr = typeof(AddCustomTrace).FullName;
                        bool needInject = method.CustomAttributes.Any(typeAttribute => typeAttribute.AttributeType.FullName == needInjectAttr);
                        if (!needInject)
                        {
                            continue;
                        }

                        //Only public methods need to be injected
                        if (method.IsConstructor || method.IsGetter || method.IsSetter || !method.IsPublic)
                            continue;
                        Inject(module, method, type, assembly);
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

        private static void Inject(ModuleDefinition module, MethodDefinition method, TypeDefinition type, AssemblyDefinition assembly)
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

            //get AddCustomTrace attribute in method
            AddCustomTrace attr = getTraceAttribute(type, method, assembly);
            //whether the function is turned on
            if(attr.enable != true){
                return;
            }
            //get name of attribute
            String name = attr.name;

            //Change the local variable table of the function to be injected
            method.Body.InitLocals = true;
            var customTraceType = module.ImportReference(typeof(CustomTrace));
            var customTraceTypeDef = new VariableDefinition(customTraceType);
            method.Body.Variables.Add(customTraceTypeDef);
            
            //Prepare functions to be injected
            MethodReference getInstance = module.ImportReference(typeof(APMS).GetMethod("getInstance"));
            MethodReference createInstance = module.ImportReference(typeof(APMS).GetMethod("createCustomTrace", new Type[] {typeof(string)}));
            MethodReference customTraceStart = module.ImportReference(typeof(CustomTrace).GetMethod("start"));
            MethodReference customTraceEnd = module.ImportReference(typeof(CustomTrace).GetMethod("stop"));
            
            //Set some labels for statement jump
            Instruction first = method.Body.Instructions[0];

            // start injecting IL code
            var ilProcessor = method.Body.GetILProcessor();
            ilProcessor.InsertBefore(first, ilProcessor.Create(OpCodes.Nop));
            ilProcessor.InsertBefore(first, Instruction.Create(OpCodes.Call, getInstance));

            ilProcessor.InsertBefore(first, Instruction.Create(OpCodes.Ldstr, name));
            ilProcessor.InsertBefore(first, Instruction.Create(OpCodes.Callvirt, createInstance));
            ilProcessor.InsertBefore(first, Instruction.Create(OpCodes.Stloc, customTraceTypeDef));

            ilProcessor.InsertBefore(first, Instruction.Create(OpCodes.Ldloc, customTraceTypeDef));
            ilProcessor.InsertBefore(first, Instruction.Create(OpCodes.Callvirt, customTraceStart));
            ilProcessor.InsertBefore(first, ilProcessor.Create(OpCodes.Nop));
            
            //Insert stop functions at every return. Note that after inserting the instruction,
            //method.Body.Instructions.Count increment，and need to adjust the value of i
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

        //get attribute of given method
        private static AddCustomTrace getTraceAttribute(TypeDefinition type, MethodDefinition method, AssemblyDefinition assembly){
            Type inejectClassType = Type.GetType(type.FullName + ", " + assembly.Name);
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
