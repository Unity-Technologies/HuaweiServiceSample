using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.location
{
    public class FusedLocationProviderClient_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.location.FusedLocationProviderClient";
    }
    public class FusedLocationProviderClient :HmsClass<FusedLocationProviderClient_Data>
    {
        public const string KEY_VERTICAL_ACCURACY = "verticalAccuracy";
        public FusedLocationProviderClient (Context arg0): base(arg0) { }
        public FusedLocationProviderClient (Activity arg0): base(arg0) { }
        public FusedLocationProviderClient (): base() { }
        public Task flushLocations() {
            return Call<Task>("flushLocations");
        }
        public Task getLastLocation() {
            return Call<Task>("getLastLocation");
        }
        public Task getLocationAvailability() {
            return Call<Task>("getLocationAvailability");
        }
        public Task removeLocationUpdates(LocationCallback arg0) {
            return Call<Task>("removeLocationUpdates", arg0);
        }
        public Task removeLocationUpdates(PendingIntent arg0) {
            return Call<Task>("removeLocationUpdates", arg0);
        }
        public Task requestLocationUpdates(LocationRequest arg0, PendingIntent arg1) {
            return Call<Task>("requestLocationUpdates", arg0, arg1);
        }
        public Task requestLocationUpdates(LocationRequest arg0, LocationCallback arg1, Looper arg2) {
            return Call<Task>("requestLocationUpdates", arg0, arg1, arg2);
        }
        public Task setMockMode(bool arg0) {
            return Call<Task>("setMockMode", arg0);
        }
        public Task setMockLocation(Location arg0) {
            return Call<Task>("setMockLocation", arg0);
        }
        public Task getLastLocationWithAddress(LocationRequest arg0) {
            return Call<Task>("getLastLocationWithAddress", arg0);
        }
        public Task requestLocationUpdatesEx(LocationRequest arg0, LocationCallback arg1, Looper arg2) {
            return Call<Task>("requestLocationUpdatesEx", arg0, arg1, arg2);
        }
    }
}