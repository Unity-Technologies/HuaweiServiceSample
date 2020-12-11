using UnityEngine;
using System.Collections.Generic;
using HuaweiService;

namespace HuaweiService.Auth
{
    public class HWGameAuthProvider_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.auth.HWGameAuthProvider";
    }
    public class HWGameAuthProvider :HmsClass<HWGameAuthProvider_Data>
    {
        public HWGameAuthProvider (): base() { }
    
        public class Builder_Data : IHmsBaseClass{
            public string name => "com.huawei.agconnect.auth.HWGameAuthProvider$Builder";
        }
        public class Builder :HmsClass<Builder_Data>
        {
            public Builder (): base() { }
            public Builder setPlayerSign(string arg0) {
                return Call<Builder>("setPlayerSign", arg0);
            }
            public Builder setPlayerId(string arg0) {
                return Call<Builder>("setPlayerId", arg0);
            }
            public Builder setDisplayName(string arg0) {
                return Call<Builder>("setDisplayName", arg0);
            }
            public Builder setImageUrl(string arg0) {
                return Call<Builder>("setImageUrl", arg0);
            }
            public Builder setPlayerLevel(int arg0) {
                return Call<Builder>("setPlayerLevel", arg0);
            }
            public Builder setSignTs(string arg0) {
                return Call<Builder>("setSignTs", arg0);
            }
            public Builder setAutoCreateUser(bool arg0) {
                return Call<Builder>("setAutoCreateUser", arg0);
            }
            public AGConnectAuthCredential build() {
                return Call<AGConnectAuthCredential>("build");
            }
        }
    }
}