using UnityEngine;
using System.Collections.Generic;
using HuaweiService;

namespace HuaweiService.Auth
{
    public class Account_Data : IHmsBaseClass{
        public string name => "android.accounts.Account";
    }
    public class Account :HmsClass<Account_Data>
    {
        public Account (string arg0, string arg1): base(arg0, arg1) { }
        public Account (Parcel arg0): base(arg0) { }
        public Account (): base() { }
        public string toString() {
            return Call<string>("toString");
        }
        public int hashCode() {
            return Call<int>("hashCode");
        }
        public bool equals(AndroidJavaObject arg0) {
            return Call<bool>("equals", arg0);
        }
    }
}