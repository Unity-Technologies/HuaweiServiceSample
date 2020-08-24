using HuaweiHms;
namespace HuaweiHmsDemo{
    public class MAdListener : AdListener
    {
        private InterstitialAd ad;
        public MAdListener(InterstitialAd _ad) : base()
        {
            ad = _ad;
        }
        public override void onAdLoaded()
        {
            TestTip.Inst.ShowText("AdListener onAdLoaded");
            ad.show();
        }
    }
    public class MRewardLoadListener : RewardAdLoadListener
    {
        private RewardAd ad;
        public MRewardLoadListener(RewardAd _ad)
        {
            ad = _ad;
        }
        public override void onRewardAdFailedToLoad(int errorCode)
        {
            TestTip.Inst.ShowText("RewardAdLoadListener onRewardAdFailedToLoad "+errorCode);
        }

        public override void onRewardedLoaded()
        {
            TestTip.Inst.ShowText("RewardAdLoadListener onRewardedLoaded");
            ad.show(new Context(), new MRewardAdStatusListener());
        }
    }

    public class MRewardAdStatusListener : RewardAdStatusListener
    {
        public override void onRewardAdOpened()
        {
            TestTip.Inst.ShowText("RewardAdStatusListener onRewardAdOpened");
        }
        public override void onRewardAdClosed()
        {
            TestTip.Inst.ShowText("RewardAdStatusListener onRewardAdClosed");
        }
        public override void onRewarded(Reward arg0)
        {
            TestTip.Inst.ShowText("RewardAdStatusListener onRewarded");
        }
        public override void onRewardAdFailedToShow(int arg0)
        {
            TestTip.Inst.ShowText("RewardAdStatusListener onRewarded");
        }
    }
    public class MConsentUpdateListener : ConsentUpdateListener
    {
        public override void onSuccess(ConsentStatus arg0, bool isNeedConsent, List arg2)
        {
            TestTip.Inst.ShowText("ConsentUpdateListener onSuccess");
            if (arg0 == ConsentStatus.UNKNOWN)
            {
                TestTip.Inst.ShowText("UNKNOWN");
            }
            else if (arg0 == ConsentStatus.PERSONALIZED)
            {
                TestTip.Inst.ShowText("PERSONALIZED");
            }
            else if (arg0 == ConsentStatus.NON_PERSONALIZED)
            {
                TestTip.Inst.ShowText("NON_PERSONALIZED");
            }else{
                TestTip.Inst.ShowText("NON");
            }
        }
        public override void onFail(string arg0)
        {
            TestTip.Inst.ShowText("ConsentUpdateListener UNKNOWN");
            base.onFail(arg0);
        }
    }
}