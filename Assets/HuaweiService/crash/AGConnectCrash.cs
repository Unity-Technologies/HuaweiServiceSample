using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.crash
{
    public class AGConnectCrash_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.crash.AGConnectCrash";
    }
    public class AGConnectCrash :HmsClass<AGConnectCrash_Data>
    {
        public AGConnectCrash (): base() { }
        public static AGConnectCrash getInstance() {
            return CallStatic<AGConnectCrash>("getInstance");
        }
        public void enableCrashCollection(bool arg0) {
            Call("enableCrashCollection", arg0);
        }
        public void testIt(Context arg0) {
            Call("testIt", arg0);
        }
        public void setUserId(string arg0) {
            Call("setUserId", arg0);
        }
        public void setCustomKey(string arg0, bool arg1) {
            Call("setCustomKey", arg0, arg1);
        }
        public void setCustomKey(string arg0, long arg1) {
            Call("setCustomKey", arg0, arg1);
        }
        public void setCustomKey(string arg0, int arg1) {
            Call("setCustomKey", arg0, arg1);
        }
        public void setCustomKey(string arg0, string arg1) {
            Call("setCustomKey", arg0, arg1);
        }
        public void setCustomKey(string arg0, double arg1) {
            Call("setCustomKey", arg0, arg1);
        }
        public void setCustomKey(string arg0, float arg1) {
            Call("setCustomKey", arg0, arg1);
        }
        public void log(int arg0, string arg1) {
            Call("log", arg0, arg1);
        }
        public void log(string arg0) {
            Call("log", arg0);
        }
    }
}