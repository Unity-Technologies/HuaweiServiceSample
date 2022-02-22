using System.Collections.Generic;
using System.Text;
using HuaweiService;
using HuaweiService.location;
using UnityEngine;
using UnityEngine.UI;

namespace HuaweiServiceDemo{
    public class LocationGeoTest:Test<LocationGeoTest>{
        public const string ACTION_PROCESS_LOCATION = "com.huawei.hmssample.geofence.GeoFenceBroadcastReceiver.ACTION_PROCESS_LOCATION";
        private Geofence.Builder geoBuild = new Geofence.Builder();
        private GeofenceService mService;
        private PendingIntent pendingIntent;
        private int requestId = 0;
        private Context context;
        
        public override void RegisterEvent(TestEvent registerEvent){
            registerEvent("CreateGeo",CreateGeo);
            registerEvent("removeGeo",RemoveGeo);
            registerEvent("removeGeoIntent",RemoveGeoIntent);
            registerEvent("GetGeofence(Activity))",GetGeoByActivity);
            registerEvent("GetGeofence(Context))",GetGeoByContext);
        }

        public void GetGeoByContext()
        {
            context = new HuaweiService.Context().getApplicationContext();
            mService = LocationServices.getGeofenceService(context);
            pendingIntent = getPendingIntent();
            TestTip.Inst.ShowText("Successfully created a new GeofenceService instance.");
        }
        public void GetGeoByActivity()
        {
            AndroidJavaClass javaUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = javaUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            Activity activity = HmsUtil.GetHmsBase<Activity>(currentActivity);
            mService = LocationServices.getGeofenceService(activity);
            pendingIntent = getPendingIntent();
            TestTip.Inst.ShowText("Successfully created a new GeofenceService instance.");
        }
        public void CreateGeo(){
            Geofence fence = geoBuild
                .setUniqueId("7")
                .setRoundArea(LocationCallBackWrap.latitude,LocationCallBackWrap.longitude,200)
                .setConversions(7)
                .setValidContinueTime(1000000)
                .setDwellDelayTime(10000)
                .setNotificationInterval(100)
                .build();
            List geofenceList = new List();
            bool r = geofenceList.add(fence.obj);
            GeofenceRequest.Builder builder = new GeofenceRequest.Builder();    
            builder.createGeofenceList(geofenceList);  
            builder.setInitConversions(7);
            GeofenceRequest request =  builder.build();

            mService = new GeofenceService(new Context());
            pendingIntent = getPendingIntent();
            mService.createGeofenceList(request, pendingIntent).addOnCompleteListener(new MCompleteListener());
        }
        public void RemoveGeo(){
            List list = new List();
            list.add("7");
            mService.deleteGeofenceList(list).addOnCompleteListener(new MCompleteListener());
        }

        public void RemoveGeoIntent()
        {
            mService.deleteGeofenceList(pendingIntent).addOnCompleteListener(new MCompleteListener());
        }
        
        private PendingIntent getPendingIntent() {
            Context ctx = new Context();
            Intent intent = new Intent(ctx,BroadcastRegister.CreateGeoFenceReceiver(new GeoFenceBroadcast()));
            intent.setAction(ACTION_PROCESS_LOCATION);
            return PendingIntent.getBroadcast(ctx,++requestId, intent, PendingIntent.FLAG_UPDATE_CURRENT);
        }
    }
}