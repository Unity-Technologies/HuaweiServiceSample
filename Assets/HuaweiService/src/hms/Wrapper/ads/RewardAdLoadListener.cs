using UnityEngine;
using System.Collections.Generic;

namespace HuaweiHms
{
    public class RewardAdLoadListenerData : IHmsBaseListener
    {
        public string name => "com.unity.hms.listener.IRewardAdLoadListener";
        public string buildName => "BuildRewardAdLoadListener";
    }
    public class RewardAdLoadListener : HmsListener<RewardAdLoadListenerData>
    {
    
        public virtual void onRewardedLoaded() {
            Call("onRewardedLoaded");
        }
    
        public virtual void onRewardAdFailedToLoad(int arg0) {
            Call("onRewardAdFailedToLoad", arg0);
        }
    }
}