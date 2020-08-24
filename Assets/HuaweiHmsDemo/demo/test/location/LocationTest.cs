using UnityEngine;

namespace HuaweiHmsDemo{
    public class LocationTest : Test<LocationTest>{
        public override void RegistEvent(TestEvent registEvent){
            LocationUpdateTest.GetInstance().RegistEvent(registEvent);
            LocationRunTest.GetInstance().RegistEvent(registEvent);
            LocationGeoTest.GetInstance().RegistEvent(registEvent);
        }
    }
}