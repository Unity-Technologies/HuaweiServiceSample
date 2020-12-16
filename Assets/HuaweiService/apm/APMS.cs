using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.apm
{
    public class APMS_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.apms.APMS";
    }
    public class APMS :HmsClass<APMS_Data>
    {
        public APMS (): base() { }
        public static APMS getInstance() {
            return CallStatic<APMS>("getInstance");
        }
        public void enableCollection(bool arg0) {
            Call("enableCollection", arg0);
        }
        public void enableAnrMonitor(bool arg0) {
            Call("enableAnrMonitor", arg0);
        }
        public CustomTrace createCustomTrace(string arg0) {
            return Call<CustomTrace>("createCustomTrace", arg0);
        }
        public NetworkMeasure createNetworkMeasure(string arg0, string arg1) {
            return Call<NetworkMeasure>("createNetworkMeasure", arg0, arg1);
        }
    }
}