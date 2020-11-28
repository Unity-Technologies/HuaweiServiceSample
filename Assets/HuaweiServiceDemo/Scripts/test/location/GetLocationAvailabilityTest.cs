using System.Collections.Generic;
using System.Text;
using HuaweiHms;
using UnityEngine;
using UnityEngine.UI;

namespace HuaweiHmsDemo{
    public class GetLocationAvailabilityTest:Test<GetLocationAvailabilityTest>{
        private FusedLocationProviderClient mFusedLocationProviderClient;

        public override void RegisterEvent(TestEvent registerEvent){
            registerEvent("Get Location Availability",GetLocationAvailability);
        }

        public void GetLocationAvailability()
        {
            mFusedLocationProviderClient = LocationServices.getFusedLocationProviderClient(new Context());
            try {
                Task locationAvailability = mFusedLocationProviderClient.getLocationAvailability();
                locationAvailability.addOnSuccessListener(new HmsSuccessListener<LocationAvailability>((LocationAvailability locationAvailabilityIn) =>
                {
                    if (locationAvailabilityIn != null)
                    {
                        TestTip.Inst.ShowText("getLocationAvailability onSuccess:" + locationAvailabilityIn.toString());
                    }
                })).addOnFailureListener(new HmsFailureListener(exception =>
                {
                    TestTip.Inst.ShowText("getLocationAvailability onFailure");
                }));
            } catch (System.Exception e) {
                TestTip.Inst.ShowText("getLocationAvailability exception:" + e.Message);
            }
        }
        
    }
}