using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.Auth
{
    public class AuthLoginListenerData : IHmsBaseListener
    {
        public string name => "com.huawei.agconnect.auth.api.AuthLoginListener";
        public string buildName => "";
    }
    public class AuthLoginListener : HmsListener<AuthLoginListenerData>
    {
    
        public virtual void loginSuccess(AGConnectAuthCredential arg0) {
            Call("loginSuccess", arg0);
        }
    
        public void loginSuccess(AndroidJavaObject arg0){
            loginSuccess(HmsUtil.GetHmsBase<AGConnectAuthCredential>(arg0));
        }
    
        public virtual void loginCancel() {
            Call("loginCancel");
        }
    
        public virtual void loginFailure(Exception arg0) {
            Call("loginFailure", arg0);
        }
    
        public void loginFailure(AndroidJavaObject arg0){
            loginFailure(HmsUtil.GetHmsBase<Exception>(arg0));
        }
    }
}