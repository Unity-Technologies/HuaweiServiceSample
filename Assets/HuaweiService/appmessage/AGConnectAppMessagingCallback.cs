using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.appmessage
{
    public class AGConnectAppMessagingCallbackData : IHmsBaseListener
    {
        public string name => "com.huawei.agconnect.appmessaging.AGConnectAppMessagingCallback";
        public string buildName => "";
    }
    public class AGConnectAppMessagingCallback : HmsListener<AGConnectAppMessagingCallbackData>
    {
    
        public virtual void onMessageClick(AppMessage arg0) {
            Call("onMessageClick", arg0);
        }
    
        public void onMessageClick(AndroidJavaObject arg0){
            onMessageClick(HmsUtil.GetHmsBase<AppMessage>(arg0));
        }
    
        public virtual void onMessageDismiss(AppMessage arg0, DismissType arg1) {
            Call("onMessageDismiss", arg0, arg1);
        }
    
        public void onMessageDismiss(AndroidJavaObject arg0, AndroidJavaObject arg1){
            onMessageDismiss(HmsUtil.GetHmsBase<AppMessage>(arg0), HmsUtil.GetHmsBase<DismissType>(arg1));
        }
    
        public virtual void onMessageDisplay(AppMessage arg0) {
            Call("onMessageDisplay", arg0);
        }
    
        public void onMessageDisplay(AndroidJavaObject arg0){
            onMessageDisplay(HmsUtil.GetHmsBase<AppMessage>(arg0));
        }
    
        public virtual void onMessageError(AppMessage arg0) {
            Call("onMessageError", arg0);
        }
    
        public void onMessageError(AndroidJavaObject arg0){
            onMessageError(HmsUtil.GetHmsBase<AppMessage>(arg0));
        }
    
        public class DismissType_Data : IHmsBaseClass{
            public string name => "com.huawei.agconnect.appmessaging.AGConnectAppMessagingCallback$DismissType";
        }
        public class DismissType :HmsClass<DismissType_Data>
        {
            public static DismissType UNKNOWN_DISMISS_TYPE => HmsUtil.GetStaticValue<DismissType>("UNKNOWN_DISMISS_TYPE");
        
            public static DismissType CLICK => HmsUtil.GetStaticValue<DismissType>("CLICK");
        
            public static DismissType CLICK_OUTSIDE => HmsUtil.GetStaticValue<DismissType>("CLICK_OUTSIDE");
        
            public static DismissType BACK_BUTTON => HmsUtil.GetStaticValue<DismissType>("BACK_BUTTON");
        
            public static DismissType AUTO => HmsUtil.GetStaticValue<DismissType>("AUTO");
        
            public DismissType (): base() { }
        }
    }
}