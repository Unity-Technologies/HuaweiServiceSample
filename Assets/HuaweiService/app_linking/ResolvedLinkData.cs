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
        public LinkType getLinkType() {
            return Call<LinkType>("getLinkType");
        }
        public string getInstallSource() {
            return Call<string>("getInstallSource");
        }
    
        public class LinkType_Data : IHmsBaseClass{
            public string name => "com.huawei.agconnect.applinking.ResolvedLinkData$LinkType";
        }
        public class LinkType :HmsClass<LinkType_Data>
        {
            public static LinkType AppLinking => HmsUtil.GetStaticValue<LinkType>("AppLinking");
        
            public static LinkType UnifiedLinking => HmsUtil.GetStaticValue<LinkType>("UnifiedLinking");
        
            public LinkType (): base() { }
        }
    }
}