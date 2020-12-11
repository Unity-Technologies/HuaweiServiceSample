using UnityEngine;
using System.Collections.Generic;
using HuaweiService;

namespace HuaweiService.Auth
{
    public class TokenSnapshot_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.core.service.auth.TokenSnapshot";
    }
    public class TokenSnapshot :HmsClass<TokenSnapshot_Data>
    {
        public TokenSnapshot (): base() { }
        public TokenSnapshot.State getState() {
            return Call<State>("getState");
        }
        public string getToken() {
            return Call<string>("getToken");
        }

        public enum State
        {
            SIGNED_IN,
            TOKEN_UPDATED,
            TOKEN_INVALID,
            SIGNED_OUT
        }
    }
}