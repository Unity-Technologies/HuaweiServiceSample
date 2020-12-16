using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class ExecuteResultData : IHmsBaseListener
    {
        public string name => "com.huawei.hmf.tasks.ExecuteResult";
        public string buildName => "";
    }
    public class ExecuteResult : HmsListener<ExecuteResultData>
    {
    
        public virtual void onComplete(Task arg0) {
            Call("onComplete", arg0);
        }
    
        public void onComplete(AndroidJavaObject arg0){
            onComplete(HmsUtil.GetHmsBase<Task>(arg0));
        }
    
        public virtual void cancel() {
            Call("cancel");
        }
    }
}