using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.Account
{
    public class HuaweiIdAuthExtendedParams_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.support.hwid.request.HuaweiIdAuthExtendedParams";
    }
    public class HuaweiIdAuthExtendedParams :HmsClass<HuaweiIdAuthExtendedParams_Data>
    {
        public HuaweiIdAuthExtendedParams (): base() { }
    }
}