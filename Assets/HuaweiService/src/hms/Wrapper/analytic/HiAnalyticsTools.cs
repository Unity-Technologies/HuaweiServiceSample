using UnityEngine;
using System.Collections.Generic;

namespace HuaweiHms
{
    public class HiAnalyticsTools_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.analytics.HiAnalyticsTools";
    }
    public class HiAnalyticsTools :HmsClass<HiAnalyticsTools_Data>
    {
        public HiAnalyticsTools (): base() { }
        public static void enableLog() {
            CallStatic("enableLog");
        }
        public static void enableLog(int arg0) {
            CallStatic("enableLog", arg0);
        }
    }
}