using UnityEngine;
using System.Collections.Generic;
using HuaweiService.Auth;

namespace HuaweiService.location
{
    public class ActivityConversionRequest_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.location.ActivityConversionRequest";
    }
    public class ActivityConversionRequest :HmsClass<ActivityConversionRequest_Data>
    {
        public static Parcelable.Creator CREATOR => HmsUtil.GetStaticValue<Parcelable.Creator>("CREATOR");
        public static Comparator IS_EQUAL_CONVERSION => HmsUtil.GetStaticValue<Comparator>("IS_EQUAL_CONVERSION");
        public ActivityConversionRequest (List arg0): base(arg0) { }
        public ActivityConversionRequest (): base() { }
        public void setDataToIntent(Intent arg0) {
            Call("setDataToIntent", arg0);
        }
    }
}