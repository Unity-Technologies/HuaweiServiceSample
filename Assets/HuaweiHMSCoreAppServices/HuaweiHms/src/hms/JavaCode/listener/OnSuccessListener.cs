using UnityEngine;
using System.Collections.Generic;

namespace HuaweiHms
{
    public class OnSuccessListenerData : IHmsBaseListener
    {
        public string name => "com.huawei.hmf.tasks.OnSuccessListener";
        public string buildName => "";
    }
    public class OnSuccessListener : HmsListener<OnSuccessListenerData>
    {
    
        public virtual void onSuccess(AndroidJavaObject arg0) { }
    }
    
    public class OnSuccessListener<T> : HmsListener<OnSuccessListenerData> where T:IHmsBase,new()
    {
    
        public virtual void onSuccess(T arg0) {}

        public void onSuccess(AndroidJavaObject arg0)
        {
            onSuccess(HmsUtil.GetHmsBase<T>(arg0));
        }
    }
}