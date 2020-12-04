using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class Location_Data : IHmsBaseClass{
        public string name => "android.location.Location";
    }
    public class Location :HmsClass<Location_Data>
    {
        public const int FORMAT_DEGREES = 0;
        public const int FORMAT_MINUTES = 1;
        public const int FORMAT_SECONDS = 2;
        public Location (string arg0): base(arg0) { }
        public Location (Location arg0): base(arg0) { }
        public Location (): base() { }
        public double getLongitude() {
            return Call<double>("getLongitude");
        }
        public double getLatitude() {
            return Call<double>("getLatitude");
        }
        public float getAccuracy() {
            return Call<float>("getAccuracy");
        }
        public void setLatitude(double arg0) {
            Call("setLatitude", arg0);
        }
        public void setLongitude(double arg0) {
            Call("setLongitude", arg0);
        }
    }
}