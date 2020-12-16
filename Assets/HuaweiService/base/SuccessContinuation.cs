using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class SuccessContinuationData : IHmsBaseListener
    {
        public string name => "com.huawei.hmf.tasks.SuccessContinuation";
        public string buildName => "";
    }
    public class SuccessContinuation : HmsListener<SuccessContinuationData>
    {
    
        public virtual Task then(AndroidJavaObject arg0) {
            return Call<Task>("then", arg0);
        }
    }
}