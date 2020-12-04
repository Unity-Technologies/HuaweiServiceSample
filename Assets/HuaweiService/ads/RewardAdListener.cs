using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.ads
{
    public class RewardAdListener_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.ads.reward.RewardAdListener";
    }
    public class RewardAdListener :HmsClass<RewardAdListener_Data>
    {
        public RewardAdListener (): base() { }
        public void onRewardAdClosed() {
            Call("onRewardAdClosed");
        }
        public void onRewardAdFailedToLoad(int arg0) {
            Call("onRewardAdFailedToLoad", arg0);
        }
        public void onRewardAdLeftApp() {
            Call("onRewardAdLeftApp");
        }
        public void onRewardAdLoaded() {
            Call("onRewardAdLoaded");
        }
        public void onRewardAdOpened() {
            Call("onRewardAdOpened");
        }
        public void onRewarded(Reward arg0) {
            Call("onRewarded", arg0);
        }
        public void onRewardAdCompleted() {
            Call("onRewardAdCompleted");
        }
        public void onRewardAdStarted() {
            Call("onRewardAdStarted");
        }
    }
}