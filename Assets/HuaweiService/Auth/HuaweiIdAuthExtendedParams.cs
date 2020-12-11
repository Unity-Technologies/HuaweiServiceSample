using UnityEngine;
using System.Collections.Generic;
using HuaweiService;

namespace HuaweiService.Auth
{
    public class HuaweiIdAuthExtendedParams_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.support.hwid.request.HuaweiIdAuthExtendedParams";
    }
    public class HuaweiIdAuthExtendedParams :HmsClass<HuaweiIdAuthExtendedParams_Data>
    {
        public HuaweiIdAuthExtendedParams (): base() { }
    }
}