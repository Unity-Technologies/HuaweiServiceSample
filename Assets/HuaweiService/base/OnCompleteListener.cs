using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class OnCompleteListenerData : IHmsBaseListener
    {
        public string name => "com.huawei.hmf.tasks.OnCompleteListener";
        public string buildName => "";
    }
    public class OnCompleteListener : HmsListener<OnCompleteListenerData>
    {
    
        public virtual void onComplete(Task arg0) {
            Call("onComplete", arg0);
        }
    
        public void onComplete(AndroidJavaObject arg0){
            onComplete(HmsUtil.GetHmsBase<Task>(arg0));
        }
    }
}