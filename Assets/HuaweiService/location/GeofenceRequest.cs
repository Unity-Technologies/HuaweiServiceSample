using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.location
{
    public class GeofenceRequest_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.location.GeofenceRequest";
    }
    public class GeofenceRequest :HmsClass<GeofenceRequest_Data>
    {
        public const int ENTER_INIT_CONVERSION = 1;
        public const int EXIT_INIT_CONVERSION = 2;
        public const int DWELL_INIT_CONVERSION = 4;
        public const int COORDINATE_TYPE_WGS_84 = 1;
        public const int COORDINATE_TYPE_GCJ_02 = 0;
        public GeofenceRequest (): base() { }
        public List getGeofences() {
            return Call<List>("getGeofences");
        }
        public int getInitConversions() {
            return Call<int>("getInitConversions");
        }
    
        public class Builder_Data : IHmsBaseClass{
            public string name => "com.huawei.hms.location.GeofenceRequest$Builder";
        }
        public class Builder :HmsClass<Builder_Data>
        {
            public Builder (): base() { }
            public Builder createGeofence(Geofence arg0) {
                return Call<Builder>("createGeofence", arg0);
            }
            public Builder createGeofenceList(List arg0) {
                return Call<Builder>("createGeofenceList", arg0);
            }
            public Builder setInitConversions(int arg0) {
                return Call<Builder>("setInitConversions", arg0);
            }
            public GeofenceRequest build() {
                return Call<GeofenceRequest>("build");
            }
        }
    }
}