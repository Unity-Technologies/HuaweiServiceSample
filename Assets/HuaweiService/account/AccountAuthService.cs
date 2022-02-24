using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.Account
{
    public class AccountAuthService_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.support.account.service.AccountAuthService";
    }
    public class AccountAuthService :HmsClass<AccountAuthService_Data>
    {
        public AccountAuthService (): base() { }
        public Intent getSignInIntent() {
            return Call<Intent>("getSignInIntent");
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
        public Task getChannel() {
            return Call<Task>("getChannel");
        }
        public Intent getIndependentSignInIntent(string arg0) {
            return Call<Intent>("getIndependentSignInIntent", arg0);
        }
    }
}