using UnityEngine;
using System.Collections.Generic;
using HuaweiService;

namespace HuaweiService.Auth
{
    public class HuaweiIdAuthManager_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.support.hwid.HuaweiIdAuthManager";
    }
    public class HuaweiIdAuthManager :HmsClass<HuaweiIdAuthManager_Data>
    {
        public HuaweiIdAuthManager (): base() { }
        public static HuaweiIdAuthService getService(Context arg0, HuaweiIdAuthParams arg1) {
            return CallStatic<HuaweiIdAuthService>("getService", arg0, arg1);
        }
        public static HuaweiIdAuthService getService(Activity arg0, HuaweiIdAuthParams arg1) {
            return CallStatic<HuaweiIdAuthService>("getService", arg0, arg1);
        }
        public static Task parseAuthResultFromIntent(Intent arg0) {
            return CallStatic<Task>("parseAuthResultFromIntent", arg0);
        }
        public static AuthHuaweiId getAuthResult() {
            return CallStatic<AuthHuaweiId>("getAuthResult");
        }
        public static AuthHuaweiId getAuthResultWithScopes(List<Scope> arg0) {
            return CallStatic<AuthHuaweiId>("getAuthResultWithScopes", arg0);
        }
        public static AuthHuaweiId getExtendedAuthResult(HuaweiIdAuthExtendedParams arg0) {
            return CallStatic<AuthHuaweiId>("getExtendedAuthResult", arg0);
        }
        public static bool containScopes(AuthHuaweiId arg0, HuaweiIdAuthExtendedParams arg1) {
            return CallStatic<bool>("containScopes", arg0, arg1);
        }
        public static bool containScopes(AuthHuaweiId arg0, List<Scope> arg1) {
            return CallStatic<bool>("containScopes", arg0, arg1);
        }
        public static void addAuthScopes(Activity arg0, int arg1, HuaweiIdAuthExtendedParams arg2) {
            CallStatic("addAuthScopes", arg0, arg1, arg2);
        }
        public static void addAuthScopes(Fragment arg0, int arg1, HuaweiIdAuthExtendedParams arg2) {
            CallStatic("addAuthScopes", arg0, arg1, arg2);
        }
        public static void addAuthScopes(Activity arg0, int arg1, List<Scope> arg2) {
            CallStatic("addAuthScopes", arg0, arg1, arg2);
        }
        public static void addAuthScopes(Fragment arg0, int arg1, List<Scope> arg2) {
            CallStatic("addAuthScopes", arg0, arg1, arg2);
        }
    }
}