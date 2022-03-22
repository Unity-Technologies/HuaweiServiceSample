using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.Account
{
    public class ReadSmsManager_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.support.sms.ReadSmsManager";
    }
    public class ReadSmsManager :HmsClass<ReadSmsManager_Data>
    {
        public ReadSmsManager (): base() { }
        public static Task start(Activity arg0) {
            return CallStatic<Task>("start", arg0);
        }
        public static Task start(Context arg0) {
            return CallStatic<Task>("start", arg0);
        }
        
        public static Task startConsent(Activity arg0,string arg1) {
            return CallStatic<Task>("startConsent", arg0,arg1);
        }
    }
}