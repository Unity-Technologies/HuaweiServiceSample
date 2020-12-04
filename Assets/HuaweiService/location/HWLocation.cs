using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.location
{
    public class HWLocation_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.location.HWLocation";
    }
    public class HWLocation :HmsClass<HWLocation_Data>
    {
        public HWLocation (): base() { }
        public double getLatitude() {
            return Call<double>("getLatitude");
        }
        public double getLongitude() {
            return Call<double>("getLongitude");
        }
        public double getAltitude() {
            return Call<double>("getAltitude");
        }
        public float getSpeed() {
            return Call<float>("getSpeed");
        }
        public float getBearing() {
            return Call<float>("getBearing");
        }
        public float getAccuracy() {
            return Call<float>("getAccuracy");
        }
        public float getVerticalAccuracyMeters() {
            return Call<float>("getVerticalAccuracyMeters");
        }
        public float getSpeedAccuracyMetersPerSecond() {
            return Call<float>("getSpeedAccuracyMetersPerSecond");
        }
        public float getBearingAccuracyDegrees() {
            return Call<float>("getBearingAccuracyDegrees");
        }
        public string getProvider() {
            return Call<string>("getProvider");
        }
        public long getTime() {
            return Call<long>("getTime");
        }
        public long getElapsedRealtimeNanos() {
            return Call<long>("getElapsedRealtimeNanos");
        }
        public string getCountryCode() {
            return Call<string>("getCountryCode");
        }
        public string getCountryName() {
            return Call<string>("getCountryName");
        }
        public string getState() {
            return Call<string>("getState");
        }
        public string getCity() {
            return Call<string>("getCity");
        }
        public string getCounty() {
            return Call<string>("getCounty");
        }
        public string getStreet() {
            return Call<string>("getStreet");
        }
        public string getFeatureName() {
            return Call<string>("getFeatureName");
        }
        public string getPostalCode() {
            return Call<string>("getPostalCode");
        }
        public string getPhone() {
            return Call<string>("getPhone");
        }
        public string getUrl() {
            return Call<string>("getUrl");
        }
        public Map getExtraInfo() {
            return Call<Map>("getExtraInfo");
        }
    }
}