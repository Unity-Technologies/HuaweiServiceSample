using UnityEngine;
using System.Collections.Generic;
using HuaweiService.Auth;

namespace HuaweiService.location
{
    public class ActivityConversionData_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.location.ActivityConversionData";
    }
    public class ActivityConversionData :HmsClass<ActivityConversionData_Data>
    {
        public static Parcelable.Creator CREATOR => HmsUtil.GetStaticValue<Parcelable.Creator>("CREATOR");
        public ActivityConversionData (int arg0, int arg1, long arg2): base(arg0, arg1, arg2) { }
        public ActivityConversionData (): base() { }
        public int getActivityType() {
            return Call<int>("getActivityType");
        }
        public long getElapsedTimeFromReboot() {
            return Call<long>("getElapsedTimeFromReboot");
        }
        public int getConversionType() {
            return Call<int>("getConversionType");
        }
    }
}