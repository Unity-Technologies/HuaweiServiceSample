using UnityEngine;
using System.Collections.Generic;
using HuaweiService.Auth;

namespace HuaweiService.Account
{
    public class AccountIcon_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.support.account.result.AccountIcon";
    }
    public class AccountIcon :HmsClass<AccountIcon_Data>
    {
        public static Parcelable.Creator CREATOR => HmsUtil.GetStaticValue<Parcelable.Creator>("CREATOR");
    
        public AccountIcon (string arg0, Bitmap arg1): base(arg0, arg1) { }
        public AccountIcon (): base() { }
        public Bitmap getIcon() {
            return Call<Bitmap>("getIcon");
        }
        public string getDescription() {
            return Call<string>("getDescription");
        }
    }

    public class Bitmap
    {
    }
}