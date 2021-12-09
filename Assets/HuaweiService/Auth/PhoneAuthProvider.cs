using System;
using UnityEngine;
using System.Collections.Generic;
using HuaweiService;

namespace HuaweiService.Auth
{
    public class PhoneAuthProvider_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.auth.PhoneAuthProvider";
    }
    public class PhoneAuthProvider :HmsClass<PhoneAuthProvider_Data>
    {
        public PhoneAuthProvider (): base() { }
        public static AGConnectAuthCredential credentialWithPassword(string arg0, string arg1, string arg2) {
            return CallStatic<AGConnectAuthCredential>("credentialWithPassword", arg0, arg1, arg2);
        }
        [Obsolete("Method is obsolete.", false)]
        public static Task requestVerifyCode(string arg0, string arg1, VerifyCodeSettings arg2) {
            return CallStatic<Task>("requestVerifyCode", arg0, arg1, arg2);
        }
        [Obsolete("Method is obsolete.", false)]
        public static void verifyPhoneCode(string arg0, string arg1, VerifyCodeSettings arg2, OnVerifyCodeCallBack arg3) {
            CallStatic("verifyPhoneCode", arg0, arg1, arg2, arg3);
        }

        public static AGConnectAuthCredential credentialWithVerifyCode(string arg0, string arg1, string arg2, string arg3)
        {
            return CallStatic<AGConnectAuthCredential>("credentialWithVerifyCode",arg0, arg1, arg2, arg3);
        }
    }
}