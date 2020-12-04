using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class LocationManager_Data : IHmsBaseClass{
        public string name => "android.location.LocationManager";
    }
    public class LocationManager :HmsClass<LocationManager_Data>
    {
        public const string GPS_PROVIDER = "gps";
        public const string KEY_LOCATION_CHANGED = "location";
        public const string KEY_PROVIDER_ENABLED = "providerEnabled";
        public const string KEY_PROXIMITY_ENTERING = "entering";
        public const string KEY_STATUS_CHANGED = "status";
        public const string MODE_CHANGED_ACTION = "android.location.MODE_CHANGED";
        public const string NETWORK_PROVIDER = "network";
        public const string PASSIVE_PROVIDER = "passive";
        public const string PROVIDERS_CHANGED_ACTION = "android.location.PROVIDERS_CHANGED";
        public LocationManager (): base() { }
    }
}