using UnityEngine;
using System.Collections.Generic;

namespace HuaweiHms
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
    }
}