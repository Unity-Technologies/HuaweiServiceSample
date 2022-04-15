using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.push
{
    public class HmsMessageService_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.push.HmsMessageService";
    }
    public class HmsMessageService :HmsClass<HmsMessageService_Data>
    {
        public const string SUBJECT_ID = "subject_id";
        public const string PROXY_TYPE = "proxy_type";
        public HmsMessageService (): base() { }
        public void onMessageReceived(RemoteMessage arg0) {
            Call("onMessageReceived", arg0);
        }
        public void onMessageSent(string arg0) {
            Call("onMessageSent", arg0);
        }
        public void onSendError(string arg0, Exception arg1) {
            Call("onSendError", arg0, arg1);
        }
        public void onNewToken(string arg0, Bundle arg1) {
            Call("onNewToken", arg0, arg1);
        }
        public void onNewToken(string arg0) {
            Call("onNewToken", arg0);
        }
        public void onTokenError(Exception arg0) {
            Call("onTokenError", arg0);
        }
        public void onTokenError(Exception arg0, Bundle arg1) {
            Call("onTokenError", arg0, arg1);
        }
        public void onMessageDelivered(string arg0, Exception arg1) {
            Call("onMessageDelivered", arg0, arg1);
        }
    }
}