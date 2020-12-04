using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.RemoteConfig
{
    public class ConfigValues_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.remoteconfig.ConfigValues";
    }
    public class ConfigValues :HmsClass<ConfigValues_Data>
    {
        public ConfigValues (): base() { }
        public bool containKey(string arg0) {
            return Call<bool>("containKey", arg0);
        }
        public Boolean getValueAsBoolean(string arg0) {
            return Call<Boolean>("getValueAsBoolean", arg0);
        }
        public Double getValueAsDouble(string arg0) {
            return Call<Double>("getValueAsDouble", arg0);
        }
        public Long getValueAsLong(string arg0) {
            return Call<Long>("getValueAsLong", arg0);
        }
        public string getValueAsString(string arg0) {
            return Call<string>("getValueAsString", arg0);
        }
        public byte[] getValueAsByteArray(string arg0) {
            return Call<byte[]>("getValueAsByteArray", arg0);
        }
    }
}