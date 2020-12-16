using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.ads
{
    public class RequestOptions_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.ads.RequestOptions";
    }
    public class RequestOptions :HmsClass<RequestOptions_Data>
    {
        public RequestOptions (): base() { }
        public string getAdContentClassification() {
            return Call<string>("getAdContentClassification");
        }
        public string getAppLang() {
            return Call<string>("getAppLang");
        }
        public string getAppCountry() {
            return Call<string>("getAppCountry");
        }
        public Integer getTagForChildProtection() {
            return Call<Integer>("getTagForChildProtection");
        }
        public Integer getTagForUnderAgeOfPromise() {
            return Call<Integer>("getTagForUnderAgeOfPromise");
        }
        public Builder toBuilder() {
            return Call<Builder>("toBuilder");
        }
        public Integer getNonPersonalizedAd() {
            return Call<Integer>("getNonPersonalizedAd");
        }
    
        public class Builder_Data : IHmsBaseClass{
            public string name => "com.huawei.hms.ads.RequestOptions$Builder";
        }
        public class Builder :HmsClass<Builder_Data>
        {
            public Builder (): base() { }
            public RequestOptions build() {
                return Call<RequestOptions>("build");
            }
            public Builder setAdContentClassification(string arg0) {
                return Call<Builder>("setAdContentClassification", arg0);
            }
            public Builder setTagForChildProtection(Integer arg0) {
                return Call<Builder>("setTagForChildProtection", arg0);
            }
            public Builder setTagForUnderAgeOfPromise(Integer arg0) {
                return Call<Builder>("setTagForUnderAgeOfPromise", arg0);
            }
            public Builder setNonPersonalizedAd(Integer arg0) {
                return Call<Builder>("setNonPersonalizedAd", arg0);
            }
            public Builder setAppLang(string arg0) {
                return Call<Builder>("setAppLang", arg0);
            }
            public Builder setAppCountry(string arg0) {
                return Call<Builder>("setAppCountry", arg0);
            }
        }
    }
}