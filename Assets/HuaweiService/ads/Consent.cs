using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.ads
{
    public class Consent_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.ads.consent.inter.Consent";
    }
    public class Consent :HmsClass<Consent_Data>
    {
        public Consent (): base() { }
        public static Consent getInstance(Context arg0) {
            return CallStatic<Consent>("getInstance", arg0);
        }
        public void setUnderAgeOfPromise(bool arg0) {
            Call("setUnderAgeOfPromise", arg0);
        }
        public void requestConsentUpdate(ConsentUpdateListener arg0) {
            Call("requestConsentUpdate", arg0);
        }
        public void setConsentStatus(ConsentStatus arg0) {
            Call("setConsentStatus", arg0);
        }
    }
}