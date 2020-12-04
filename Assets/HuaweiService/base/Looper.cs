using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class Looper_Data : IHmsBaseClass{
        public string name => "android.os.Looper";
    }
    public class Looper :HmsClass<Looper_Data>
    {
        public Looper (): base() { }
        public static Looper getMainLooper() {
            return CallStatic<Looper>("getMainLooper");
        }
    }
}