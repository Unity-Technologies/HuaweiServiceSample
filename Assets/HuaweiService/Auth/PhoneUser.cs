using UnityEngine;
using System.Collections.Generic;
using HuaweiService;

namespace HuaweiService.Auth
{
    public class PhoneUser_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.auth.PhoneUser";
    }
    public class PhoneUser :HmsClass<PhoneUser_Data>
    {
        public PhoneUser (): base() { }
        public string getPhone() {
            return Call<string>("getPhone");
        }
        public int verifyPhoneUser(bool arg0) {
            return Call<int>("verifyPhoneUser", arg0);
        }
    
        public class Builder_Data : IHmsBaseClass{
            public string name => "com.huawei.agconnect.auth.PhoneUser$Builder";
        }
        public class Builder :HmsClass<Builder_Data>
        {
            public Builder (): base() { }
            public Builder setCountryCode(string arg0) {
                return Call<Builder>("setCountryCode", arg0);
            }
            public Builder setPhoneNumber(string arg0) {
                return Call<Builder>("setPhoneNumber", arg0);
            }
            public Builder setPassword(string arg0) {
                return Call<Builder>("setPassword", arg0);
            }
            public Builder setVerifyCode(string arg0) {
                return Call<Builder>("setVerifyCode", arg0);
            }
            public PhoneUser build() {
                return Call<PhoneUser>("build");
            }
        }
    }
}