using UnityEngine;
using System.Collections.Generic;
using HuaweiService.Auth;

namespace HuaweiService.Account
{
    public class AuthHuaweiId_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.support.hwid.result.AuthHuaweiId";
    }
    public class AuthHuaweiId :HmsClass<AuthHuaweiId_Data>
    {
        public static Parcelable.Creator CREATOR => HmsUtil.GetStaticValue<Parcelable.Creator>("CREATOR");
    
        public AuthHuaweiId (): base() { }
        public static AuthHuaweiId createDefault() {
            return CallStatic<AuthHuaweiId>("createDefault");
        }
        public static AuthHuaweiId build(string arg0, string arg1, string arg2, string arg3, string arg4, string arg5, int arg6, int arg7, Set<Scope>  arg8, string arg9, string arg10, string arg11) {
            return CallStatic<AuthHuaweiId>("build", arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
        }
        public string getAccessToken() {
            return Call<string>("getAccessToken");
        }
        public Auth.Account getHuaweiAccount(Context arg0) {
            return Call<Auth.Account>("getHuaweiAccount", arg0);
        }
        public string getDisplayName() {
            return Call<string>("getDisplayName");
        }
        public string getEmail() {
            return Call<string>("getEmail");
        }
        public string getFamilyName() {
            return Call<string>("getFamilyName");
        }
        public string getGivenName() {
            return Call<string>("getGivenName");
        }
        public Set<Scope> getAuthorizedScopes() {
            return Call<Set<Scope> >("getAuthorizedScopes");
        }
        public string getIdToken() {
            return Call<string>("getIdToken");
        }
        public Uri getAvatarUri() {
            return Call<Uri>("getAvatarUri");
        }
        public string getAuthorizationCode() {
            return Call<string>("getAuthorizationCode");
        }
        public string getUnionId() {
            return Call<string>("getUnionId");
        }
        public string getOpenId() {
            return Call<string>("getOpenId");
        }
    }
}