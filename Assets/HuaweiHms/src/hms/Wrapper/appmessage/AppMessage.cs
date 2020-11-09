using UnityEngine;
using System.Collections.Generic;

namespace HuaweiHms
{
    public class AppMessage_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.appmessaging.model.AppMessage";
    }
    public class AppMessage :HmsClass<AppMessage_Data>
    {
        public AppMessage (): base() { }
    }
}