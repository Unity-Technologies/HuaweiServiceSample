using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.location
{
    public class ActivityConversionInfo_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.location.ActivityConversionInfo";
    }
    public class ActivityConversionInfo :HmsClass<ActivityConversionInfo_Data>
    {
        public const int ENTER_ACTIVITY_CONVERSION = 0;
        public const int EXIT_ACTIVITY_CONVERSION = 1;
        public ActivityConversionInfo (int arg0, int arg1): base(arg0, arg1) { }
        public ActivityConversionInfo (): base() { }
        public int getActivityType() {
            return Call<int>("getActivityType");
        }
        public int getConversionType() {
            return Call<int>("getConversionType");
        }
    
        public class Builder_Data : IHmsBaseClass{
            public string name => "com.huawei.hms.location.ActivityConversionInfo$Builder";
        }
        public class Builder :HmsClass<Builder_Data>
        {
            public Builder (): base() { }
            public Builder setConversionType(int arg0) {
                return Call<Builder>("setConversionType", arg0);
            }
            public Builder setActivityType(int arg0) {
                return Call<Builder>("setActivityType", arg0);
            }
            public ActivityConversionInfo build() {
                return Call<ActivityConversionInfo>("build");
            }
        }
    }
}