using UnityEngine;
using System.Collections.Generic;
using HuaweiService;

namespace HuaweiService.Auth
{
    public class VerifyCodeSettings_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.auth.VerifyCodeSettings";
    }
    public class VerifyCodeSettings :HmsClass<VerifyCodeSettings_Data>
    {
        public const int ACTION_REGISTER_LOGIN = 1001;
        public const int ACTION_RESET_PASSWORD = 1002;
        public VerifyCodeSettings (): base() { }
        public int getAction() {
            return Call<int>("getAction");
        }
        public string getLang() {
            return Call<string>("getLang");
        }
        public int getSendInterval() {
            return Call<int>("getSendInterval");
        }
    
        public class Builder_Data : IHmsBaseClass{
            public string name => "com.huawei.agconnect.auth.VerifyCodeSettings$Builder";
        }
        public class Builder :HmsClass<Builder_Data>
        {
            public Builder (): base() { }
            public Builder locale(Locale arg0) {
                return Call<Builder>("locale", arg0);
            }
            public Builder sendInterval(int arg0) {
                return Call<Builder>("sendInterval", arg0);
            }
            public VerifyCodeSettings build() {
                return Call<VerifyCodeSettings>("build");
            }

            public Builder action(int arg0)
            {
                return Call<Builder>("action", arg0);
            }
        }
    }
}