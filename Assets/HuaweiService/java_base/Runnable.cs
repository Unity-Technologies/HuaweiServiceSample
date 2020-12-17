using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class RunnableData : IHmsBaseListener
    {
        public string name => "java.lang.Runnable";
        public string buildName => "";
    }
    public class Runnable : HmsListener<RunnableData>
    {
    
        public virtual void run() {
            Call("run");
        }
    }
}