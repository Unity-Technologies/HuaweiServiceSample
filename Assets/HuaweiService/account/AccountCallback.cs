using UnityEngine;

namespace HuaweiService.Account
{
    public class AccountCallback_Data : IHmsBaseClass
    {
        public string name => "com.unity.hms.account.IAccountCallback";
    }

    public delegate void OnActivityResultCallback(int requestCode, int resultCode, AndroidJavaObject obj);
    public class AccountCallback : AndroidJavaProxy
    {
        private OnActivityResultCallback onActivityResultCallback;
        public AccountCallback() : base("com.unity.hms.account.IAccountCallback") { }
        public void setCallback(OnActivityResultCallback callback)
        {
            onActivityResultCallback = callback;
        }
        public void onActivityResult(int requestCode, int resultCode, AndroidJavaObject obj)
        {
            onActivityResultCallback(requestCode, resultCode, obj);
        }
    }
}