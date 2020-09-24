using System.Collections.Generic;
using System.Text;
using HuaweiHms;
using UnityEngine;
using UnityEngine.UI;

namespace HuaweiHmsDemo{
    public class ActiveConvertionTest:Test<ActiveConvertionTest>{
        public const string ACTION_PROCESS_LOCATION = "com.huawei.hms.location.ACTION_PROCESS_LOCATION";

        private FusedLocationProviderClient mFusedLocationProviderClient;
        public ActivityIdentificationService activityIdentificationService;
        public ActivityConversionRequest activityTransitionRequest;
        private PendingIntent pendingIntent;
        ActivityConversionInfo.Builder activityTransition = new ActivityConversionInfo.Builder();

        public override void RegisterEvent(TestEvent registerEvent){
            registerEvent("Check Still In and Out", CheckStill);
            registerEvent("Remove Check Still",removeActivityTransitionUpdates);
        }

        public void CheckStill()
        {
            if (activityIdentificationService == null)
            {
                activityIdentificationService = ActivityIdentification.getService(new Context());
            }
            
            if(pendingIntent != null){
                removeActivityTransitionUpdates();
            }

            LocationBroadcast.SetListenActivityConversionEnabled(true);
            try {
                List transitions = new List();
                activityTransition.setActivityType(103);
                activityTransition.setConversionType(0);
                transitions.add(activityTransition.build().obj);
                activityTransition.setActivityType(103);
                activityTransition.setConversionType(1);
                transitions.add(activityTransition.build().obj);
                pendingIntent = getPendingIntent();
                activityTransitionRequest = new ActivityConversionRequest(transitions);
                Task task = activityIdentificationService.createActivityConversionUpdates(activityTransitionRequest, pendingIntent);
                task.addOnSuccessListener(new LocationSuccessListener((o) =>
                {
                    TestTip.Inst.ShowText("createActivityConversionUpdates onSuccess");
                })).addOnFailureListener(new HmsFailureListener((o) =>
                {
                    TestTip.Inst.ShowText("createActivityConversionUpdates exception");
                }));
            } catch (System.Exception e) {
                TestTip.Inst.ShowText("createActivityConversionUpdates exception:" + e.StackTrace);
            }
        }
        
        private PendingIntent getPendingIntent() {
            Context ctx = new Context();
            Intent intent = new Intent(ctx,BroadcastRegister.CreateLocationReceiver(new LocationBroadcast()));
            intent.setAction(ACTION_PROCESS_LOCATION);
            return PendingIntent.getBroadcast(ctx,0, intent, PendingIntent.FLAG_UPDATE_CURRENT);
        }
        
        public void removeActivityTransitionUpdates() {
            LocationBroadcast.SetListenActivityConversionEnabled(false);

            try {
                // LocationBroadcastReceiver.removeConversionListener();
                activityIdentificationService.deleteActivityConversionUpdates(pendingIntent)
                    .addOnSuccessListener(new LocationSuccessListener((o) =>
                    {
                        TestTip.Inst.ShowText("deleteActivityConversionUpdates onSuccess");
                    })).addOnFailureListener(new HmsFailureListener((c) =>
                    {
                        TestTip.Inst.ShowText($"removeActivityTransitionUpdates exception: {c.toString()}");
                    }));
                pendingIntent = null;
            } catch (System.Exception e) {
                TestTip.Inst.ShowText("removeActivityTransitionUpdates exception:" + e.Message);
            }
        }
        
    }
}