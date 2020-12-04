using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.ads
{
    public class ConsentUpdateListenerData : IHmsBaseListener
    {
        public string name => "com.huawei.hms.ads.consent.inter.ConsentUpdateListener";
        public string buildName => "";
    }
    public class ConsentUpdateListener : HmsListener<ConsentUpdateListenerData>
    {
    
        public virtual void onSuccess(ConsentStatus arg0, bool arg1, List arg2) {
            Call("onSuccess", arg0, arg1, arg2);
        }
    
        public void onSuccess(AndroidJavaObject arg0, bool arg1, AndroidJavaObject arg2){
            onSuccess(HmsUtil.GetHmsBase<ConsentStatus>(arg0), arg1, HmsUtil.GetHmsBase<List>(arg2));
        }
    
        public virtual void onFail(string arg0) {
            Call("onFail", arg0);
        }
    }
}