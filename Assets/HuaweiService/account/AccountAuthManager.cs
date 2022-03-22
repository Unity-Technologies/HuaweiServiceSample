using UnityEngine;
using System.Collections.Generic;
using HuaweiService.Auth;

namespace HuaweiService.Account
{
    public class AccountAuthManager_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.support.account.AccountAuthManager";
    }
    public class AccountAuthManager :HmsClass<AccountAuthManager_Data>
    {
        public AccountAuthManager (): base() { }
        public static AccountAuthService getService(Activity arg0, AccountAuthParams arg1) {
            return CallStatic<AccountAuthService>("getService", arg0, arg1);
        }
        public static AccountAuthService getService(Context arg0, AccountAuthParams arg1) {
            return CallStatic<AccountAuthService>("getService", arg0, arg1);
        }
        public static Task parseAuthResultFromIntent(Intent arg0) {
            return CallStatic<Task>("parseAuthResultFromIntent", arg0);
        }
        public static AuthAccount getAuthResult() {
            return CallStatic<AuthAccount>("getAuthResult");
        }
        public static AuthAccount getAuthResultWithScopes(List arg0) {
            return CallStatic<AuthAccount>("getAuthResultWithScopes", arg0);
        }
        public static AuthAccount getExtendedAuthResult(AccountAuthExtendedParams arg0) {
            return CallStatic<AuthAccount>("getExtendedAuthResult", arg0);
        }
        public static bool containScopes(AuthAccount arg0, AccountAuthExtendedParams arg1) {
            return CallStatic<bool>("containScopes", arg0, arg1);
        }
        public static bool containScopes(AuthAccount arg0, List arg1) {
            return CallStatic<bool>("containScopes", arg0, arg1);
        }
        public static void addAuthScopes(Fragment arg0, int arg1, List arg2) {
            CallStatic("addAuthScopes", arg0, arg1, arg2);
        }
        public static void addAuthScopes(Activity arg0, int arg1, List arg2) {
            CallStatic("addAuthScopes", arg0, arg1, arg2);
        }
        public static void addAuthScopes(Fragment arg0, int arg1, AccountAuthExtendedParams arg2) {
            CallStatic("addAuthScopes", arg0, arg1, arg2);
        }
        public static void addAuthScopes(Activity arg0, int arg1, AccountAuthExtendedParams arg2) {
            CallStatic("addAuthScopes", arg0, arg1, arg2);
        }
    }
}