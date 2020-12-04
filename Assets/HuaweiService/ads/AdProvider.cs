using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.ads
{
    public class AdProvider_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.ads.consent.bean.AdProvider";
    }
    public class AdProvider :HmsClass<AdProvider_Data>
    {
        public AdProvider (): base() { }
        public string getId() {
            return Call<string>("getId");
        }
        public string getName() {
            return Call<string>("getName");
        }
        public string getPrivacyPolicyUrl() {
            return Call<string>("getPrivacyPolicyUrl");
        }
        public string getServiceArea() {
            return Call<string>("getServiceArea");
        }
    }
}