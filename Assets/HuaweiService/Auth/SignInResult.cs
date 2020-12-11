using UnityEngine;
using System.Collections.Generic;
using HuaweiService;

namespace HuaweiService.Auth
{
    public class SignInResult_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.auth.SignInResult";
    }
    public class SignInResult :HmsClass<SignInResult_Data>
    {
        public SignInResult (): base() { }
        
        public AGConnectUser getUser() {
            return Call<AGConnectUser>("getUser");
        }
        
    }
}