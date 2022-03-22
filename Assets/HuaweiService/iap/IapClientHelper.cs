using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.IAP
{
    public class IapClientHelper_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.iap.util.IapClientHelper";
    }
    public class IapClientHelper :HmsClass<IapClientHelper_Data>
    {
        public IapClientHelper (): base() { }
        public static int parseAccountFlagFromIntent(Intent arg0) {
            return CallStatic<int>("parseAccountFlagFromIntent", arg0);
        }
        public static string parseCarrierIdFromIntent(Intent arg0) {
            return CallStatic<string>("parseCarrierIdFromIntent", arg0);
        }
        public static string parseCountryFromIntent(Intent arg0) {
            return CallStatic<string>("parseCountryFromIntent", arg0);
        }
        public static int parseRespCodeFromIntent(Intent arg0) {
            return CallStatic<int>("parseRespCodeFromIntent", arg0);
        }
        public static string parseRespMessageFromIntent(Intent arg0) {
            return CallStatic<string>("parseRespMessageFromIntent", arg0);
        }
    }
}