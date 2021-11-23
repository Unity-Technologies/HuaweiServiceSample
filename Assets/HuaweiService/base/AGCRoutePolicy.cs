using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class AGCRoutePolicy_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.AGCRoutePolicy";
    }
    public class AGCRoutePolicy :HmsClass<AGCRoutePolicy_Data>
    {
        public static AGCRoutePolicy UNKNOWN => HmsUtil.GetStaticValue<AGCRoutePolicy>("UNKNOWN");
    
        public static AGCRoutePolicy CHINA => HmsUtil.GetStaticValue<AGCRoutePolicy>("CHINA");
    
        public static AGCRoutePolicy GERMANY => HmsUtil.GetStaticValue<AGCRoutePolicy>("GERMANY");
    
        public static AGCRoutePolicy RUSSIA => HmsUtil.GetStaticValue<AGCRoutePolicy>("RUSSIA");
    
        public static AGCRoutePolicy SINGAPORE => HmsUtil.GetStaticValue<AGCRoutePolicy>("SINGAPORE");
    
        public AGCRoutePolicy (): base() { }
        public string getRouteName() {
            return Call<string>("getRouteName");
        }
    }
}