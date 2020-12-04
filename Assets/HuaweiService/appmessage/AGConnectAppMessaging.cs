using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.appmessage
{
    public class AGConnectAppMessaging_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.appmessaging.AGConnectAppMessaging";
    }
    public class AGConnectAppMessaging :HmsClass<AGConnectAppMessaging_Data>
    {
        public AGConnectAppMessaging (): base() { }
        public bool isFetchMessageEnable() {
            return Call<bool>("isFetchMessageEnable");
        }
        public void setFetchMessageEnable(bool arg0) {
            Call("setFetchMessageEnable", arg0);
        }
        public bool isDisplayEnable() {
            return Call<bool>("isDisplayEnable");
        }
        public void setDisplayEnable(bool arg0) {
            Call("setDisplayEnable", arg0);
        }
        public void setForceFetch() {
            Call("setForceFetch");
        }
        public void addCustomView(AGConnectAppMessagingDisplay arg0) {
            Call("addCustomView", arg0);
        }
        public void removeCustomView() {
            Call("removeCustomView");
        }
        public void setDisplayLocation(Location arg0) {
            Call("setDisplayLocation", arg0);
        }
        public void trigger(string arg0) {
            Call("trigger", arg0);
        }
        public static AGConnectAppMessaging getInstance() {
            return CallStatic<AGConnectAppMessaging>("getInstance");
        }
        public void addOnClickListener(AGConnectAppMessagingOnClickListener arg0) {
            Call("addOnClickListener", arg0);
        }
        public void addOnDisplayListener(AGConnectAppMessagingOnDisplayListener arg0) {
            Call("addOnDisplayListener", arg0);
        }
        public void addOnDismissListener(AGConnectAppMessagingOnDismissListener arg0) {
            Call("addOnDismissListener", arg0);
        }
        public void addOnErrorListener(AGConnectAppMessagingOnErrorListener arg0) {
            Call("addOnErrorListener", arg0);
        }
    }
}