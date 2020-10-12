using UnityEngine;
using System.Collections.Generic;

namespace HuaweiHms
{
    public class RewardAdStatusListenerData : IHmsBaseListener
    {
        public string name => "com.unity.hms.listener.IRewardAdStatusListener";
        public string buildName => "BuildRewardAdStatusListener";
    }
    public class RewardAdStatusListener : HmsListener<RewardAdStatusListenerData>
    {
    
        public virtual void onRewardAdClosed() { }
    
        public virtual void onRewardAdFailedToShow(int arg0) { }
    
        public virtual void onRewardAdOpened() { }
    
        public virtual void onRewarded(Reward arg0) { }
    
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