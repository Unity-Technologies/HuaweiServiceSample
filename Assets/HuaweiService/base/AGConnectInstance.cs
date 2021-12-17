using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class AGConnectInstance_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.AGConnectInstance";
    }
    public class AGConnectInstance :HmsClass<AGConnectInstance_Data>
    {
        public AGConnectInstance (): base() { }
    }
}