using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.RemoteConfig
{
    public class AGConnectConfig_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.remoteconfig.AGConnectConfig";
    }
    public class AGConnectConfig :HmsClass<AGConnectConfig_Data>
    {
        public AGConnectConfig (): base() { }
        public static AGConnectConfig getInstance() {
            return CallStatic<AGConnectConfig>("getInstance");
        }
        public void applyDefault(int arg0) {
            Call("applyDefault", arg0);
        }
        public void applyDefault(Map arg0) {
            Call("applyDefault", arg0);
        }
        public Task fetch() {
            return Call<Task>("fetch");
        }
        public Task fetch(long arg0) {
            return Call<Task>("fetch", arg0);
        }
        public ConfigValues loadLastFetched() {
            return Call<ConfigValues>("loadLastFetched");
        }
        public void apply(ConfigValues arg0) {
            Call("apply", arg0);
        }
        public Map getMergedAll() {
            return Call<Map>("getMergedAll");
        }
        public SOURCE getSource(string arg0) {
            return Call<SOURCE>("getSource", arg0);
        }
        public void clearAll() {
            Call("clearAll");
        }
        public void setDeveloperMode(bool arg0) {
            Call("setDeveloperMode", arg0);
        }
    
        public class SOURCE_Data : IHmsBaseClass{
            public string name => "com.huawei.agconnect.remoteconfig.AGConnectConfig$SOURCE";
        }
        public class SOURCE :HmsClass<SOURCE_Data>
        {
            public static SOURCE STATIC => HmsUtil.GetStaticValue<SOURCE>("STATIC");
        
            public static SOURCE DEFAULT => HmsUtil.GetStaticValue<SOURCE>("DEFAULT");
        
            public static SOURCE REMOTE => HmsUtil.GetStaticValue<SOURCE>("REMOTE");
        
            public SOURCE (): base() { }
        }
    }
}