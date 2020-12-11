using UnityEngine;
using System.Collections.Generic;
using HuaweiService;

namespace HuaweiService.Auth
{
    public class QQAuthProvider_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.auth.QQAuthProvider";
    }
    public class QQAuthProvider :HmsClass<QQAuthProvider_Data>
    {
        public QQAuthProvider (): base() { }
        public static AGConnectAuthCredential credentialWithToken(string arg0, string arg1) {
            return CallStatic<AGConnectAuthCredential>("credentialWithToken", arg0, arg1);
        }
        public static AGConnectAuthCredential credentialWithToken(string arg0, string arg1, bool arg2) {
            return CallStatic<AGConnectAuthCredential>("credentialWithToken", arg0, arg1, arg2);
        }
    }
}