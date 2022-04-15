using UnityEngine;
using System.Collections.Generic;
using HuaweiService.Auth;

namespace HuaweiService.location
{
    public class ActivityIdentificationData_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.location.ActivityIdentificationData";
    }
    public class ActivityIdentificationData :HmsClass<ActivityIdentificationData_Data>
    {
        public static Parcelable.Creator CREATOR => HmsUtil.GetStaticValue<Parcelable.Creator>("CREATOR");
        public const int VEHICLE = 100;
        public const int BIKE = 101;
        public const int FOOT = 102;
        public const int STILL = 103;
        public const int OTHERS = 104;
        public const int WALKING = 107;
        public const int RUNNING = 108;
        public ActivityIdentificationData (int arg0, int arg1): base(arg0, arg1) { }
        public ActivityIdentificationData (): base() { }
        public int getPossibility() {
            return Call<int>("getPossibility");
        }
        public int getIdentificationActivity() {
            return Call<int>("getIdentificationActivity");
        }
    }
}