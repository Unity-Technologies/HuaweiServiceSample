using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.Account
{
    public class AccountAuthParamsHelper_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.support.account.request.AccountAuthParamsHelper";
    }
    public class AccountAuthParamsHelper :HmsClass<AccountAuthParamsHelper_Data>
    {
        public AccountAuthParamsHelper (AccountAuthParams arg0): base(arg0) { }
        public AccountAuthParamsHelper (): base() { }
        public AccountAuthParamsHelper setUid() {
            return Call<AccountAuthParamsHelper>("setUid");
        }
        public AccountAuthParamsHelper setAccessToken() {
            return Call<AccountAuthParamsHelper>("setAccessToken");
        }
        public AccountAuthParamsHelper setAuthorizationCode() {
            return Call<AccountAuthParamsHelper>("setAuthorizationCode");
        }
        public AccountAuthParamsHelper setScopeList(List arg0) {
            return Call<AccountAuthParamsHelper>("setScopeList", arg0);
        }
        public AccountAuthParamsHelper setEmail() {
            return Call<AccountAuthParamsHelper>("setEmail");
        }
        public AccountAuthParamsHelper setId() {
            return Call<AccountAuthParamsHelper>("setId");
        }
        public AccountAuthParamsHelper setIdToken() {
            return Call<AccountAuthParamsHelper>("setIdToken");
        }
        public AccountAuthParamsHelper setProfile() {
            return Call<AccountAuthParamsHelper>("setProfile");
        }
        public AccountAuthParamsHelper setCarrierId() {
            return Call<AccountAuthParamsHelper>("setCarrierId");
        }
        public AccountAuthParams createParams() {
            return Call<AccountAuthParams>("createParams");
        }
    }
}