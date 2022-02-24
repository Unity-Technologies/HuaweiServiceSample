using UnityEngine;
using System.Collections.Generic;
using HuaweiService.Auth;

namespace HuaweiService.Account
{
    public class AccountAuthParams_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.support.account.request.AccountAuthParams";
    }
    public class AccountAuthParams :HmsClass<AccountAuthParams_Data>
    {
        public static AccountAuthParams DEFAULT_AUTH_REQUEST_PARAM => HmsUtil.GetStaticValue<AccountAuthParams>("DEFAULT_AUTH_REQUEST_PARAM");
    
        public static AccountAuthParams DEFAULT_AUTH_REQUEST_PARAM_GAME => HmsUtil.GetStaticValue<AccountAuthParams>("DEFAULT_AUTH_REQUEST_PARAM_GAME");
    
        public static Parcelable.Creator CREATOR => HmsUtil.GetStaticValue<Parcelable.Creator>("CREATOR");
    
        public AccountAuthParams (): base() { }
        public List getRequestScopeList() {
            return Call<List>("getRequestScopeList");
        }
        public int hashCode() {
            return Call<int>("hashCode");
        }
        public bool equals(AndroidJavaObject arg0) {
            return Call<bool>("equals", arg0);
        }
    }
}