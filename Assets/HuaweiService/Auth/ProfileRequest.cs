using UnityEngine;
using System.Collections.Generic;
using HuaweiService;

namespace HuaweiService.Auth
{
    public class ProfileRequest_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.auth.ProfileRequest";
    }
    public class ProfileRequest :HmsClass<ProfileRequest_Data>
    {
        public ProfileRequest (): base() { }
        public string getDisplayName() {
            return Call<string>("getDisplayName");
        }
        public string getPhotoUrl() {
            return Call<string>("getPhotoUrl");
        }
    
        public class Builder_Data : IHmsBaseClass{
            public string name => "com.huawei.agconnect.auth.ProfileRequest$Builder";
        }
        public class Builder :HmsClass<Builder_Data>
        {
            public Builder (): base() { }
            public Builder setDisplayName(string arg0) {
                return Call<Builder>("setDisplayName", arg0);
            }
            public Builder setPhotoUrl(string arg0) {
                return Call<Builder>("setPhotoUrl", arg0);
            }
            public ProfileRequest build() {
                return Call<ProfileRequest>("build");
            }
        }
    }
}