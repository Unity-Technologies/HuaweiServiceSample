using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class AGConnectOptionsBuilder_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.AGConnectOptionsBuilder";
    }
    public class AGConnectOptionsBuilder :HmsClass<AGConnectOptionsBuilder_Data>
    {
        public AGConnectOptionsBuilder (): base() { }
        public AGConnectOptionsBuilder setProductId(string arg0) {
            return Call<AGConnectOptionsBuilder>("setProductId", arg0);
        }
        public AGConnectOptionsBuilder setAppId(string arg0) {
            return Call<AGConnectOptionsBuilder>("setAppId", arg0);
        }
        public AGConnectOptionsBuilder setCPId(string arg0) {
            return Call<AGConnectOptionsBuilder>("setCPId", arg0);
        }
        public AGConnectOptionsBuilder setClientId(string arg0) {
            return Call<AGConnectOptionsBuilder>("setClientId", arg0);
        }
        public AGConnectOptionsBuilder setClientSecret(string arg0) {
            return Call<AGConnectOptionsBuilder>("setClientSecret", arg0);
        }
        public AGConnectOptionsBuilder setApiKey(string arg0) {
            return Call<AGConnectOptionsBuilder>("setApiKey", arg0);
        }
        public Map getCustomConfigMap() {
            return Call<Map>("getCustomConfigMap");
        }
        public AGConnectOptionsBuilder setCustomValue(string arg0, string arg1) {
            return Call<AGConnectOptionsBuilder>("setCustomValue", arg0, arg1);
        }
        public AGConnectOptionsBuilder setCustomCredentialProvider(CustomCredentialsProvider arg0) {
            return Call<AGConnectOptionsBuilder>("setCustomCredentialProvider", arg0);
        }
        public AGConnectOptionsBuilder setCustomAuthProvider(CustomAuthProvider arg0) {
            return Call<AGConnectOptionsBuilder>("setCustomAuthProvider", arg0);
        }
        public AGConnectOptionsBuilder setRoutePolicy(AGCRoutePolicy arg0) {
            return Call<AGConnectOptionsBuilder>("setRoutePolicy", arg0);
        }
        public AGCRoutePolicy getRoutePolicy() {
            return Call<AGCRoutePolicy>("getRoutePolicy");
        }
        public AGConnectOptionsBuilder setPackageName(string arg0) {
            return Call<AGConnectOptionsBuilder>("setPackageName", arg0);
        }
        public AGConnectOptionsBuilder setInputStream(InputStream arg0) {
            return Call<AGConnectOptionsBuilder>("setInputStream", arg0);
        }
        public InputStream getInputStream() {
            return Call<InputStream>("getInputStream");
        }
        public AGConnectOptions build(Context arg0, string arg1) {
            return Call<AGConnectOptions>("build", arg0, arg1);
        }
        public AGConnectOptions build(Context arg0) {
            return Call<AGConnectOptions>("build", arg0);
        }
    }
}