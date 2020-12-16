using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class ContinuationData : IHmsBaseListener
    {
        public string name => "com.huawei.hmf.tasks.Continuation";
        public string buildName => "";
    }
    public class Continuation : HmsListener<ContinuationData>
    {
    
        public virtual AndroidJavaObject then(Task arg0) {
            return Call<AndroidJavaObject>("then", arg0);
        }
    
        public AndroidJavaObject then(AndroidJavaObject arg0){
            return then(HmsUtil.GetHmsBase<Task>(arg0));
        }
    }
}