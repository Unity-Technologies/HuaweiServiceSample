using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.location
{
    public class LocationServices_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.location.LocationServices";
    }
    public class LocationServices :HmsClass<LocationServices_Data>
    {
        public LocationServices (): base() { }
        public static FusedLocationProviderClient getFusedLocationProviderClient(Activity arg0) {
            return CallStatic<FusedLocationProviderClient>("getFusedLocationProviderClient", arg0);
        }
        public static FusedLocationProviderClient getFusedLocationProviderClient(Context arg0) {
            return CallStatic<FusedLocationProviderClient>("getFusedLocationProviderClient", arg0);
        }
        public static SettingsClient getSettingsClient(Context arg0) {
            return CallStatic<SettingsClient>("getSettingsClient", arg0);
        }
        public static SettingsClient getSettingsClient(Activity arg0) {
            return CallStatic<SettingsClient>("getSettingsClient", arg0);
        }
    }
}