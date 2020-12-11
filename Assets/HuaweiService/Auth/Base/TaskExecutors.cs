using UnityEngine;
using System.Collections.Generic;
using HuaweiService;

namespace HuaweiService.Auth
{
    public class TaskExecutors_Data : IHmsBaseClass{
        public string name => "com.huawei.hmf.tasks.TaskExecutors";
    }
    public class TaskExecutors :HmsClass<TaskExecutors_Data>
    {
        public TaskExecutors (): base() { }
        public static Executor immediate() {
            return CallStatic<Executor>("immediate");
        }
        public static Executor uiThread() {
            return CallStatic<Executor>("uiThread");
        }
    }
}