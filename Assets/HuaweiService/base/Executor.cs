using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class Executor_Data : IHmsBaseClass{
        public string name => "java.util.concurrent.Executor";
    }
    public class Executor :HmsClass<Executor_Data>
    {
        public Executor (): base() { }
    }
}