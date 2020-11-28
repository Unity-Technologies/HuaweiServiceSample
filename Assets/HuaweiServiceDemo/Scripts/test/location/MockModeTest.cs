using System.Collections.Generic;
using System.Text;
using HuaweiHms;
using UnityEngine;
using UnityEngine.UI;

namespace HuaweiHmsDemo{
    public class MockModeTest:Test<MockModeTest>{
        private FusedLocationProviderClient mFusedLocationProviderClient;

        public override void RegisterEvent(TestEvent registerEvent){
            registerEvent("SetMockMode true",() => SetMockMode(true));
            registerEvent("SetMockMode false",() => SetMockMode(false));
            registerEvent("SetMock Location",setMockLocation);
        }

        public void SetMockMode(bool mMockFlag)
        {
            mFusedLocationProviderClient = LocationServices.getFusedLocationProviderClient(new Context());
            try {
               TestTip.Inst.ShowText( "setMockMode mock mode is " + mMockFlag);
                Task voidTask = mFusedLocationProviderClient.setMockMode(mMockFlag);
                voidTask.addOnSuccessListener(new LocationSuccessListener((e) =>
                {
                    TestTip.Inst.ShowText("setMockMode onSuccess");
                })).addOnFailureListener(new HmsFailureListener((e) =>
                {
                    TestTip.Inst.ShowText("setMockMode onFailure.\n" + e.toString());
                }));
                
            } catch (System.Exception e) {
                TestTip.Inst.ShowText("setMockMode exception:" + e.Message);
            }
        }
        
        public void setMockLocation() {
            try {
                Location mockLocation = new Location(LocationManager.GPS_PROVIDER);
                mockLocation.setLongitude(66.66);
                mockLocation.setLatitude(99.99);
                Task voidTask = mFusedLocationProviderClient.setMockLocation(mockLocation);
                voidTask.addOnSuccessListener(new LocationSuccessListener((o) =>
                {
                    TestTip.Inst.ShowText($"setMockLocation onSuccess:" +
                                          $"latitude: {mockLocation.getLatitude()} " +
                                          $"longitude: {mockLocation.getLongitude()}");
                })).addOnFailureListener(new HmsFailureListener((c) =>
                {
                    TestTip.Inst.ShowText("setMockLocation onFailure");
                }));
            } catch (System.Exception e) {
                TestTip.Inst.ShowText("setMockLocation exception");
            }
        }
    }
}