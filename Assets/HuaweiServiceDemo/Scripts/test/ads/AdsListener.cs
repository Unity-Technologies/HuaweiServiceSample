using HuaweiService;
using HuaweiService.ads;

namespace HuaweiServiceDemo{
    public partial class Util
    {
        public static void showToast(string message)
        {
            Toast.makeText(new Context(),message, Toast.LENGTH_SHORT).show();
        }
    }
    public class MAdListener : AdListener
    {
        private InterstitialAd ad;
        public MAdListener(InterstitialAd _ad) : base()
        {
            ad = _ad;
        }
        public override void onAdLoaded()
        {
            Util.showToast("AdListener onAdLoaded");
            TestTip.Inst.ShowText("AdListener onAdLoaded");
            ad.show();
        }

        public override void onAdFailed(int arg0)
        {
            Util.showToast($"Ad failed to load with error code {arg0}.");
        }

        public override void onAdOpened()
        {
            Util.showToast("Ad Opened");
        }

        public override void onAdClicked()
        {
            Util.showToast("Ad Clicked");
        }

        public override void onAdLeave()
        {
            Util.showToast("Ad Leave");
        }

        public override void onAdClosed()
        {
            Util.showToast("Ad Closed");
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
            Util.showToast("RewardAdLoadListener onRewardAdFailedToLoad "+errorCode);
            TestTip.Inst.ShowText("RewardAdLoadListener onRewardAdFailedToLoad "+errorCode);
        }

        public override void onRewardedLoaded()
        {
            Util.showToast("RewardAdLoadListener onRewardedLoaded");

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