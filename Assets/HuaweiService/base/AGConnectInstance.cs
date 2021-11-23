using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class AGConnectInstance_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.AGConnectInstance";
    }
    public class AGConnectInstance :HmsClass<AGConnectInstance_Data>
    {
        public AGConnectInstance (): base() { }
        public static void initialize(Context arg0, AGConnectOptionsBuilder arg1) {
            CallStatic("initialize", arg0, arg1);
        }
        public static void initialize(Context arg0) {
            CallStatic("initialize", arg0);
        }
        public static AGConnectInstance buildInstance(AGConnectOptions arg0) {
            return CallStatic<AGConnectInstance>("buildInstance", arg0);
        }
        public static AGConnectInstance getInstance(string arg0) {
            return CallStatic<AGConnectInstance>("getInstance", arg0);
        }
        public static AGConnectInstance getInstance() {
            return CallStatic<AGConnectInstance>("getInstance");
        }
        public AGConnectOptions getOptions() {
            return Call<AGConnectOptions>("getOptions");
        }
        public string getIdentifier() {
            return Call<string>("getIdentifier");
        }
    }
}