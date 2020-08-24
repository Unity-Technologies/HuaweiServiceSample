using UnityEngine;

namespace HuaweiHms{
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
    }
}