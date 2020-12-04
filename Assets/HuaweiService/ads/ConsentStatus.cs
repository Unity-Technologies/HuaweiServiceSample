using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.ads
{
    public class ConsentStatus_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.ads.consent.constant.ConsentStatus";
    }
    public class ConsentStatus :HmsClass<ConsentStatus_Data>
    {
        public static ConsentStatus PERSONALIZED => HmsUtil.GetStaticValue<ConsentStatus>("PERSONALIZED");
    
        public static ConsentStatus NON_PERSONALIZED => HmsUtil.GetStaticValue<ConsentStatus>("NON_PERSONALIZED");
    
        public static ConsentStatus UNKNOWN => HmsUtil.GetStaticValue<ConsentStatus>("UNKNOWN");
    
        public ConsentStatus (): base() { }
        public int getValue() {
            return Call<int>("getValue");
        }
        public static ConsentStatus forValue(int arg0) {
            return CallStatic<ConsentStatus>("forValue", arg0);
        }
    }
}