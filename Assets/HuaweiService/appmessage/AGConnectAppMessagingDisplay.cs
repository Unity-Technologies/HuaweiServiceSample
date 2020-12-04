using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.appmessage
{
    public class AGConnectAppMessagingDisplayData : IHmsBaseListener
    {
        public string name => "com.huawei.agconnect.appmessaging.AGConnectAppMessagingDisplay";
        public string buildName => "";
    }
    public class AGConnectAppMessagingDisplay : HmsListener<AGConnectAppMessagingDisplayData>
    {
    
        public virtual void displayMessage(AppMessage arg0, AGConnectAppMessagingCallback arg1) {
            Call("displayMessage", arg0, arg1);
        }
    
        public void displayMessage(AndroidJavaObject arg0, AndroidJavaObject arg1){
            displayMessage(HmsUtil.GetHmsBase<AppMessage>(arg0), HmsUtil.GetHmsBase<AGConnectAppMessagingCallback>(arg1));
        }
    }
}