using UnityEngine;
using HuaweiHms;

namespace HuaweiHmsDemo{
    public class LocationRunTest:Test<LocationRunTest>{
        public ActivityIdentificationService activityIdentificationService;

        public override void RegistEvent(TestEvent registEvent){
            registEvent("SetActivityPermission",RequestActivityPermission);
            registEvent("RequestActivity",RequestActivity);
            registEvent("RemoveRunning",RemoveRunning);
        }
        public void RequestActivityPermission(){
            LocationCommon.SetPermission(
                new string[]{"com.huawei.hms.permission.ACTIVITY_RECOGNITION"},
                new string[]{"android.permission.ACTIVITY_RECOGNITION"}
            );
        }
        public void RequestActivity(){
            LocationBroadcast.SetActivityEnabled(true);
            activityIdentificationService = ActivityIdentification.getService(new Activity());
            activityIdentificationService.createActivityIdentificationUpdates(5000,LocationCommon.GetPendingIntent())
            .addOnSuccessListener(new LocationSuccessListener((AndroidJavaObject o)=>{
                TestTip.Inst.ShowText("activity success");
            }))
            .addOnFailureListener(new LocationFailureListener((Exception e)=>{
                TestTip.Inst.ShowText("activity failure");
            }));
        }
        public void RemoveRunning(){
            LocationBroadcast.SetActivityEnabled(false);
            activityIdentificationService.deleteActivityIdentificationUpdates(LocationCommon.GetPendingIntent());
        }
    }
}