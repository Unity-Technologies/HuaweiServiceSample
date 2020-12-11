using UnityEngine;
using System.Collections.Generic;
using HuaweiService;

namespace HuaweiService.Auth
{
    public class TokenResult_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.auth.SignInResult";
    }
    public class TokenResult :HmsClass<SignInResult_Data>
    {
        public TokenResult (): base() { }
        
        public string getToken() {
            return Call<string>("getToken");
        }

        public long getExpirePeriod()
        {
            return Call<long>("getExpirePeriod");
        }
        
    }
}