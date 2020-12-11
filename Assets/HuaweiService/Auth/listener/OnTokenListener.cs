using UnityEngine;
using HuaweiService;

namespace HuaweiService.Auth
{
    public class OnTokenListenerData : IHmsBaseListener
    {
        public string name => "com.huawei.agconnect.core.service.auth.OnTokenListener";
        public string buildName => "";
    }
    public class OnTokenListener : HmsListener<OnTokenListenerData>
    {
    
        public virtual void onChanged(TokenSnapshot arg0) { }
    
        public void onChanged(AndroidJavaObject arg0){
            onChanged(HmsUtil.GetHmsBase<TokenSnapshot>(arg0));
        }
    }
}