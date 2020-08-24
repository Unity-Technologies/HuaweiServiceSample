using UnityEngine;
using HuaweiHms;

namespace HuaweiHmsDemo{

    public delegate void SuccessCb(AndroidJavaObject o);
    public delegate void FailureCb(Exception e);
    public class LocationSuccessListener:OnSuccessListener{
        public SuccessCb cb;
        public LocationSuccessListener(SuccessCb c){
            cb = c;
        }
        public override void onSuccess(AndroidJavaObject arg0){
            TestTip.Inst.ShowText("OnSuccessListener onSuccess");
            if(cb !=null){
                cb.Invoke(arg0);
            }
        }
    }
    public class LocationFailureListener:OnFailureListener{
        public FailureCb cb;
        public LocationFailureListener(FailureCb c){
            cb = c;
        }
        public override void onFailure(Exception arg0){
            TestTip.Inst.ShowText("OnFailureListener onFailure");
            if(cb !=null){
                cb.Invoke(arg0);
            }
        }
    }
    public class MCompleteListener:OnCompleteListener{
        public override void onComplete(Task task) { 
            if(task.isSuccessful()){
                TestTip.Inst.ShowText("OnCompleteListener success");
            }else{
                TestTip.Inst.ShowText("OnCompleteListener fail "+ task.Call<AndroidJavaObject>("getException").Call<string>("getMessage"));
            }
        }
    }
    public class LocationCb:LocationCallback{
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
        public static void SetActivityEnabled(bool enabled){
            activityEnabled = enabled;
        }
        public override void onReceive(Context arg0, Intent arg1){
            TestTip.Inst.ShowText("LocationBroadcast onReceive");
            string s = "data";
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
            s += activityRecognitionResult.obj != null?"y":"f";
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