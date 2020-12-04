using HuaweiService.push;
using UnityEngine;

namespace HuaweiService{
    public class IPushServiceListener:AndroidJavaProxy{
        public IPushServiceListener():base("com.unity.hms.push.IPushService"){}

        public virtual void onMessageReceived(RemoteMessage arg0) {
            
        }

        public void onMessageReceived(AndroidJavaObject arg0) {
            onMessageReceived(HmsUtil.GetHmsBase<RemoteMessage>(arg0));
        }
        
        public virtual void onMessageSent(string arg0) {
            
        }
        
        public virtual void onNewToken(string arg0) {
            
        }
        
        public virtual void onSendError(string arg0, BaseException arg1) {
            
        }
        public void onSendError(string arg0, AndroidJavaObject arg1) {
            onSendError(arg0,HmsUtil.GetHmsBase<BaseException>(arg1));
        }
        
        public virtual void onMessageDelivered(string arg0, BaseException arg1) {
            
        }
        public void onMessageDelivered(string arg0, AndroidJavaObject arg1) {
            onSendError(arg0,HmsUtil.GetHmsBase<BaseException>(arg1));
        }
        
        public virtual void onTokenError(BaseException arg0) {
            
        }
        public void onTokenError(AndroidJavaObject arg0) {
            onTokenError(HmsUtil.GetHmsBase<BaseException>(arg0));
        }
    }
}