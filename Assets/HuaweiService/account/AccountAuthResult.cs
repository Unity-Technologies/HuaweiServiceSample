using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.Account
{
    public class AccountAuthResult_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.support.account.result.AccountAuthResult";
    }
    public class AccountAuthResult :HmsClass<AccountAuthResult_Data>
    {
        public AccountAuthResult (): base() { }
        public AuthAccount getAccount() {
            return Call<AuthAccount>("getAccount");
        }
        public void setAuthAccount(AuthAccount arg0) {
            Call("setAuthAccount", arg0);
        }
        public bool isSuccess() {
            return Call<bool>("isSuccess");
        }
    }
}