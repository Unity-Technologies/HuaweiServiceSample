using UnityEngine;

namespace HuaweiService{
    public class BroadcastRegister{
        public static AndroidJavaClass CreateLocationReceiver(IBroadcastReceiver listener){
            AndroidJavaClass cl = new AndroidJavaClass("com.unity.hms.location.LocationBroadcastReceiver");
            return cl.CallStatic<AndroidJavaClass>("SetListener",listener);
        }
        public static AndroidJavaClass CreateGeoFenceReceiver(IBroadcastReceiver listener){
            AndroidJavaClass cl = new AndroidJavaClass("com.unity.hms.location.GeoFenceBroadcastReceiver");
            return cl.CallStatic<AndroidJavaClass>("SetListener",listener);
        }
    }
}