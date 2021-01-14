using System;
using System.Collections.Generic;
using UnityEngine;

namespace HuaweiService{
    public class HmsUtil{
        public static object TransferParam(object arg)
        {
            if (arg is IHmsBase)
            {
                IHmsBase a = arg as IHmsBase;
                return a.param;
            }
            return arg;
        }
        public static object[] TransferParams(params object[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                args[i] = TransferParam(args[i]);
            }
            return args;
        }
        public static T GetHmsBase<T>(AndroidJavaObject obj) where T:IHmsBase,new(){
            T a = new T();
            a.obj = obj;
            return a;
        }

        private static Dictionary<Type, Dictionary<string, IHmsBase>> _enums = new Dictionary<Type, Dictionary<string, IHmsBase>>();
        
        internal static T GetStaticValue<T>(string value, string className="") where T : IHmsBase, new()
        {
            var type = typeof(T);
            if (!_enums.ContainsKey(type))
            {
                _enums.Add(type, new Dictionary<string, IHmsBase>());
            }

            if (!_enums[type].ContainsKey(value))
            {
                var result = new T();
                if(className.Length > 0) {
                    var cls = new AndroidJavaClass(className);
                    result.obj = cls.GetStatic<AndroidJavaObject>(value);
                } else {
                    result.obj = result.obj.GetStatic<AndroidJavaObject>(value);
                }
                _enums[type].Add(value, result);
            } 
            
            return (T)_enums[type][value];
        }
    }
}