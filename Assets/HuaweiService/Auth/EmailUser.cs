using UnityEngine;
using System.Collections.Generic;
using HuaweiService;

namespace HuaweiService.Auth
{
    public class EmailUser_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.auth.EmailUser";
    }
    public class EmailUser :HmsClass<EmailUser_Data>
    {
        public EmailUser (): base() { }
        public string getEmail() {
            return Call<string>("getEmail");
        }
        public int verifyEmailUser(bool arg0) {
            return Call<int>("verifyEmailUser", arg0);
        }
    
        public class Builder_Data : IHmsBaseClass{
            public string name => "com.huawei.agconnect.auth.EmailUser$Builder";
        }
        public class Builder :HmsClass<Builder_Data>
        {
            public Builder (): base() { }
            public Builder setPassword(string arg0) {
                return Call<Builder>("setPassword", arg0);
            }
            public Builder setEmail(string arg0) {
                return Call<Builder>("setEmail", arg0);
            }
            public Builder setVerifyCode(string arg0) {
                return Call<Builder>("setVerifyCode", arg0);
            }
            public EmailUser build() {
                return Call<EmailUser>("build");
            }
        }
    }
}