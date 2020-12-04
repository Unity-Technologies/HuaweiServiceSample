using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class AndroidUtil_Data : IHmsBaseClass{
        public string name => "com.unity.AndroidUtil.AndroidUtil";
    }
    public class AndroidUtil :HmsClass<AndroidUtil_Data>
    {
        public AndroidUtil (): base() { }
        public static int GetAndroidVersion() {
            return CallStatic<int>("GetAndroidVersion");
        }
        public static int GetAndroidVersionCodeP() {
            return CallStatic<int>("GetAndroidVersionCodeP");
        }
        public static int GetPMPermissionGranted() {
            return CallStatic<int>("GetPMPermissionGranted");
        }
        public static int GetId(Context arg0, string arg1, string arg2) {
            return CallStatic<int>("GetId", arg0, arg1, arg2);
        }
    }
}