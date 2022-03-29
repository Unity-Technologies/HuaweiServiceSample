using HuaweiService;
using UnityEngine;
namespace HuaweiService.IAP
{
    public class IapCallback_Data : IHmsBaseClass
    {
        public string name => "com.unity.hms.iap.IIapCallback";
    }
    public delegate void OnActivityResultCallback(int requestCode, int resultCode, AndroidJavaObject obj);

    public class IapCallback : AndroidJavaProxy
    {
        private OnActivityResultCallback onActivityResultCallback;
        public IapCallback() : base("com.unity.hms.iap.IIapCallback") { }
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