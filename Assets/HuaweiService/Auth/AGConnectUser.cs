using System;
using UnityEngine;
using System.Collections.Generic;
using HuaweiService;

namespace HuaweiService.Auth
{
    public class AGConnectUser_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.auth.AGConnectUser";
    }
    public class AGConnectUser :HmsClass<AGConnectUser_Data>
    {
        public AGConnectUser (): base() { }
        public bool isAnonymous() {
            return Call<bool>("isAnonymous");
        }
        public string getUid() {
            return Call<string>("getUid");
        }
        public string getEmail() {
            return Call<string>("getEmail");
        }
        public string getPhone() {
            return Call<string>("getPhone");
        }
        public string getDisplayName() {
            return Call<string>("getDisplayName");
        }
        public string getPhotoUrl() {
            return Call<string>("getPhotoUrl");
        }
        public string getProviderId() {
            return Call<string>("getProviderId");
        }

        public Task getToken(bool var1)
        {
            return Call<Task>("getToken", var1);
        }
        
        public List getProviderInfo() {
            return Call<List>("getProviderInfo");
        }
        public Task link(AGConnectAuthCredential arg0) {
            return Call<Task>("link", arg0);
        }
        public Task unlink(int arg0) {
            return Call<Task>("unlink", arg0);
        }
        public Task updateProfile(ProfileRequest arg0) {
            return Call<Task>("updateProfile", arg0);
        }
        public Task updateEmail(string arg0, string arg1) {
            return Call<Task>("updateEmail", arg0, arg1);
        }
        public Task updateEmail(string arg0, string arg1, Locale arg2) {
            return Call<Task>("updateEmail", arg0, arg1, arg2);
        }
        public Task updatePhone(string arg0, string arg1, string arg2) {
            return Call<Task>("updatePhone", arg0, arg1, arg2);
        }
        public Task updatePhone(string arg0, string arg1, string arg2, Locale arg3) {
            return Call<Task>("updatePhone", arg0, arg1, arg2, arg3);
        }
        public Task updatePassword(string arg0, string arg1, int arg2) {
            return Call<Task>("updatePassword", arg0, arg1, arg2);
        }
        public int getEmailVerified() {
            return Call<int>("getEmailVerified");
        }
        public int getPasswordSetted() {
            return Call<int>("getPasswordSetted");
        }
        public Task getUserExtra() {
            return Call<Task>("getUserExtra");
        }
    }
}