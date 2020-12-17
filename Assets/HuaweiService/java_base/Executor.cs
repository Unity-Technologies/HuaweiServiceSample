using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class ExecutorData : IHmsBaseListener
    {
        public string name => "java.util.concurrent.Executor";
        public string buildName => "";
    }
    public class Executor : HmsListener<ExecutorData>
    {
    
        public virtual void execute(Runnable arg0) {
            Call("execute", arg0);
        }
    
        public void execute(AndroidJavaObject arg0){
            execute(HmsUtil.GetHmsBase<Runnable>(arg0));
        }
    }
}