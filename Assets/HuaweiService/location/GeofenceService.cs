using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.location
{
    public class GeofenceService_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.location.GeofenceService";
    }
    public class GeofenceService :HmsClass<GeofenceService_Data>
    {
        public GeofenceService (Context arg0): base(arg0) { }
        public GeofenceService (Activity arg0): base(arg0) { }
        public GeofenceService (): base() { }
        public Task createGeofenceList(GeofenceRequest arg0, PendingIntent arg1) {
            return Call<Task>("createGeofenceList", arg0, arg1);
        }
        public Task deleteGeofenceList(List arg0) {
            return Call<Task>("deleteGeofenceList", arg0);
        }
        public Task deleteGeofenceList(PendingIntent arg0) {
            return Call<Task>("deleteGeofenceList", arg0);
        }
    }
}