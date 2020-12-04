using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.ads
{
    public class HwAds_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.ads.HwAds";
    }
    public class HwAds :HmsClass<HwAds_Data>
    {
        public HwAds (): base() { }
        public static void init(Context arg0) {
            CallStatic("init", arg0);
        }
        public static void init(Context arg0, string arg1) {
            CallStatic("init", arg0, arg1);
        }
        public static string getSDKVersion() {
            return CallStatic<string>("getSDKVersion");
        }
        public static RequestOptions getRequestOptions() {
            return CallStatic<RequestOptions>("getRequestOptions");
        }
        public static void setRequestOptions(RequestOptions arg0) {
            CallStatic("setRequestOptions", arg0);
        }
    }
}