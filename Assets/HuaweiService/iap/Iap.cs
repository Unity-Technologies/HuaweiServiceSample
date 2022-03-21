using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.IAP
{
    public class Iap_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.iap.Iap";
    }
    public class Iap :HmsClass<Iap_Data>
    {  
        public Iap (): base() { }
        public static IapClient getIapClient(Activity arg0, string arg1) {
            return CallStatic<IapClient>("getIapClient", arg0, arg1);
        }
        public static IapClient getIapClient(Context arg0, string arg1) {
            return CallStatic<IapClient>("getIapClient", arg0, arg1);
        }
        public static IapClient getIapClient(Activity arg0) {
            return CallStatic<IapClient>("getIapClient", arg0);
        }
        public static IapClient getIapClient(Context arg0) {
            return CallStatic<IapClient>("getIapClient", arg0);
        }
    }
}