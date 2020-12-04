using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.ads
{
    public class RewardVerifyConfig_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.ads.reward.RewardVerifyConfig";
    }
    public class RewardVerifyConfig :HmsClass<RewardVerifyConfig_Data>
    {
        public RewardVerifyConfig (): base() { }
        public string getData() {
            return Call<string>("getData");
        }
        public string getUserId() {
            return Call<string>("getUserId");
        }
    
        public class Builder_Data : IHmsBaseClass{
            public string name => "com.huawei.hms.ads.reward.RewardVerifyConfig$Builder";
        }
        public class Builder :HmsClass<Builder_Data>
        {
            public Builder (): base() { }
            public RewardVerifyConfig build() {
                return Call<RewardVerifyConfig>("build");
            }
            public Builder setData(string arg0) {
                return Call<Builder>("setData", arg0);
            }
            public Builder setUserId(string arg0) {
                return Call<Builder>("setUserId", arg0);
            }
        }
    }
}