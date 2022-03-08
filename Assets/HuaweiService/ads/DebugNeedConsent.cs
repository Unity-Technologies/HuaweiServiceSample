using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.ads
{
    public class DebugNeedConsent_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.ads.consent.constant.DebugNeedConsent";
    }
    public class DebugNeedConsent :HmsClass<DebugNeedConsent_Data>
    {
        public static DebugNeedConsent DEBUG_DISABLED => HmsUtil.GetStaticValue<DebugNeedConsent>("DEBUG_DISABLED");
    
        public static DebugNeedConsent DEBUG_NEED_CONSENT => HmsUtil.GetStaticValue<DebugNeedConsent>("DEBUG_NEED_CONSENT");
    
        public static DebugNeedConsent DEBUG_NOT_NEED_CONSENT => HmsUtil.GetStaticValue<DebugNeedConsent>("DEBUG_NOT_NEED_CONSENT");
    
        public DebugNeedConsent (): base() { }
    }
}