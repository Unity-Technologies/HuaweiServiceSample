using UnityEngine;
using System.Collections.Generic;
using HuaweiService.Auth;

namespace HuaweiService.location
{
    public class LocationSettingsResult_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.location.LocationSettingsResult";
    }
    public class LocationSettingsResult :HmsClass<LocationSettingsResult_Data>
    {
        public static Parcelable.Creator CREATOR => HmsUtil.GetStaticValue<Parcelable.Creator>("CREATOR");
        public LocationSettingsResult (): base() { }
    }
}