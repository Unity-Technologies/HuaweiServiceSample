using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.CloudStorage
{
    public class OnProgressListenerData : IHmsBaseListener
    {
        public string name => "com.huawei.agconnect.cloud.storage.core.OnProgressListener";
        public string buildName => "";
    }
    public class OnProgressListener : HmsListener<OnProgressListenerData>
    {
    
        public virtual void onProgress(AndroidJavaObject arg0) {
            Call("onProgress", arg0);
        }
    }
}