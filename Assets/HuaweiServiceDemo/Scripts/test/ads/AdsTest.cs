using UnityEngine;
using HuaweiService;
using HuaweiService.ads;

namespace HuaweiServiceDemo
{
    public class AdsTest:Test<AdsTest>
    {
        public override void RegisterEvent(TestEvent registerEvent){
            registerEvent("load image ads " + Screen.width,LoadImageAds);
            registerEvent("load video ads " + Screen.height,LoadVideoAds);
            registerEvent("load reward ads",LoadRewardAds);
            registerEvent("set consent personal",() => SetConsentStatus(true));
            registerEvent("set consent non personal", ()=> SetConsentStatus(false));
            registerEvent("consent",checkConsentStatus);
            registerEvent("set RequestOptions NonPersonalizedAd",setRequestOptionsNonPersonalizedAd);
            registerEvent("setRequestOptionsConsent",setRequestOptionsConsent);
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
            ad.setMobileDataAlertSwitch(false);
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
            consentInfo.addTestDeviceId("1");
            string id = consentInfo.getTestDeviceId();
            consentInfo.setDebugNeedConsent(DebugNeedConsent.DEBUG_NEED_CONSENT);
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
        public void setRequestOptionsConsent()
        {
            RequestOptions requestOptions = HwAds.getRequestOptions();
            requestOptions.toBuilder().setConsent("tcfString").build();
            
            TestTip.Inst.ShowText("RequestOptions setConsent:set consent");
        }
    }
}