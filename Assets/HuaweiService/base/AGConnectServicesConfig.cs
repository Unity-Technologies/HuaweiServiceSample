using System;
using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class AGConnectServicesConfig_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.config.AGConnectServicesConfig";
    }
    
    [Obsolete("Method is obsolete.", false)]
    public class AGConnectServicesConfig :HmsClass<AGConnectServicesConfig_Data>
    {
        public AGConnectServicesConfig (): base() { }
        public static AGConnectServicesConfig fromContext(Context arg0) {
            return CallStatic<AGConnectServicesConfig>("fromContext", arg0);
        }
        public static AGConnectServicesConfig fromContext(Context arg0, string arg1) {
            return CallStatic<AGConnectServicesConfig>("fromContext", arg0, arg1);
        }
        public bool getBoolean(string arg0) {
            return Call<bool>("getBoolean", arg0);
        }
        public bool getBoolean(string arg0, bool arg1) {
            return Call<bool>("getBoolean", arg0, arg1);
        }
        public int getInt(string arg0) {
            return Call<int>("getInt", arg0);
        }
        public int getInt(string arg0, int arg1) {
            return Call<int>("getInt", arg0, arg1);
        }
        public string getString(string arg0, string arg1) {
            return Call<string>("getString", arg0, arg1);
        }
        public string getString(string arg0) {
            return Call<string>("getString", arg0);
        }
    }
}