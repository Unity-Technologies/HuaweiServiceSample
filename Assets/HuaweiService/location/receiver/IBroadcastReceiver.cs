using UnityEngine;

namespace HuaweiService{
    public class IBroadcastReceiver:AndroidJavaProxy{
        public IBroadcastReceiver():base("com.unity.hms.location.IBroadcastReceiver"){}

        public virtual void onReceive(Context arg0,Intent arg1) {
            
        }
        public void onReceive(AndroidJavaObject arg0,AndroidJavaObject arg1) {
            onReceive(HmsUtil.GetHmsBase<Context>(arg0),HmsUtil.GetHmsBase<Intent>(arg1));
        }
    }
}