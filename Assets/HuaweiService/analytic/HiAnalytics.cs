using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.analytic
{
    public class HiAnalytics_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.analytics.HiAnalytics";
    }
    public class HiAnalytics :HmsClass<HiAnalytics_Data>
    {
        public HiAnalytics (): base() { }
        public static HiAnalyticsInstance getInstance(Activity arg0) {
            return CallStatic<HiAnalyticsInstance>("getInstance", arg0);
        }
        public static HiAnalyticsInstance getInstance(Context arg0) {
            return CallStatic<HiAnalyticsInstance>("getInstance", arg0);
        }
    }
}