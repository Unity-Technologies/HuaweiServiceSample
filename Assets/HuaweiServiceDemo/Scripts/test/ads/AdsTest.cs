using UnityEngine;
using HuaweiService;
using HuaweiService.ads;
using UnityEngine.Diagnostics;

namespace HuaweiServiceDemo
{
    public class AdsTest:Test<AdsTest>
    {
        public override void RegisterEvent(TestEvent registerEvent){
            registerEvent("test policy ",TestPolicy);
            registerEvent("load image ads " + Screen.width,LoadImageAds);
            registerEvent("load video ads " + Screen.height,LoadVideoAds);
            registerEvent("load reward ads",LoadRewardAds);
            registerEvent("set consent personal",() => SetConsentStatus(true));
            registerEvent("set consent non personal", ()=> SetConsentStatus(false));
            registerEvent("consent",checkConsentStatus);
            registerEvent("set RequestOptions NonPersonalizedAd",setRequestOptionsNonPersonalizedAd);
        }

        public void TestPolicy()
        {
            var instance = AGConnectInstance.getInstance();
            TestTip.Inst.ShowText($"instance");
            var option = instance.getOptions();
            TestTip.Inst.ShowText($"option");
            var policy = option.getRoutePolicy();
            TestTip.Inst.ShowText($"policy {policy.getRouteName()}");

            TestTip.Inst.ShowText($"{AGCRoutePolicy.CHINA.getRouteName()}");
            TestTip.Inst.ShowText($"{AGCRoutePolicy.RUSSIA.getRouteName()}");
        }

        public void LoadImageAds()
        {
            InterstitialAd ad = new InterstitialAd(new Context());
            ad.setAdId("teste9ih9j0rc3");
            ad.setAdListener(new MAdListener(ad));
            AdParam.Builder builder = new AdParam.Builder();
            AdParam adParam = builder.build();
            ad.loadAd(adParam);
        }
        public void LoadVideoAds()
        {
            InterstitialAd ad = new InterstitialAd(new Context());
            ad.setAdId("testb4znbuh3n2");
            ad.setAdListener(new MAdListener(ad));
            AdParam.Builder builder = new AdParam.Builder();
            ad.loadAd(builder.build());
        }
        public void LoadRewardAds()
        {
            RewardAd ad = new RewardAd(new Context(), "testx9dtjwj8hp");
            AdParam adParam = new AdParam.Builder().build();
            MRewardLoadListener rewardAdLoadListener = new MRewardLoadListener(ad);
            ad.loadAd(adParam, rewardAdLoadListener);
        }
        
        public void SetConsentStatus(bool personal)
        {
            Consent consentInfo = Consent.getInstance(new Context());
            var consentStatus = personal ? ConsentStatus.PERSONALIZED : ConsentStatus.NON_PERSONALIZED;
            consentInfo.setConsentStatus(consentStatus);
            Util.showToast($"set consent status as {consentStatus}");
        }
        
        public void checkConsentStatus()
        {
            Consent consentInfo = Consent.getInstance(new Context());
            consentInfo.requestConsentUpdate(new MConsentUpdateListener());
        }

        public void setRequestOptionsNonPersonalizedAd()
        {
            RequestOptions reqOptions =  HwAds.getRequestOptions()
                .toBuilder()
                .setNonPersonalizedAd( new Integer(NonPersonalizedAd.ALLOW_ALL) )
                .build();
            HwAds.setRequestOptions(reqOptions);
            
            TestTip.Inst.ShowText("RequestOptions NonPersonalizedAd:"+ HwAds.getRequestOptions().getNonPersonalizedAd());
        }
    }
}