using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class ActivityCompat_Data : IHmsBaseClass{
        public string name => "androidx.core.app.ActivityCompat";
    }
    public class ActivityCompat :HmsClass<ActivityCompat_Data>
    {
        public ActivityCompat (): base() { }
        public static int checkSelfPermission(Context arg0, string arg1) {
            return CallStatic<int>("checkSelfPermission", arg0, arg1);
        }
        public static void requestPermissions(Activity arg0, string[] arg1, int arg2) {
            CallStatic("requestPermissions", arg0, arg1, arg2);
        }
    }
}