using UnityEngine;
using System.Collections.Generic;
using HuaweiService;

namespace HuaweiService.Auth
{
    public class HuaweiIdAuthService_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.support.hwid.service.HuaweiIdAuthService";
    }
    public class HuaweiIdAuthService :HmsClass<HuaweiIdAuthService_Data>
    {
        public HuaweiIdAuthService (): base() { }
        public Task silentSignIn(string arg0) {
            return Call<Task>("silentSignIn", arg0);
        }
        public Task silentSignIn() {
            return Call<Task>("silentSignIn");
        }
        public Intent getSignInIntent(string arg0) {
            return Call<Intent>("getSignInIntent", arg0);
        }
    }
}