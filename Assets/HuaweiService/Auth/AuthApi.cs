using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.Auth
{
    public class AuthApiData : IHmsBaseListener
    {
        public string name => "com.huawei.agconnect.auth.api.AuthApi";
        public string buildName => "";
    }
    public class AuthApi : HmsListener<AuthApiData>
    {
    
        public virtual void login(Activity arg0, AGConnectInstance arg1, AuthLoginListener arg2) {
            Call("login", arg0, arg1, arg2);
        }
    
        public void login(AndroidJavaObject arg0, AndroidJavaObject arg1, AndroidJavaObject arg2){
            login(HmsUtil.GetHmsBase<Activity>(arg0), HmsUtil.GetHmsBase<AGConnectInstance>(arg1), HmsUtil.GetHmsBase<AuthLoginListener>(arg2));
        }
    
        public virtual void logout() {
            Call("logout");
        }
    
        public virtual int providerId() {
            return Call<int>("providerId");
        }
    }
}