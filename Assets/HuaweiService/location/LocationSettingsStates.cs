using UnityEngine;
using System.Collections.Generic;
using HuaweiService.Auth;

namespace HuaweiService.location
{
    public class LocationSettingsStates_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.location.LocationSettingsStates";
    }
    public class LocationSettingsStates :HmsClass<LocationSettingsStates_Data>
    {
        public static Parcelable.Creator CREATOR => HmsUtil.GetStaticValue<Parcelable.Creator>("CREATOR");
        public LocationSettingsStates (bool arg0, bool arg1, bool arg2, bool arg3, bool arg4, bool arg5, bool arg6, bool arg7): base(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7) { }
        public LocationSettingsStates (): base() { }
        public bool isBlePresent() {
            return Call<bool>("isBlePresent");
        }
        public bool isBleUsable() {
            return Call<bool>("isBleUsable");
        }
        public bool isGpsPresent() {
            return Call<bool>("isGpsPresent");
        }
        public bool isGpsUsable() {
            return Call<bool>("isGpsUsable");
        }
        public bool isLocationPresent() {
            return Call<bool>("isLocationPresent");
        }
        public bool isLocationUsable() {
            return Call<bool>("isLocationUsable");
        }
        public bool isNetworkLocationPresent() {
            return Call<bool>("isNetworkLocationPresent");
        }
        public bool isNetworkLocationUsable() {
            return Call<bool>("isNetworkLocationUsable");
        }
    }
}