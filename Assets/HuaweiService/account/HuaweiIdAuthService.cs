using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.Account
{
    public class HuaweiIdAuthService_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.support.hwid.service.HuaweiIdAuthService";
    }
    public class HuaweiIdAuthService :HmsClass<HuaweiIdAuthService_Data>
    {
        public HuaweiIdAuthService (): base() { }
        public Intent getSignInIntent(string arg0) {
            return Call<Intent>("getSignInIntent", arg0);
        }
        public Intent getSignInIntent() {
            return Call<Intent>("getSignInIntent");
        }
        public Task silentSignIn(string arg0) {
            return Call<Task>("silentSignIn", arg0);
        }
        public Task silentSignIn() {
            return Call<Task>("silentSignIn");
        }
        public Task signOut() {
            return Call<Task>("signOut");
        }
        public Task cancelAuthorization() {
            return Call<Task>("cancelAuthorization");
        }
    }
}