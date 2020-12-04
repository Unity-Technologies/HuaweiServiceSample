using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.location
{
    public class GeofenceErrorCodes_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.location.GeofenceErrorCodes";
    }
    public class GeofenceErrorCodes :HmsClass<GeofenceErrorCodes_Data>
    {
        public const int GEOFENCE_UNAVAILABLE = 10200;
        public const int GEOFENCE_NUMBER_OVER_LIMIT = 10201;
        public const int GEOFENCE_PENDINGINTENT_OVER_LIMIT = 10202;
        public const int GEOFENCE_INSUFFICIENT_PERMISSION = 10204;
        public const int GEOFENCE_REQUEST_TOO_OFTEN = 10205;
        public GeofenceErrorCodes (): base() { }
        public static string getErrorMessage(int arg0) {
            return CallStatic<string>("getErrorMessage", arg0);
        }
    }
}