using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.AppLinking
{
    public class AGConnectAppLinking_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.applinking.AGConnectAppLinking";
    }
    public class AGConnectAppLinking :HmsClass<AGConnectAppLinking_Data>
    {
        public AGConnectAppLinking (): base() { }
        public static AGConnectAppLinking getInstance() {
            return CallStatic<AGConnectAppLinking>("getInstance");
        }
        public Task getAppLinking(Activity arg0, Intent arg1) {
            return Call<Task>("getAppLinking", arg0, arg1);
        }
        public Task getAppLinking(Activity arg0, Uri arg1) {
            return Call<Task>("getAppLinking", arg0, arg1);
        }
        public Task getAppLinking(Activity arg0) {
            return Call<Task>("getAppLinking", arg0);
        }
    }
}