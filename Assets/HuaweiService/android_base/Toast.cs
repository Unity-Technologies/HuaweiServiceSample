using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class Toast_Data : IHmsBaseClass{
        public string name => "android.widget.Toast";
    }
    public class Toast :HmsClass<Toast_Data>
    {
        public const int LENGTH_LONG = 1;
        public const int LENGTH_SHORT = 0;
        public Toast (Context arg0): base(arg0) { }
        public Toast (): base() { }
        public static Toast makeText(Context arg0, string arg1, int arg2) {
            return CallStatic<Toast>("makeText", arg0, arg1, arg2);
        }
        public static Toast makeText(Context arg0, int arg1, int arg2) {
            return CallStatic<Toast>("makeText", arg0, arg1, arg2);
        }
        public void show() {
            Call("show");
        }
    }
}