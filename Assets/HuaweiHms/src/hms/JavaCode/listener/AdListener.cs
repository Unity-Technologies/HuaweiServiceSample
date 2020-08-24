using UnityEngine;
using System.Collections.Generic;

namespace HuaweiHms
{
    public class AdListenerData : IHmsBaseListener
    {
        public string name => "com.unity.hms.listener.IAdListener";
        public string buildName => "BuildAdListener";
    }
    public class AdListener : HmsListener<AdListenerData>
    {
    
        public virtual void onAdClicked() { }
    
        public virtual void onAdClosed() { }
    
        public virtual void onAdFailed(int arg0) { }
    
        public virtual void onAdImpression() { }
    
        public virtual void onAdLeave() { }
    
        public virtual void onAdLoaded() { }
    
        public virtual void onAdOpened() { }
    }
}