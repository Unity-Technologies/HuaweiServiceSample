using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.location
{
    public class LocationRequest_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.location.LocationRequest";
    }
    public class LocationRequest :HmsClass<LocationRequest_Data>
    {
        public const int PRIORITY_HIGH_ACCURACY = 100;
        public const int PRIORITY_BALANCED_POWER_ACCURACY = 102;
        public const int PRIORITY_LOW_POWER = 104;
        public const int PRIORITY_NO_POWER = 105;
        public const int PRIORITY_HD_ACCURACY = 200;
        public LocationRequest (): base() { }
        public static LocationRequest create() {
            return CallStatic<LocationRequest>("create");
        }
        public LocationRequest setPriority(int arg0) {
            return Call<LocationRequest>("setPriority", arg0);
        }
        public LocationRequest setInterval(long arg0) {
            return Call<LocationRequest>("setInterval", arg0);
        }
        public LocationRequest setNumUpdates(int arg0) {
            return Call<LocationRequest>("setNumUpdates", arg0);
        }
        public LocationRequest setFastestInterval(long arg0) {
            return Call<LocationRequest>("setFastestInterval", arg0);
        }
        public bool isFastestIntervalExplicitlySet() {
            return Call<bool>("isFastestIntervalExplicitlySet");
        }
        public LocationRequest setExpirationTime(long arg0) {
            return Call<LocationRequest>("setExpirationTime", arg0);
        }
        public LocationRequest setExpirationDuration(long arg0) {
            return Call<LocationRequest>("setExpirationDuration", arg0);
        }
        public LocationRequest setSmallestDisplacement(float arg0) {
            return Call<LocationRequest>("setSmallestDisplacement", arg0);
        }
        public LocationRequest setMaxWaitTime(long arg0) {
            return Call<LocationRequest>("setMaxWaitTime", arg0);
        }
        public LocationRequest setNeedAddress(bool arg0) {
            return Call<LocationRequest>("setNeedAddress", arg0);
        }
        public LocationRequest setLanguage(string arg0) {
            return Call<LocationRequest>("setLanguage", arg0);
        }
        public LocationRequest setCountryCode(string arg0) {
            return Call<LocationRequest>("setCountryCode", arg0);
        }
    }
}