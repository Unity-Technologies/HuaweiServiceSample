using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class Uri_Data : IHmsBaseClass{
        public string name => "android.net.Uri";
    }
    public class Uri :HmsClass<Uri_Data>
    {
        public Uri (): base() { }
        public string toString() {
            return Call<string>("toString");
        }
        public static Uri parse(string arg0) {
            return CallStatic<Uri>("parse", arg0);
        }
    }
}