using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.location
{
    public class LocationSettingsResult_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.location.LocationSettingsResult";
    }
    public class LocationSettingsResult :HmsClass<LocationSettingsResult_Data>
    {
        public LocationSettingsResult (): base() { }
    }
}