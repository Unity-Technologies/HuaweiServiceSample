using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.location
{
    public class GeofenceData_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.location.GeofenceData";
    }
    public class GeofenceData :HmsClass<GeofenceData_Data>
    {
        public const string KEY_ERROR_CODE = "hms_error_code";
        public const string KEY_TRANSITION = "com.huawei.hms.location.geofence.conversion";
        public const string KEY_GEOFENCE_LIST = "com.huawei.hms.location.geofence.geofence_list";
        public const string KEY_LOCATION = "com.huawei.hms.location.geofence.location";
        public GeofenceData (): base() { }
        public static GeofenceData getDataFromIntent(Intent arg0) {
            return CallStatic<GeofenceData>("getDataFromIntent", arg0);
        }
        public int getErrorCode() {
            return Call<int>("getErrorCode");
        }
        public int getConversion() {
            return Call<int>("getConversion");
        }
        public List getConvertingGeofenceList() {
            return Call<List>("getConvertingGeofenceList");
        }
        public Location getConvertingLocation() {
            return Call<Location>("getConvertingLocation");
        }
        public bool isSuccess() {
            return Call<bool>("isSuccess");
        }
    }
}