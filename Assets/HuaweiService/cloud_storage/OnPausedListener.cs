using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.CloudStorage
{
    public class OnPausedListenerData : IHmsBaseListener
    {
        public string name => "com.huawei.agconnect.cloud.storage.core.OnPausedListener";
        public string buildName => "";
    }
    public class OnPausedListener : HmsListener<OnPausedListenerData>
    {
    
        public virtual void onPaused(AndroidJavaObject arg0) {
            Call("onPaused", arg0);
        }
    }
}