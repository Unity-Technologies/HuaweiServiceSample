using UnityEngine;
using System.Collections.Generic;
using HuaweiService;

namespace HuaweiService.Auth
{
    public class AuthHuaweiId_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.support.hwid.result.AuthHuaweiId";
    }
    public class AuthHuaweiId :HmsClass<AuthHuaweiId_Data>
    {
        public AuthHuaweiId (): base() { }
        public static AuthHuaweiId createDefault() {
            return CallStatic<AuthHuaweiId>("createDefault");
        }
        public static AuthHuaweiId build(string arg0, string arg1, string arg2, string arg3, string arg4, string arg5, int arg6, int arg7, Set<Scope> arg8, string arg9, string arg10, string arg11) {
            return CallStatic<AuthHuaweiId>("build", arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
        }
        public static AuthHuaweiId fromJson(string arg0) {
            return CallStatic<AuthHuaweiId>("fromJson", arg0);
        }
        public static AuthHuaweiId fromJson(JSONObject arg0) {
            return CallStatic<AuthHuaweiId>("fromJson", arg0);
        }
        public bool equals(AndroidJavaObject arg0) {
            return Call<bool>("equals", arg0);
        }
        public AuthHuaweiId requestExtraScopes(List<Scope> arg0) {
            return Call<AuthHuaweiId>("requestExtraScopes", arg0);
        }
        public Account getHuaweiAccount() {
            return Call<Account>("getHuaweiAccount");
        }
        public int getAgeRangeFlag() {
            return Call<int>("getAgeRangeFlag");
        }
        public int hashCode() {
            return Call<int>("hashCode");
        }
    }
}