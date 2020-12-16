using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.ads
{
    public class AdParam_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.ads.AdParam";
    }
    public class AdParam :HmsClass<AdParam_Data>
    {
        public AdParam (): base() { }
    
        public class ErrorCode
        {
            public const int INNER = 0;
            public const int INVALID_REQUEST = 1;
            public const int NETWORK_ERROR = 2;
            public const int NO_AD = 3;
            public const int AD_LOADING = 4;
            public const int LOW_API = 5;
            public const int BANNER_AD_EXPIRE = 6;
            public const int BANNER_AD_CANCEL = 7;
        }
    
        public class Builder_Data : IHmsBaseClass{
            public string name => "com.huawei.hms.ads.AdParam$Builder";
        }
        public class Builder :HmsClass<Builder_Data>
        {
            public Builder (): base() { }
            public AdParam build() {
                return Call<AdParam>("build");
            }
            public Builder setGender(int arg0) {
                return Call<Builder>("setGender", arg0);
            }
            public Builder setAdContentClassification(string arg0) {
                return Call<Builder>("setAdContentClassification", arg0);
            }
            public Builder setTagForUnderAgeOfPromise(Integer arg0) {
                return Call<Builder>("setTagForUnderAgeOfPromise", arg0);
            }
            public Builder setTagForChildProtection(Integer arg0) {
                return Call<Builder>("setTagForChildProtection", arg0);
            }
            public Builder setNonPersonalizedAd(Integer arg0) {
                return Call<Builder>("setNonPersonalizedAd", arg0);
            }
            public Builder setAppCountry(string arg0) {
                return Call<Builder>("setAppCountry", arg0);
            }
            public Builder setAppLang(string arg0) {
                return Call<Builder>("setAppLang", arg0);
            }
            public Builder setBelongCountryCode(string arg0) {
                return Call<Builder>("setBelongCountryCode", arg0);
            }
        }
    }
}