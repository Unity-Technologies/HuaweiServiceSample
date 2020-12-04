using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class OnFailureListenerData : IHmsBaseListener
    {
        public string name => "com.huawei.hmf.tasks.OnFailureListener";
        public string buildName => "";
    }
    public class OnFailureListener : HmsListener<OnFailureListenerData>
    {
    
        public virtual void onFailure(Exception arg0) {
            Call("onFailure", arg0);
        }
    
        public void onFailure(AndroidJavaObject arg0){
            onFailure(HmsUtil.GetHmsBase<Exception>(arg0));
        }
    }
}