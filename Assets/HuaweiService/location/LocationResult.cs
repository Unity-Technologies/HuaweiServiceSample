using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.location
{
    public class LocationResult_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.location.LocationResult";
    }
    public class LocationResult :HmsClass<LocationResult_Data>
    {
        public LocationResult (): base() { }
        public static LocationResult create(List arg0) {
            return CallStatic<LocationResult>("create", arg0);
        }
        public static LocationResult extractResult(Intent arg0) {
            return CallStatic<LocationResult>("extractResult", arg0);
        }
        public Location getLastLocation() {
            return Call<Location>("getLastLocation");
        }
        public List getLocations() {
            return Call<List>("getLocations");
        }
        public static bool hasResult(Intent arg0) {
            return CallStatic<bool>("hasResult", arg0);
        }
        public HWLocation getLastHWLocation() {
            return Call<HWLocation>("getLastHWLocation");
        }
        public List getHWLocationList() {
            return Call<List>("getHWLocationList");
        }
    }
}