using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.location
{
    public class ActivityConversionRequest_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.location.ActivityConversionRequest";
    }
    public class ActivityConversionRequest :HmsClass<ActivityConversionRequest_Data>
    {
        public ActivityConversionRequest (List arg0): base(arg0) { }
        public ActivityConversionRequest (): base() { }
        public void setDataToIntent(Intent arg0) {
            Call("setDataToIntent", arg0);
        }
    }
}