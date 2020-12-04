using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class OnSuccessListenerData : IHmsBaseListener
    {
        public string name => "com.huawei.hmf.tasks.OnSuccessListener";
        public string buildName => "";
    }
    public class OnSuccessListener : HmsListener<OnSuccessListenerData>
    {
    
        public virtual void onSuccess(AndroidJavaObject arg0) {
            Call("onSuccess", arg0);
        }
    }
}