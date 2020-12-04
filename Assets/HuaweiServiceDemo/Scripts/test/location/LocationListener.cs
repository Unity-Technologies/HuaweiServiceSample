using System;
using UnityEngine;
using HuaweiService;
using HuaweiService.location;
using Exception = HuaweiService.Exception;

namespace HuaweiServiceDemo{

    public delegate void SuccessCallBack<T>(T o);
    public class HmsSuccessListener<T>:OnSuccessListener{
        public SuccessCallBack<T> CallBack;
        public HmsSuccessListener(SuccessCallBack<T> c){
            CallBack = c;
        }
        public void onSuccess(T arg0)
        {
            TestTip.Inst.ShowText("OnSuccessListener onSuccess");
            if(CallBack != null)
            {
                CallBack.Invoke(arg0);
            }
        }
        
        public override void onSuccess(AndroidJavaObject arg0){
            TestTip.Inst.ShowText("OnSuccessListener onSuccess");
            if(CallBack !=null)
            {
                Type type = typeof(T);
                IHmsBase ret = (IHmsBase)Activator.CreateInstance(type);
                ret.obj = arg0;
                CallBack.Invoke((T)ret);
            }
        }
    }
    
    public delegate void SuccessCallBack(AndroidJavaObject o);
    public delegate void FailureCallBack(Exception e);
    
    public class LocationSuccessListener:OnSuccessListener{
        public SuccessCallBack CallBack;
        public LocationSuccessListener(SuccessCallBack c){
            CallBack = c;
        }
        public override void onSuccess(AndroidJavaObject arg0){
            TestTip.Inst.ShowText("OnSuccessListener onSuccess");
            if(CallBack !=null){
                CallBack.Invoke(arg0);
            }
        }
    }
    public class HmsFailureListener:OnFailureListener{
        public FailureCallBack CallBack;
        public HmsFailureListener(FailureCallBack c){
            CallBack = c;
        }
        public override void onFailure(Exception arg0){
            TestTip.Inst.ShowText("OnFailureListener onFailure");
            if(CallBack !=null){
                CallBack.Invoke(arg0);
            }
        }
    }
    public class MCompleteListener:OnCompleteListener{
        public override void onComplete(Task task) { 
            if(task.isSuccessful()){
                TestTip.Inst.ShowText($"OnCompleteListener success");
            }else{
                TestTip.Inst.ShowText("OnCompleteListener fail "+ task.Call<AndroidJavaObject>("getException").Call<string>("getMessage"));
            }
        }
    }
    public class LocationCallBackWrap:LocationCallback{
        public static double longitude;
        public static double latitude;
        public override void onLocationResult(LocationResult locationResult) {
            TestTip.Inst.ShowText("LocationCallback onLocationResult");
            List ls = locationResult.getLocations();
            AndroidJavaObject[] obj = ls.toArray();
            string s = "";
            for(int i=0;i<obj.Length;i++){
                Location loc = HmsUtil.GetHmsBase<Location>(obj[i]);
                s += "onLocationResult location[Longitude,Latitude,Accuracy]:" + loc.getLongitude()
                        + "," + loc.getLatitude() + "," + loc.getAccuracy();
                longitude = loc.getLongitude();
                latitude = loc.getLatitude();
            }
            TestTip.Inst.ShowText(s);
        }

        public override void onLocationAvailability(LocationAvailability locationAvailability) {
        }  
    }
    public class LocationBroadcast:IBroadcastReceiver{
        public static bool activityEnabled;
        public static bool isListenActivityConversion;
        public static void SetActivityEnabled(bool enabled){
            activityEnabled = enabled;
        }
        public static void SetListenActivityConversionEnabled(bool enabled){
            isListenActivityConversion = enabled;
        }
        public override void onReceive(Context arg0, Intent arg1){
            TestTip.Inst.ShowText("LocationBroadcast onReceive");
            string s = "data";
            
            ActivityConversionResponse activityTransitionResult = ActivityConversionResponse.getDataFromIntent(arg1);
            if (activityTransitionResult != null && isListenActivityConversion == true) {
                List list = activityTransitionResult.getActivityConversionDatas();
                AndroidJavaObject[] obj = list.toArray();
                for (int i = 0; i < obj.Length; i++)
                {
                    ActivityConversionData d = HmsUtil.GetHmsBase<ActivityConversionData>(obj[i]);
                    s += $"activityTransitionEvent[{i}]:" +
                         $"active type: {d.getActivityType()} " +
                         $"active ConversionType: {d.getConversionType()} ";
                }
            }

            if(LocationResult.hasResult(arg1)){
                s += "\n";
                LocationResult locationResult = LocationResult.extractResult(arg1);
                List ls = locationResult.getLocations();
                AndroidJavaObject[] obj = ls.toArray();
                for(int i=0;i<obj.Length;i++){
                    Location loc = HmsUtil.GetHmsBase<Location>(obj[i]);
                    s += "onLocationResult location[Longitude,Latitude,Accuracy]:" + loc.getLongitude()
                        + "," + loc.getLatitude() + "," + loc.getAccuracy() +"\n";
                }
            }
            ActivityIdentificationResponse activityRecognitionResult = ActivityIdentificationResponse.getDataFromIntent(arg1);
            if(activityEnabled && activityRecognitionResult.obj != null){
                s += "\n";
                List list = activityRecognitionResult.getActivityIdentificationDatas();
                AndroidJavaObject[] obj = list.toArray();
                s += obj.Length.ToString()+"\n";
                for(int i=0;i<obj.Length;i++){
                    ActivityIdentificationData d = HmsUtil.GetHmsBase<ActivityIdentificationData>(obj[i]);
                    int type = d.getIdentificationActivity();
                    int value = d.getPossibility();
                    s += "ActivityIdentificationResponse [type,value]:"+type+","+value+"\n";
                }
            }
            TestTip.Inst.ShowText(s);
        }
    }
    public class GeoFenceBroadcast:IBroadcastReceiver{
        public static bool activityEnabled;
        public static void SetActivityEnabled(bool enabled){
            activityEnabled = enabled;
        }
        public override void onReceive(Context arg0, Intent arg1){
            TestTip.Inst.ShowText("GeoFenceBroadcast success");
            GeofenceData geofenceData = GeofenceData.getDataFromIntent(arg1);
            string s = "receive\n";
            if (geofenceData != null) {
               int errorCode = geofenceData.getErrorCode();
               int conversion = geofenceData.getConversion();
               List list = geofenceData.getConvertingGeofenceList();
               Location mLocation = geofenceData.getConvertingLocation();
               bool status = geofenceData.isSuccess();
               s += "errorcode: " + errorCode.ToString()+"\n";
               s += "conversion: " + conversion.ToString()+"\n";
               for(int i = 0;i < list.toArray().Length;i++){
                   Geofence g = HmsUtil.GetHmsBase<Geofence>(list.toArray()[i]);
                   s += ("geoFence id :" + g.getUniqueId() + "\n");
               }
               s += ("location is :" + mLocation.getLongitude() + " " + mLocation.getLatitude() + "\n");
               s += ("is successful :" + status);
            }
            TestTip.Inst.ShowText(s);
        }
    }
}