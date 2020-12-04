using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.AppLinking
{
    public class AppLinking_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.applinking.AppLinking";
    }
    public class AppLinking :HmsClass<AppLinking_Data>
    {
        public AppLinking (): base() { }
        public static Builder newBuilder() {
            return CallStatic<Builder>("newBuilder");
        }
        public Uri getUri() {
            return Call<Uri>("getUri");
        }
    
        public class CampaignInfo_Data : IHmsBaseClass{
            public string name => "com.huawei.agconnect.applinking.AppLinking$CampaignInfo";
        }
        public class CampaignInfo :HmsClass<CampaignInfo_Data>
        {
            public CampaignInfo (): base() { }
            public static Builder newBuilder() {
                return CallStatic<Builder>("newBuilder");
            }
        
            public class Builder_Data : IHmsBaseClass{
                public string name => "com.huawei.agconnect.applinking.AppLinking$CampaignInfo$Builder";
            }
            public class Builder :HmsClass<Builder_Data>
            {
                public Builder (): base() { }
                public Builder setName(string arg0) {
                    return Call<Builder>("setName", arg0);
                }
                public Builder setSource(string arg0) {
                    return Call<Builder>("setSource", arg0);
                }
                public Builder setMedium(string arg0) {
                    return Call<Builder>("setMedium", arg0);
                }
                public CampaignInfo build() {
                    return Call<CampaignInfo>("build");
                }
            }
        }
    
        public class AndroidLinkInfo_Data : IHmsBaseClass{
            public string name => "com.huawei.agconnect.applinking.AppLinking$AndroidLinkInfo";
        }
        public class AndroidLinkInfo :HmsClass<AndroidLinkInfo_Data>
        {
            public AndroidLinkInfo (): base() { }
            public static Builder newBuilder() {
                return CallStatic<Builder>("newBuilder");
            }
            public static Builder newBuilder(string arg0) {
                return CallStatic<Builder>("newBuilder", arg0);
            }
        
            public class AndroidOpenType_Data : IHmsBaseClass{
                public string name => "com.huawei.agconnect.applinking.AppLinking$AndroidLinkInfo$AndroidOpenType";
            }
            public class AndroidOpenType :HmsClass<AndroidOpenType_Data>
            {
                public static AndroidOpenType AppGallery => HmsUtil.GetStaticValue<AndroidOpenType>("AppGallery");
            
                public static AndroidOpenType LocalMarket => HmsUtil.GetStaticValue<AndroidOpenType>("LocalMarket");
            
                public static AndroidOpenType CustomUrl => HmsUtil.GetStaticValue<AndroidOpenType>("CustomUrl");
            
                public AndroidOpenType (): base() { }
            }
        
            public class Builder_Data : IHmsBaseClass{
                public string name => "com.huawei.agconnect.applinking.AppLinking$AndroidLinkInfo$Builder";
            }
            public class Builder :HmsClass<Builder_Data>
            {
                public Builder (): base() { }
                public Builder (string arg0): base(arg0) { }
                public AndroidLinkInfo build() {
                    return Call<AndroidLinkInfo>("build");
                }
                public Builder setAndroidDeepLink(string arg0) {
                    return Call<Builder>("setAndroidDeepLink", arg0);
                }
                public Builder setOpenType(AndroidOpenType arg0) {
                    return Call<Builder>("setOpenType", arg0);
                }
                public Builder setFallbackUrl(string arg0) {
                    return Call<Builder>("setFallbackUrl", arg0);
                }
            }
        }
    
        public class SocialCardInfo_Data : IHmsBaseClass{
            public string name => "com.huawei.agconnect.applinking.AppLinking$SocialCardInfo";
        }
        public class SocialCardInfo :HmsClass<SocialCardInfo_Data>
        {
            public SocialCardInfo (): base() { }
            public static Builder newBuilder() {
                return CallStatic<Builder>("newBuilder");
            }
        
            public class Builder_Data : IHmsBaseClass{
                public string name => "com.huawei.agconnect.applinking.AppLinking$SocialCardInfo$Builder";
            }
            public class Builder :HmsClass<Builder_Data>
            {
                public Builder (): base() { }
                public Builder setTitle(string arg0) {
                    return Call<Builder>("setTitle", arg0);
                }
                public Builder setImageUrl(string arg0) {
                    return Call<Builder>("setImageUrl", arg0);
                }
                public Builder setDescription(string arg0) {
                    return Call<Builder>("setDescription", arg0);
                }
                public SocialCardInfo build() {
                    return Call<SocialCardInfo>("build");
                }
            }
        }
    
        public class Builder_Data : IHmsBaseClass{
            public string name => "com.huawei.agconnect.applinking.AppLinking$Builder";
        }
        public class Builder :HmsClass<Builder_Data>
        {
            public Builder (): base() { }
            public Builder setUriPrefix(string arg0) {
                return Call<Builder>("setUriPrefix", arg0);
            }
            public Builder setLongLink(Uri arg0) {
                return Call<Builder>("setLongLink", arg0);
            }
            public Builder setDeepLink(Uri arg0) {
                return Call<Builder>("setDeepLink", arg0);
            }
            public Builder setAndroidLinkInfo(AndroidLinkInfo arg0) {
                return Call<Builder>("setAndroidLinkInfo", arg0);
            }
            public Builder setSocialCardInfo(SocialCardInfo arg0) {
                return Call<Builder>("setSocialCardInfo", arg0);
            }
            public AppLinking buildAppLinking() {
                return Call<AppLinking>("buildAppLinking");
            }
            public Builder setCampaignInfo(CampaignInfo arg0) {
                return Call<Builder>("setCampaignInfo", arg0);
            }
            public Task buildShortAppLinking(ShortAppLinking.LENGTH arg0) {
                return Call<Task>("buildShortAppLinking", arg0);
            }
            public Task buildShortAppLinking() {
                return Call<Task>("buildShortAppLinking");
            }
            public Builder setExpireMinute(long arg0) {
                return Call<Builder>("setExpireMinute", arg0);
            }
            public Builder setPreviewType(LinkingPreviewType arg0) {
                return Call<Builder>("setPreviewType", arg0);
            }
        }
    
        public class LinkingPreviewType_Data : IHmsBaseClass{
            public string name => "com.huawei.agconnect.applinking.AppLinking$LinkingPreviewType";
        }
        public class LinkingPreviewType :HmsClass<LinkingPreviewType_Data>
        {
            public static LinkingPreviewType AppInfo => HmsUtil.GetStaticValue<LinkingPreviewType>("AppInfo");
        
            public static LinkingPreviewType SocialInfo => HmsUtil.GetStaticValue<LinkingPreviewType>("SocialInfo");
        
            public LinkingPreviewType (): base() { }
        }
    }
}