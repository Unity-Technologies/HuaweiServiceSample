using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.ads
{
    public class RewardAdStatusListenerData : IHmsBaseListener
    {
        public string name => "com.unity.hms.listener.IRewardAdStatusListener";
        public string buildName => "BuildRewardAdStatusListener";
    }
    public class RewardAdStatusListener : HmsListener<RewardAdStatusListenerData>
    {
    
        public virtual void onRewardAdClosed() {
            Call("onRewardAdClosed");
        }
    
        public virtual void onRewardAdFailedToShow(int arg0) {
            Call("onRewardAdFailedToShow", arg0);
        }
    
        public virtual void onRewardAdOpened() {
            Call("onRewardAdOpened");
        }
    
        public virtual void onRewarded(Reward arg0) {
            Call("onRewarded", arg0);
        }
    
        public void onRewarded(AndroidJavaObject arg0){
            onRewarded(HmsUtil.GetHmsBase<Reward>(arg0));
        }
    
        public class ErrorCode
        {
            public const int INTERNAL = 0;
            public const int REUSED = 1;
            public const int NOT_LOADED = 2;
            public const int BACKGROUND = 3;
        }
    }
}