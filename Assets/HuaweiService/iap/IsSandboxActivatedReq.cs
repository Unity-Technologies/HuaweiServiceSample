using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.IAP
{
    public class IsSandboxActivatedReq_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.iap.entity.IsSandboxActivatedReq";
    }
    public class IsSandboxActivatedReq :HmsClass<IsSandboxActivatedReq_Data>
    {
        public IsSandboxActivatedReq (): base() { }
    }
}