using UnityEngine;

namespace HuaweiServiceDemo{
    public class LocationTest : Test<LocationTest>{
        public override void RegisterEvent(TestEvent registerEvent){
            GetLastLocationTest.GetInstance().RegisterEvent(registerEvent);
            GetLocationAvailabilityTest.GetInstance().RegisterEvent(registerEvent);
            LocationUpdateTest.GetInstance().RegisterEvent(registerEvent);
            LocationRunTest.GetInstance().RegisterEvent(registerEvent);
            LocationGeoTest.GetInstance().RegisterEvent(registerEvent);
            MockModeTest.GetInstance().RegisterEvent(registerEvent);
            ActiveConvertionTest.GetInstance().RegisterEvent(registerEvent);
        }
    }
}