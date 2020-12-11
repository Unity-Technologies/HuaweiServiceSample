using UnityEngine;
using System.Collections.Generic;
using HuaweiService;

namespace HuaweiService.Auth
{
    public class WeiboAuthProvider_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.auth.WeiboAuthProvider";
    }
    public class WeiboAuthProvider :HmsClass<WeiboAuthProvider_Data>
    {
        public WeiboAuthProvider (): base() { }
        public static AGConnectAuthCredential credentialWithToken(string arg0, string arg1) {
            return CallStatic<AGConnectAuthCredential>("credentialWithToken", arg0, arg1);
        }
        public static AGConnectAuthCredential credentialWithToken(string arg0, string arg1, bool arg2) {
            return CallStatic<AGConnectAuthCredential>("credentialWithToken", arg0, arg1, arg2);
        }
    }
}