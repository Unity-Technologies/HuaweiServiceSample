using UnityEngine;
using System.Collections.Generic;

namespace HuaweiHms
{
    public class LocationSettingsStates_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.location.LocationSettingsStates";
    }
    public class LocationSettingsStates :HmsClass<LocationSettingsStates_Data>
    {
        public LocationSettingsStates (): base() { }
        public LocationSettingsStates (bool arg0, bool arg1, bool arg2, bool arg3, bool arg4, bool arg5): base(arg0, arg1, arg2, arg3, arg4, arg5) { }
    }
}