using UnityEngine;
using System.Collections.Generic;
using HuaweiService.Auth;

namespace HuaweiService.Account
{
    public class AuthAccount_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.support.account.result.AuthAccount";
    }
    public class AuthAccount :HmsClass<AuthAccount_Data>
    {
        public static Parcelable.Creator CREATOR => HmsUtil.GetStaticValue<Parcelable.Creator>("CREATOR");
    
        public AuthAccount (): base() { }
        public static AuthAccount createDefault() {
            return CallStatic<AuthAccount>("createDefault");
        }
        public static AuthAccount build(string arg0, string arg1, string arg2, string arg3, string arg4, string arg5, int arg6, int arg7, Set<Scope> arg8, string arg9, string arg10, string arg11, int arg12) {
            return CallStatic<AuthAccount>("build", arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
        }
        public string getAccessToken() {
            return Call<string>("getAccessToken");
        }
        public Auth.Account getAccount(Context arg0) {
            return Call<Auth.Account>("getAccount", arg0);
        }
        public string getServiceCountryCode() {
            return Call<string>("getServiceCountryCode");
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
            return Call<Set<Scope>>("getAuthorizedScopes");
        }
        public string getIdToken() {
            return Call<string>("getIdToken");
        }
        public string getUid() {
            return Call<string>("getUid");
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
        public int getAccountFlag() {
            return Call<int>("getAccountFlag");
        }
        public int getCarrierId() {
            return Call<int>("getCarrierId");
        }
    }
}