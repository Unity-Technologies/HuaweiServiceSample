using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.appmessage
{
    public class AGConnectAppMessagingOnDismissListenerData : IHmsBaseListener
    {
        public string name => "com.huawei.agconnect.appmessaging.AGConnectAppMessagingOnDismissListener";
        public string buildName => "";
    }
    public class AGConnectAppMessagingOnDismissListener : HmsListener<AGConnectAppMessagingOnDismissListenerData>
    {
    
        public virtual void onMessageDismiss(AppMessage arg0, AGConnectAppMessagingCallback.DismissType arg1) {
            Call("onMessageDismiss", arg0, arg1);
        }
    
        public void onMessageDismiss(AndroidJavaObject arg0, AndroidJavaObject arg1){
            onMessageDismiss(HmsUtil.GetHmsBase<AppMessage>(arg0), HmsUtil.GetHmsBase<AGConnectAppMessagingCallback.DismissType>(arg1));
        }
    }
}