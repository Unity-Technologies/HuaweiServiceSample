using System;
using HuaweiServiceDemo;
using UnityEngine;

namespace HuaweiService.Account
{
    public class AccountCallback_Data : IHmsBaseClass{
        public string name => "com.hms.hms_account_activity.AccountCallback";
    }

    public delegate void OnActivityResultCallback(int requestCode, int resultCode);
    public class AccountCallback :AndroidJavaProxy
    {
        private OnActivityResultCallback onActivityResultCallback;
        public AccountCallback (): base("com.hms.hms_account_activity.AccountCallback") { }
        public void setCallback(OnActivityResultCallback callback)
        {
            TestTip.Inst.ShowText($"AccountCallback.setCallback");
            onActivityResultCallback = callback;
        }
        public void onActivityResult(int requestCode, int resultCode)
        {
            TestTip.Inst.ShowText($"AccountCallback onActivityResult");
            onActivityResultCallback(requestCode,resultCode);
        }
    }
}