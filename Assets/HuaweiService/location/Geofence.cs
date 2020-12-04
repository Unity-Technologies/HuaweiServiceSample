using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.location
{
    public class Geofence_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.location.Geofence";
    }
    public class Geofence :HmsClass<Geofence_Data>
    {
        public const int ENTER_GEOFENCE_CONVERSION = 1;
        public const int EXIT_GEOFENCE_CONVERSION = 2;
        public const int DWELL_GEOFENCE_CONVERSION = 4;
        public Geofence (): base() { }
        public string getUniqueId() {
            return Call<string>("getUniqueId");
        }
    
        public class Builder_Data : IHmsBaseClass{
            public string name => "com.huawei.hms.location.Geofence$Builder";
        }
        public class Builder :HmsClass<Builder_Data>
        {
            public Builder (): base() { }
            public Builder setRoundArea(double arg0, double arg1, float arg2) {
                return Call<Builder>("setRoundArea", arg0, arg1, arg2);
            }
            public Builder setUniqueId(string arg0) {
                return Call<Builder>("setUniqueId", arg0);
            }
            public Builder setConversions(int arg0) {
                return Call<Builder>("setConversions", arg0);
            }
            public Builder setValidContinueTime(long arg0) {
                return Call<Builder>("setValidContinueTime", arg0);
            }
            public Builder setDwellDelayTime(int arg0) {
                return Call<Builder>("setDwellDelayTime", arg0);
            }
            public Builder setNotificationInterval(int arg0) {
                return Call<Builder>("setNotificationInterval", arg0);
            }
            public Geofence build() {
                return Call<Geofence>("build");
            }
        }
    }
}