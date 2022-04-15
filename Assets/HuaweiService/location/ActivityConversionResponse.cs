using UnityEngine;
using System.Collections.Generic;
using HuaweiService.Auth;

namespace HuaweiService.location
{
    public class ActivityConversionResponse_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.location.ActivityConversionResponse";
    }
    public class ActivityConversionResponse :HmsClass<ActivityConversionResponse_Data>
    {
        public static Parcelable.Creator CREATOR => HmsUtil.GetStaticValue<Parcelable.Creator>("CREATOR");
        public ActivityConversionResponse (List arg0): base(arg0) { }
        public ActivityConversionResponse (): base() { }
        public static ActivityConversionResponse getDataFromIntent(Intent arg0) {
            return CallStatic<ActivityConversionResponse>("getDataFromIntent", arg0);
        }
        public List getActivityConversionDatas() {
            return Call<List>("getActivityConversionDatas");
        }
        public static bool containDataFromIntent(Intent arg0) {
            return CallStatic<bool>("containDataFromIntent", arg0);
        }
    }
}