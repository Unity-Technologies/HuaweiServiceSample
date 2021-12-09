using System;
using UnityEngine;
using System.Collections.Generic;
using HuaweiService;

namespace HuaweiService.Auth
{
    public class EmailAuthProvider_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.auth.EmailAuthProvider";
    }
    
    public class EmailAuthProvider :HmsClass<EmailAuthProvider_Data>
    {
        public EmailAuthProvider (): base() { }
        public static AGConnectAuthCredential credentialWithPassword(string arg0, string arg1) {
            return CallStatic<AGConnectAuthCredential>("credentialWithPassword", arg0, arg1);
        }
        public static AGConnectAuthCredential credentialWithVerifyCode(string arg0, string arg1, string arg2) {
            return CallStatic<AGConnectAuthCredential>("credentialWithVerifyCode", arg0, arg1, arg2);
        }
        [Obsolete("Method is obsolete.", false)]
        public static Task requestVerifyCode(string arg0, VerifyCodeSettings arg1) {
            return CallStatic<Task>("requestVerifyCode", arg0, arg1);
        }
        [Obsolete("Method is obsolete.", false)]
        public static void verifyEmailCode(string arg0, VerifyCodeSettings arg1, OnVerifyCodeCallBack arg2) {
            CallStatic("verifyEmailCode", arg0, arg1, arg2);
        }
        
    }
    public interface OnVerifyCodeCallBack {
        void onVerifySuccess(string var1, string var2);

        void onVerifyFailure(Exception var1);
    }
}