using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class AGConnectOptions_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.AGConnectOptions";
    }
    public class AGConnectOptions :HmsClass<AGConnectOptions_Data>
    {
        public AGConnectOptions (): base() { }
        public string getIdentifier() {
            return Call<string>("getIdentifier");
        }
        public Context getContext() {
            return Call<Context>("getContext");
        }
        public AGCRoutePolicy getRoutePolicy() {
            return Call<AGCRoutePolicy>("getRoutePolicy");
        }
        public string getPackageName() {
            return Call<string>("getPackageName");
        }
        public bool getBoolean(string arg0, bool arg1) {
            return Call<bool>("getBoolean", arg0, arg1);
        }
        public bool getBoolean(string arg0) {
            return Call<bool>("getBoolean", arg0);
        }
        public int getInt(string arg0, int arg1) {
            return Call<int>("getInt", arg0, arg1);
        }
        public int getInt(string arg0) {
            return Call<int>("getInt", arg0);
        }
        public string getString(string arg0, string arg1) {
            return Call<string>("getString", arg0, arg1);
        }
        public string getString(string arg0) {
            return Call<string>("getString", arg0);
        }
    }
}