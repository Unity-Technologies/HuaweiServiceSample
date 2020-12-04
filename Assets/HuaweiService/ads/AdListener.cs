using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.ads
{
    public class AdListenerData : IHmsBaseListener
    {
        public string name => "com.unity.hms.listener.IAdListener";
        public string buildName => "BuildAdListener";
    }
    public class AdListener : HmsListener<AdListenerData>
    {
    
        public virtual void onAdClicked() {
            Call("onAdClicked");
        }
    
        public virtual void onAdClosed() {
            Call("onAdClosed");
        }
    
        public virtual void onAdFailed(int arg0) {
            Call("onAdFailed", arg0);
        }
    
        public virtual void onAdImpression() {
            Call("onAdImpression");
        }
    
        public virtual void onAdLeave() {
            Call("onAdLeave");
        }
    
        public virtual void onAdLoaded() {
            Call("onAdLoaded");
        }
    
        public virtual void onAdOpened() {
            Call("onAdOpened");
        }
    }
}