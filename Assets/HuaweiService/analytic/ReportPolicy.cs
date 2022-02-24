using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.analytic
{
    public class ReportPolicy_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.analytics.type.ReportPolicy";
    }
    public class ReportPolicy :HmsClass<ReportPolicy_Data>
    {
        public static ReportPolicy ON_SCHEDULED_TIME_POLICY => HmsUtil.GetStaticValue<ReportPolicy>("ON_SCHEDULED_TIME_POLICY");
    
        public static ReportPolicy ON_APP_LAUNCH_POLICY => HmsUtil.GetStaticValue<ReportPolicy>("ON_APP_LAUNCH_POLICY");
    
        public static ReportPolicy ON_MOVE_BACKGROUND_POLICY => HmsUtil.GetStaticValue<ReportPolicy>("ON_MOVE_BACKGROUND_POLICY");
    
        public static ReportPolicy ON_CACHE_THRESHOLD_POLICY => HmsUtil.GetStaticValue<ReportPolicy>("ON_CACHE_THRESHOLD_POLICY");
    
        public ReportPolicy (): base() { }

        public void setThreshold(long arg0) {
            Call("setThreshold", arg0);
        }
        
        public long getThreshold() {
            return Call<long>("getThreshold");
        }
    }
}