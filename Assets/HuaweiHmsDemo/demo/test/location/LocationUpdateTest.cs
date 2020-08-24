using UnityEngine;
using HuaweiHms;

namespace HuaweiHmsDemo{
    public class LocationUpdateTest:Test<LocationUpdateTest>{
        public const string ACCESS_FINE_LOCATION ="android.permission.ACCESS_FINE_LOCATION";
        public const string ACCESS_COARSE_LOCATION = "android.permission.ACCESS_COARSE_LOCATION";
        public const string ACCESS_BACKGROUND_LOCATION = "android.permission.ACCESS_BACKGROUND_LOCATION";
        
        public LocationCallback mLocationCallback;
        public LocationRequest mLocationRequest;
        private FusedLocationProviderClient mFusedLocationProviderClient;
        private SettingsClient mSettingsClient;
        public bool IsCb;
        public override void RegistEvent(TestEvent registEvent){
            registEvent("SetPermission",SetPermission);
            registEvent("update with callback-102",()=>RequestLocationUpdatesWithCallback(102,true));
            registEvent("update with callback-104",()=>RequestLocationUpdatesWithCallback(104,true));
            registEvent("update with callback-100",()=>RequestLocationUpdatesWithCallback(100,true));
            registEvent("update with intent-102",()=>RequestLocationUpdatesWithCallback(102,false));
            registEvent("update with intent-104",()=>RequestLocationUpdatesWithCallback(104,false));
            registEvent("update with intent-100",()=>RequestLocationUpdatesWithCallback(100,false));
            registEvent("remove updates",RemoveUpdates);
        }
        public void SetPermission(){
            LocationCommon.SetPermission(
                new string[]{ACCESS_FINE_LOCATION,ACCESS_COARSE_LOCATION},
                new string[]{ACCESS_FINE_LOCATION,ACCESS_COARSE_LOCATION,ACCESS_BACKGROUND_LOCATION}
            );
        }
        public void RequestLocationUpdatesWithCallback(int priority,bool isCb){
            TestTip.Inst.ShowText("RequestLocationUpdatesWithCallback start");
            IsCb = isCb;
            mFusedLocationProviderClient = LocationServices.getFusedLocationProviderClient(new Context());
            mSettingsClient = LocationServices.getSettingsClient(new Context());
            mLocationRequest = new LocationRequest();
            mLocationRequest.setInterval(5000);
            mLocationRequest.setPriority(priority);
            // get LocationSettingsRequest
            LocationSettingsRequest.Builder builder = new LocationSettingsRequest.Builder();
            builder.addLocationRequest(mLocationRequest);
            LocationSettingsRequest locationSettingsRequest = builder.build();
            
            Task task = mSettingsClient.checkLocationSettings(locationSettingsRequest);
            task.addOnSuccessListener(new LocationSuccessListener((AndroidJavaObject o)=>{
                if(isCb){
                    SetCallbackSuccess();
                }else{
                    SetIntentSuccess();
                }
            }));
            task.addOnFailureListener(new LocationFailureListener((Exception e)=>SetSettingsFailuer(e)));
        }
        public void SetCallbackSuccess(){
            mLocationCallback = new LocationCb();
            mFusedLocationProviderClient
            .requestLocationUpdates(mLocationRequest,mLocationCallback,Looper.getMainLooper())
            .addOnSuccessListener(new LocationSuccessListener((AndroidJavaObject o)=>{
                    TestTip.Inst.ShowText("SetCallbackSuccess success");
            }))
            .addOnFailureListener(new LocationFailureListener((Exception e)=>{
                    TestTip.Inst.ShowText("SetCallbackSuccess fail");
            }));
        }
        public void SetIntentSuccess(){
            mFusedLocationProviderClient
            .requestLocationUpdates(mLocationRequest,LocationCommon.GetPendingIntent())
            .addOnSuccessListener(new LocationSuccessListener((AndroidJavaObject o)=>{
                TestTip.Inst.ShowText("set intent success");
            }))
            .addOnFailureListener(new LocationFailureListener((Exception e)=>{
                TestTip.Inst.ShowText("set intent fail");
            }));
        }
        public void SetSettingsFailuer(Exception e){
            int statusCode = e.Call<int>("getStatusCode");
            TestTip.Inst.ShowText("SetSettingsFailuer, error code: "+statusCode.ToString());
        }
        public void RemoveUpdates(){
            Task task = IsCb?mFusedLocationProviderClient.removeLocationUpdates(mLocationCallback)
            :mFusedLocationProviderClient.removeLocationUpdates(LocationCommon.GetPendingIntent());
            
            task.addOnSuccessListener(new LocationSuccessListener((AndroidJavaObject o)=>{
                    TestTip.Inst.ShowText("remove update success");
            }))
            .addOnFailureListener(new LocationFailureListener((Exception e)=>{
                    TestTip.Inst.ShowText("remove update failure");
            }));
        }
    }
}