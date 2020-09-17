using UnityEngine;
using HuaweiHms;

namespace HuaweiHmsDemo
{
    public class AdsTest:Test<AdsTest>
    {
        public override void RegisterEvent(TestEvent registerEvent){
            registerEvent("load image ads " + Screen.width,LoadImageAds);
            registerEvent("load video ads " + Screen.height,LoadVideoAds);
            registerEvent("load reward ads",LoadRewardAds);
            registerEvent("consent",checkConsentStatus);
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
        public void checkConsentStatus()
        {
            Consent consentInfo = Consent.getInstance(new Context());
            consentInfo.requestConsentUpdate(new MConsentUpdateListener());
        }
    }
}