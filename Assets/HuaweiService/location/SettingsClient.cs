using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.location
{
    public class SettingsClient_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.location.SettingsClient";
    }
    public class SettingsClient :HmsClass<SettingsClient_Data>
    {
        public SettingsClient (Context arg0): base(arg0) { }
        public SettingsClient (Activity arg0): base(arg0) { }
        public SettingsClient (): base() { }
        public Task checkLocationSettings(LocationSettingsRequest arg0) {
            return Call<Task>("checkLocationSettings", arg0);
        }
    }
}