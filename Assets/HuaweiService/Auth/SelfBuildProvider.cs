using UnityEngine;
using System.Collections.Generic;
using HuaweiService;

namespace HuaweiService.Auth
{
    public class SelfBuildProvider_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.auth.SelfBuildProvider";
    }
    public class SelfBuildProvider :HmsClass<SelfBuildProvider_Data>
    {
        public SelfBuildProvider (): base() { }
        public static AGConnectAuthCredential credentialWithToken(string arg0) {
            return CallStatic<AGConnectAuthCredential>("credentialWithToken", arg0);
        }
        public static AGConnectAuthCredential credentialWithToken(string arg0, bool arg1) {
            return CallStatic<AGConnectAuthCredential>("credentialWithToken", arg0, arg1);
        }
    }
}