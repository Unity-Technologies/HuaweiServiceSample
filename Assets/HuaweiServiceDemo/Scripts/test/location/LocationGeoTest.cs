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
        public override void RegisterEvent(TestEvent registerEvent){
            registerEvent("CreateGeo",CreateGeo);
            registerEvent("removeGeo",RemoveGeo);
            registerEvent("removeGeoIntent",RemoveGeoIntent);
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