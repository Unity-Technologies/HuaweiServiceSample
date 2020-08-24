using HuaweiHms;
namespace HuaweiHmsDemo{
    public class LocationGeoTest:Test<LocationGeoTest>{
        public const string ACTION_PROCESS_LOCATION = "com.huawei.hmssample.geofence.GeoFenceBroadcastReceiver.ACTION_PROCESS_LOCATION";
        private Geofence.Builder geoBuild = new Geofence.Builder();
        private GeofenceService mService;
        private int requestId = 0;
        public override void RegistEvent(TestEvent registEvent){
            registEvent("CreateGeo",CreateGeo);
            registEvent("removeGeo",RemoveGeo);
        }
        public void CreateGeo(){
            Geofence fence = geoBuild
                .setUniqueId("7")
                .setRoundArea(LocationCb.latitude,LocationCb.longitude,200)
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
            mService.createGeofenceList(request,getPendingIntent()).addOnCompleteListener(new MCompleteListener());
        }
        public void RemoveGeo(){
            List list = new List();
            list.add("7");
            mService.deleteGeofenceList(list).addOnCompleteListener(new MCompleteListener());
        }
        private PendingIntent getPendingIntent() {
            Context ctx = new Context();
            Intent intent = new Intent(ctx,BroadcastRegister.CreateGeoFenceReceiver(new GeoFenceBroadcast()));
            intent.setAction(ACTION_PROCESS_LOCATION);
            return PendingIntent.getBroadcast(ctx,++requestId, intent, PendingIntent.FLAG_UPDATE_CURRENT);
        }
    }
}