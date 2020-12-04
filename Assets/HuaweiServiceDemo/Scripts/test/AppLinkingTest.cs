using System.Security.Cryptography;
using HuaweiService;
using HuaweiService.AppLinking;
using UnityEngine;

namespace HuaweiServiceDemo
{
    public class AppLinkingTest : Test<AppLinkingTest>
    {
        private const string URI_PREFIX = "https://unity.drcn.agconnect.link";
        private const string TITLE = "Unity test app";
        private const string DESCRIPTION = "This is description.";
        private const string IMAGE_URI = "https://unity.com/sites/default/files/styles/16_9_l_scale_width/public/2019-11/Unity-TheHeretic-hero-dark.jpg";
        private const string DEEP_LINK = "https://unity.cn/detail?id=123";
        
        public override void RegisterEvent(TestEvent registerEvent)
        {
            registerEvent("create app link AppInfo", () => CreateAppLinking(AppLinking.LinkingPreviewType.AppInfo));
            registerEvent("create app link SocialInfo", () => CreateAppLinking(AppLinking.LinkingPreviewType.SocialInfo));
            registerEvent("create app link AppGallery", () => CreateAppLinking(openType: AppLinking.AndroidLinkInfo.AndroidOpenType.AppGallery));
            registerEvent("create app link LocalMarket", () => CreateAppLinking(openType: AppLinking.AndroidLinkInfo.AndroidOpenType.LocalMarket));
            registerEvent("create app link CustomUrl", () => CreateAppLinking(openType: AppLinking.AndroidLinkInfo.AndroidOpenType.CustomUrl));
            registerEvent("create app short link SHORT", () => CreateShortAppLinking(ShortAppLinking.LENGTH.SHORT));
            registerEvent("create app short link LONG", () => CreateShortAppLinking(ShortAppLinking.LENGTH.LONG));
            registerEvent("get resolve data", GetResulveData);
            registerEvent("open Link", OpenLink);
        }

        public AppLinking.Builder createBuilder(
            AppLinking.LinkingPreviewType previewType = null,
            AppLinking.AndroidLinkInfo.AndroidOpenType openType = null
            )
        {
            previewType = previewType ?? AppLinking.LinkingPreviewType.AppInfo;
            openType = openType ?? AppLinking.AndroidLinkInfo.AndroidOpenType.CustomUrl;
            return AppLinking.newBuilder()
                .setPreviewType(previewType)
                .setUriPrefix(URI_PREFIX)
                .setDeepLink(Uri.parse(DEEP_LINK))
                .setAndroidLinkInfo(
                    AppLinking.AndroidLinkInfo.newBuilder()
                        .setFallbackUrl(IMAGE_URI)
                        .setOpenType(openType)
                        .build())
                .setSocialCardInfo(
                    AppLinking.SocialCardInfo.newBuilder().
                        setTitle(TITLE)
                        .setImageUrl(IMAGE_URI)
                        .setDescription(DESCRIPTION)
                        .build())
                .setCampaignInfo(
                    AppLinking.CampaignInfo.newBuilder()
                        .setName("name")
                        .setSource("AGC")
                        .setMedium("App")
                        .build())
                .setExpireMinute(2);
        }

        public void CreateAppLinking(
            AppLinking.LinkingPreviewType previewType = null,
            AppLinking.AndroidLinkInfo.AndroidOpenType openType = null)
        {
            AppLinking.Builder builder = createBuilder(previewType, openType);
            Uri applinkingUri = builder.buildAppLinking().getUri();
            var link = applinkingUri.toString();
            TestTip.Inst.ShowText($"App link: {link}");
            GUIUtility.systemCopyBuffer = link;
        }
        
        public void CreateShortAppLinking(ShortAppLinking.LENGTH length)
        {
            AppLinking.Builder builder = createBuilder();
            builder.buildShortAppLinking(length).addOnSuccessListener(new HmsSuccessListener<ShortAppLinking>((shortAppLinking) =>
            {
                string link = shortAppLinking.getShortUrl().toString();
                TestTip.Inst.ShowText("short link:" + link);
                GUIUtility.systemCopyBuffer = link;
            })).addOnFailureListener(new HmsFailureListener((Exception e)=>{
                TestTip.Inst.ShowText($"short link failed: {e.toString()}");
            }));
        }

        public void GetResulveData()
        {
            AGConnectAppLinking.getInstance().getAppLinking(new UnityPlayerActivity()).addOnSuccessListener(new HmsSuccessListener<ResolvedLinkData>((resolvedLinkData) =>
            {
                var link = resolvedLinkData.getDeepLink().toString();
                TestTip.Inst.ShowText("short link:" + link);
                GUIUtility.systemCopyBuffer = link;
                var time = resolvedLinkData.getClickTimestamp();
                TestTip.Inst.ShowText("Time stamp:" + time);
                var socialTitle = resolvedLinkData.getSocialTitle();
                TestTip.Inst.ShowText("socialTitle: " + socialTitle);
                var socialImageUrl = resolvedLinkData.getSocialImageUrl();
                TestTip.Inst.ShowText("socialImageUrl: " + socialImageUrl);
                var socialDescription = resolvedLinkData.getSocialDescription();
                TestTip.Inst.ShowText("socialDescription: " + socialDescription);
                var campaignName = resolvedLinkData.getCampaignName();
                TestTip.Inst.ShowText("campaignName: " + campaignName);
                var campaignMedium = resolvedLinkData.getCampaignMedium();
                TestTip.Inst.ShowText("campaignMedium: " + campaignMedium);
                var campaignSource = resolvedLinkData.getCampaignSource();
                TestTip.Inst.ShowText("campaignSource: " + campaignSource);
            })).addOnFailureListener(new HmsFailureListener((Exception e)=>{
                TestTip.Inst.ShowText($"short link failed: {e.toString()}");
            }));
        }

        public void OpenLink()
        {
            var activity = new UnityPlayerActivity();
            var intent = new Intent();
            TestTip.Inst.ShowText($"use text: {GUIUtility.systemCopyBuffer}");
            intent.setData(Uri.parse(GUIUtility.systemCopyBuffer));
            activity.startActivity(intent);
        }
    }
}