using System.Collections.Generic;
using System.Text;
using HuaweiHms;
using UnityEngine;
using UnityEngine.UI;

namespace HuaweiHmsDemo{
    public class GetLastLocationTest:Test<GetLastLocationTest>{
        private FusedLocationProviderClient mFusedLocationProviderClient;

        public override void RegisterEvent(TestEvent registerEvent){
            registerEvent("Get Last Location",GetLastLocation);
        }

        public void GetLastLocation()
        {
            mFusedLocationProviderClient = LocationServices.getFusedLocationProviderClient(new Context());
            try {
                Task lastLocation = mFusedLocationProviderClient.getLastLocation();

                lastLocation.addOnSuccessListener(new HmsSuccessListener<Location>((location) =>
                {
                    if (location == null)
                    {
                        TestTip.Inst.ShowText( "getLastLocation onSuccess location is null");
                        return;
                    }
                    TestTip.Inst.ShowText(
                    "getLastLocation onSuccess location[Longitude,Latitude]:" + location.getLongitude() + ","
                    + location.getLatitude());
                })).addOnFailureListener(new HmsFailureListener((Exception e) =>
                {
                    TestTip.Inst.ShowText("getLastLocation onFailure");
                }));
            } catch (System.Exception e) {
                TestTip.Inst.ShowText("getLastLocation exception:" + e.Message);
            }
        }
        
    }
}