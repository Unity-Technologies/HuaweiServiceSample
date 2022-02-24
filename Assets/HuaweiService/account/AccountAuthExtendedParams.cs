using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.Account
{
    public class AccountAuthExtendedParams_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.support.account.request.AccountAuthExtendedParams";
    }
    public class AccountAuthExtendedParams :HmsClass<AccountAuthExtendedParams_Data>
    {
        public AccountAuthExtendedParams (): base() { }
    }
}