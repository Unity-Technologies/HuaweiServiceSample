using System.Security.Cryptography;
using HuaweiHms;
using UnityEngine;

namespace HuaweiHmsDemo
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
            registerEvent("create app link", CreateAppLinking);
            registerEvent("create app short link", CreateShortAppLinking);
            registerEvent("get resolve data", GetResulveData);
            registerEvent("open Link", OpenLink);
        }

        public AppLinking.Builder createBuilder()
        {
            return AppLinking.newBuilder()
                .setPreviewType(AppLinking.LinkingPreviewType.SocialInfo)
                .setUriPrefix(URI_PREFIX)
                .setDeepLink(Uri.parse(DEEP_LINK))
                .setAndroidLinkInfo(
                    AppLinking.AndroidLinkInfo.newBuilder()
                        .setFallbackUrl(IMAGE_URI)
                        .setOpenType(AppLinking.AndroidLinkInfo.AndroidOpenType.CustomUrl)
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

        public void CreateAppLinking()
        {
            AppLinking.Builder builder = createBuilder();
            Uri applinkingUri = builder.buildAppLinking().getUri();
            var link = applinkingUri.toString();
            TestTip.Inst.ShowText($"App link: {link}");
            GUIUtility.systemCopyBuffer = link;
        }
        
        public void CreateShortAppLinking()
        {
            AppLinking.Builder builder = createBuilder();
            TestTip.Inst.ShowText("use ShortAppLinking.LENGTH.LONG");
            builder.buildShortAppLinking(ShortAppLinking.LENGTH.LONG).addOnSuccessListener(new HmsSuccessListener<ShortAppLinking>((shortAppLinking) =>
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
            AGConnectAppLinking.getInstance().getAppLinking(new Activity()).addOnSuccessListener(new HmsSuccessListener<ResolvedLinkData>((resolvedLinkData) =>
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
            var activity = new Activity();
            var intent = new Intent();
            TestTip.Inst.ShowText($"use text: {GUIUtility.systemCopyBuffer}");
            intent.setData(Uri.parse(GUIUtility.systemCopyBuffer));
            activity.startActivity(intent);
        }
    }
}