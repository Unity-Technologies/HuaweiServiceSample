using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.location
{
    public class LocationAvailability_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.location.LocationAvailability";
    }
    public class LocationAvailability :HmsClass<LocationAvailability_Data>
    {
        public LocationAvailability (): base() { }
        public static LocationAvailability extractLocationAvailability(Intent arg0) {
            return CallStatic<LocationAvailability>("extractLocationAvailability", arg0);
        }
        public static bool hasLocationAvailability(Intent arg0) {
            return CallStatic<bool>("hasLocationAvailability", arg0);
        }
        public bool isLocationAvailable() {
            return Call<bool>("isLocationAvailable");
        }
        public string toString() {
            return Call<string>("toString");
        }
    }
}