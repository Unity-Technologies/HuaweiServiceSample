using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.location
{
    public class LocationSettingsRequest_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.location.LocationSettingsRequest";
    }
    public class LocationSettingsRequest :HmsClass<LocationSettingsRequest_Data>
    {
        public LocationSettingsRequest (): base() { }
    
        public class Builder_Data : IHmsBaseClass{
            public string name => "com.huawei.hms.location.LocationSettingsRequest$Builder";
        }
        public class Builder :HmsClass<Builder_Data>
        {
            public Builder (): base() { }
            public Builder addAllLocationRequests(Collection arg0) {
                return Call<Builder>("addAllLocationRequests", arg0);
            }
            public Builder addLocationRequest(LocationRequest arg0) {
                return Call<Builder>("addLocationRequest", arg0);
            }
            public Builder setAlwaysShow(bool arg0) {
                return Call<Builder>("setAlwaysShow", arg0);
            }
            public Builder setNeedBle(bool arg0) {
                return Call<Builder>("setNeedBle", arg0);
            }
            public LocationSettingsRequest build() {
                return Call<LocationSettingsRequest>("build");
            }
        }
    }
}