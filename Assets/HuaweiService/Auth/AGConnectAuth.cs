using System;
using UnityEngine;
using System.Collections.Generic;
using HuaweiService;

namespace HuaweiService.Auth
{
    public class AGConnectAuth_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.auth.AGConnectAuth";
    }
    public class AGConnectAuth :HmsClass<AGConnectAuth_Data>
    {
        public AGConnectAuth (): base() { }
        public static AGConnectAuth getInstance() {
            return CallStatic<AGConnectAuth>("getInstance");
        }
        public Task signIn(AGConnectAuthCredential arg0) {
            return Call<Task>("signIn", arg0);
        }
        public Task signInAnonymously() {
            return Call<Task>("signInAnonymously");
        }
        public void deleteUser() {
            Call("deleteUser");
        }
        public void signOut() {
            Call("signOut");
        }
        public AGConnectUser getCurrentUser() {
            return Call<AGConnectUser>("getCurrentUser");
        }
        public void addTokenListener(OnTokenListener arg0) {
            Call("addTokenListener", arg0);
        }
        public void removeTokenListener(OnTokenListener arg0) {
            Call("removeTokenListener", arg0);
        }
        public Task createUser(EmailUser arg0) {
            return Call<Task>("createUser", arg0);
        }
        public Task createUser(PhoneUser arg0) {
            return Call<Task>("createUser", arg0);
        }

        public Task resetPassword(string arg0, string arg1, string arg2)
        {
            return Call<Task>("resetPassword", arg0, arg1, arg2);
        }

        public Task resetPassword(string arg0, string arg1, string arg2, string arg3)
        {
            return Call<Task>("resetPassword", arg0, arg1, arg2, arg3);
        }
    }
}