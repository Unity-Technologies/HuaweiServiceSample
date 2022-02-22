using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.location
{
    public class LogConfig_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.location.LogConfig";
    }
    public class LogConfig :HmsClass<LogConfig_Data>
    {
        public LogConfig (string arg0, int arg1, int arg2, int arg3): base(arg0, arg1, arg2, arg3) { }
        public LogConfig (string arg0): base(arg0) { }
        public LogConfig (): base() { }
        public void setLogPath(string arg0) {
            Call("setLogPath", arg0);
        }
    }
}