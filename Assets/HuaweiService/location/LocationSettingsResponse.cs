using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.location
{
    public class LocationSettingsResponse_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.location.LocationSettingsResponse";
    }
    public class LocationSettingsResponse :HmsClass<LocationSettingsResponse_Data>
    {
        public LocationSettingsResponse (LocationSettingsResult arg0): base(arg0) { }
        public LocationSettingsResponse (): base() { }
        public LocationSettingsStates getLocationSettingsStates() {
            return Call<LocationSettingsStates>("getLocationSettingsStates");
        }
    }
}