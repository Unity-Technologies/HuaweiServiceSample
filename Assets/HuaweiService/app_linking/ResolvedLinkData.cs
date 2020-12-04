using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.AppLinking
{
    public class ResolvedLinkData_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.applinking.ResolvedLinkData";
    }
    public class ResolvedLinkData :HmsClass<ResolvedLinkData_Data>
    {
        public ResolvedLinkData (): base() { }
        public long getClickTimestamp() {
            return Call<long>("getClickTimestamp");
        }
        public Uri getDeepLink() {
            return Call<Uri>("getDeepLink");
        }
        public string getSocialTitle() {
            return Call<string>("getSocialTitle");
        }
        public string getSocialDescription() {
            return Call<string>("getSocialDescription");
        }
        public string getSocialImageUrl() {
            return Call<string>("getSocialImageUrl");
        }
        public string getCampaignName() {
            return Call<string>("getCampaignName");
        }
        public string getCampaignMedium() {
            return Call<string>("getCampaignMedium");
        }
        public string getCampaignSource() {
            return Call<string>("getCampaignSource");
        }
    }
}