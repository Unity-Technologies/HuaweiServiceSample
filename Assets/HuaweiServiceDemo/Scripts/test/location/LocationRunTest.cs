using UnityEngine;
using HuaweiService;
using HuaweiService.location;

namespace HuaweiServiceDemo{
    public class LocationRunTest:Test<LocationRunTest>{
        public ActivityIdentificationService activityIdentificationService;

        public override void RegisterEvent(TestEvent registerEvent){
            registerEvent("SetActivityPermission",RequestActivityPermission);
            registerEvent("RequestActivity",RequestActivity);
            registerEvent("RemoveRunning",RemoveRunning);
        }
        public void RequestActivityPermission(){
            LocationCommon.SetPermission(
                new string[]{"com.huawei.hms.permission.ACTIVITY_RECOGNITION"},
                new string[]{"android.permission.ACTIVITY_RECOGNITION"}
            );
        }
        public void RequestActivity(){
            LocationBroadcast.SetActivityEnabled(true);
            activityIdentificationService = ActivityIdentification.getService(new UnityPlayerActivity());
            activityIdentificationService.createActivityIdentificationUpdates(5000,LocationCommon.GetPendingIntent())
            .addOnSuccessListener(new LocationSuccessListener((AndroidJavaObject o)=>{
                TestTip.Inst.ShowText("activity success");
            }))
            .addOnFailureListener(new HmsFailureListener((Exception e)=>{
                TestTip.Inst.ShowText("activity failure");
            }));
        }
        public void RemoveRunning(){
            LocationBroadcast.SetActivityEnabled(false);
            activityIdentificationService.deleteActivityIdentificationUpdates(LocationCommon.GetPendingIntent());
        }
    }
}