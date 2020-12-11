using UnityEngine;
using System.Collections.Generic;
using HuaweiService;

namespace HuaweiService.Auth
{
    public class GoogleGameAuthProvider_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.auth.GoogleGameAuthProvider";
    }
    public class GoogleGameAuthProvider :HmsClass<GoogleGameAuthProvider_Data>
    {
        public GoogleGameAuthProvider (): base() { }
        public static AGConnectAuthCredential credentialWithToken(string arg0) {
            return CallStatic<AGConnectAuthCredential>("credentialWithToken", arg0);
        }
        public static AGConnectAuthCredential credentialWithToken(string arg0, bool arg1) {
            return CallStatic<AGConnectAuthCredential>("credentialWithToken", arg0, arg1);
        }
    }
}