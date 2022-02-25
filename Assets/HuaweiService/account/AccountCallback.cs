using System;
using HuaweiServiceDemo;
using UnityEngine;

namespace HuaweiService.Account
{
    public class AccountCallback_Data : IHmsBaseClass{
        public string name => "com.hms.hms_account_activity.AccountCallback";
    }

    public delegate void OnActivityResultCallback(int requestCode, int resultCode,AndroidJavaObject obj);
    public class AccountCallback :AndroidJavaProxy
    {
        private OnActivityResultCallback onActivityResultCallback;
        public AccountCallback (): base("com.hms.hms_account_activity.AccountCallback") { }
        public void setCallback(OnActivityResultCallback callback)
        {
            onActivityResultCallback = callback;
        }
        public void onActivityResult(int requestCode, int resultCode,AndroidJavaObject obj)
        {
            onActivityResultCallback(requestCode,resultCode,obj);
        }
    }
}