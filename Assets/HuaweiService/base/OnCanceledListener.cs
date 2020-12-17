using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class OnCanceledListenerData : IHmsBaseListener
    {
        public string name => "com.huawei.hmf.tasks.OnCanceledListener";
        public string buildName => "";
    }
    public class OnCanceledListener : HmsListener<OnCanceledListenerData>
    {
    
        public virtual void onCanceled() {
            Call("onCanceled");
        }
    }
}