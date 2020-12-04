using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.location
{
    public class LocationCallbackData : IHmsBaseListener
    {
        public string name => "com.unity.hms.listener.ILocationCallback";
        public string buildName => "BuildLocationCallback";
    }
    public class LocationCallback : HmsListener<LocationCallbackData>
    {
    
        public virtual void onLocationAvailability(LocationAvailability arg0) {
            Call("onLocationAvailability", arg0);
        }
    
        public void onLocationAvailability(AndroidJavaObject arg0){
            onLocationAvailability(HmsUtil.GetHmsBase<LocationAvailability>(arg0));
        }
    
        public virtual void onLocationResult(LocationResult arg0) {
            Call("onLocationResult", arg0);
        }
    
        public void onLocationResult(AndroidJavaObject arg0){
            onLocationResult(HmsUtil.GetHmsBase<LocationResult>(arg0));
        }
    }
}