using UnityEngine;
using System.Collections.Generic;

namespace HuaweiHms
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
        public bool getValueAsBoolean(string arg0) {
            return Call<bool>("getValueAsBoolean", arg0);
        }
        public double getValueAsDouble(string arg0) {
            return Call<double>("getValueAsDouble", arg0);
        }
        public long getValueAsLong(string arg0) {
            return Call<long>("getValueAsLong", arg0);
        }
        public string getValueAsString(string arg0) {
            return Call<string>("getValueAsString", arg0);
        }
        public byte[] getValueAsByteArray(string arg0) {
            return Call<byte[]>("getValueAsByteArray", arg0);
        }
    }
}