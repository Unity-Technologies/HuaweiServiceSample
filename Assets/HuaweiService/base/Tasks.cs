using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class Tasks_Data : IHmsBaseClass{
        public string name => "com.huawei.hmf.tasks.Tasks";
    }
    public class Tasks :HmsClass<Tasks_Data>
    {
        public Tasks (): base() { }
        public static AndroidJavaObject await(Task arg0, long arg1, TimeUnit arg2) {
            return CallStatic<AndroidJavaObject>("await", arg0, arg1, arg2);
        }
        public static AndroidJavaObject await(Task arg0) {
            return CallStatic<AndroidJavaObject>("await", arg0);
        }
    }
}