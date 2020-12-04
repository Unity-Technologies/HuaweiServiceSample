using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.appmessage
{
    public class AGConnectAppMessagingOnErrorListenerData : IHmsBaseListener
    {
        public string name => "com.huawei.agconnect.appmessaging.AGConnectAppMessagingOnErrorListener";
        public string buildName => "";
    }
    public class AGConnectAppMessagingOnErrorListener : HmsListener<AGConnectAppMessagingOnErrorListenerData>
    {
    
        public virtual void onMessageError(AppMessage arg0) {
            Call("onMessageError", arg0);
        }
    
        public void onMessageError(AndroidJavaObject arg0){
            onMessageError(HmsUtil.GetHmsBase<AppMessage>(arg0));
        }
    }
}