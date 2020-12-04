using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.appmessage
{
    public class AGConnectAppMessagingOnDisplayListenerData : IHmsBaseListener
    {
        public string name => "com.huawei.agconnect.appmessaging.AGConnectAppMessagingOnDisplayListener";
        public string buildName => "";
    }
    public class AGConnectAppMessagingOnDisplayListener : HmsListener<AGConnectAppMessagingOnDisplayListenerData>
    {
    
        public virtual void onMessageDisplay(AppMessage arg0) {
            Call("onMessageDisplay", arg0);
        }
    
        public void onMessageDisplay(AndroidJavaObject arg0){
            onMessageDisplay(HmsUtil.GetHmsBase<AppMessage>(arg0));
        }
    }
}