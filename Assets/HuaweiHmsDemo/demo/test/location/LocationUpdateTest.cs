using UnityEngine;
using HuaweiHms;

namespace HuaweiHmsDemo
{
    public class LocationUpdateTest : Test<LocationUpdateTest>
    {
        public const string ACCESS_FINE_LOCATION = "android.permission.ACCESS_FINE_LOCATION";
        public const string ACCESS_COARSE_LOCATION = "android.permission.ACCESS_COARSE_LOCATION";
        public const string ACCESS_BACKGROUND_LOCATION = "android.permission.ACCESS_BACKGROUND_LOCATION";
        public const int CALLBACK = 1;
        public const int INTENT = 2;
        public const int LocationHD = 3;
        public LocationCallback mLocationCallback;
        public LocationRequest mLocationRequest;
        private FusedLocationProviderClient mFusedLocationProviderClient;
        private SettingsClient mSettingsClient;
        public int requestType;

        public override void RegisterEvent(TestEvent registerEvent)
        {
            registerEvent("SetPermission", SetPermission);
            registerEvent("update with callback-102", () => RequestLocationUpdates(102, CALLBACK));
            registerEvent("update with callback-104", () => RequestLocationUpdates(104, CALLBACK));
            registerEvent("update with callback-100", () => RequestLocationUpdates(100, CALLBACK));
            registerEvent("update with intent-102", () => RequestLocationUpdates(102, INTENT));
            registerEvent("update with intent-104", () => RequestLocationUpdates(104, INTENT));
            registerEvent("update with intent-100", () => RequestLocationUpdates(100, INTENT));
            registerEvent("update with location HD", () => RequestLocationUpdates(100, LocationHD));
            registerEvent("remove updates", RemoveUpdates);
        }

        public void SetPermission()
        {
            LocationCommon.SetPermission(
                new string[] {ACCESS_FINE_LOCATION, ACCESS_COARSE_LOCATION},
                new string[] {ACCESS_FINE_LOCATION, ACCESS_COARSE_LOCATION, ACCESS_BACKGROUND_LOCATION}
            );
        }
        
        public void RequestLocationUpdates(int priority, int requestType)
        {
            TestTip.Inst.ShowText("RequestLocationUpdatesWithCallback start");
            this.requestType = requestType;
            mFusedLocationProviderClient = LocationServices.getFusedLocationProviderClient(new Context());
            mSettingsClient = LocationServices.getSettingsClient(new Context());
            mLocationRequest = new LocationRequest();
            mLocationRequest.setInterval(5000);
            mLocationRequest.setPriority(priority);
            // get LocationSettingsRequest
            LocationSettingsRequest.Builder builder = new LocationSettingsRequest.Builder();
            builder.addLocationRequest(mLocationRequest);
            LocationSettingsRequest locationSettingsRequest = builder.build();

            Task task = mSettingsClient.checkLocationSettings(locationSettingsRequest);
            task.addOnSuccessListener(new LocationSuccessListener((AndroidJavaObject o) =>
            {
                switch (requestType)
                {
                    case CALLBACK:
                        SetCallbackSuccess();
                        break;
                    case INTENT:
                        SetIntentSuccess();
                        break;
                    case LocationHD:
                        SetHDSuccess();
                        break;
                }
            }));
            task.addOnFailureListener(new HmsFailureListener((Exception e) => SetSettingsFailuer(e)));
        }

        public void SetCallbackSuccess()
        {
            if (mLocationCallback == null)
            {
                mLocationCallback = new LocationCallBackWrap();
            }

            mFusedLocationProviderClient
                .requestLocationUpdates(mLocationRequest, mLocationCallback, Looper.getMainLooper())
                .addOnSuccessListener(new LocationSuccessListener((AndroidJavaObject o) =>
                {
                    TestTip.Inst.ShowText("SetCallbackSuccess success");
                }))
                .addOnFailureListener(new HmsFailureListener((Exception e) =>
                {
                    TestTip.Inst.ShowText("SetCallbackSuccess fail");
                }));
        }
        public void SetHDSuccess()
        {
            if (mLocationCallback == null)
            {
                mLocationCallback = new LocationCallBackWrap();
            }

            mFusedLocationProviderClient
                .requestLocationUpdatesEx(mLocationRequest, mLocationCallback, Looper.getMainLooper())
                .addOnSuccessListener(new LocationSuccessListener((AndroidJavaObject o) =>
                {
                    TestTip.Inst.ShowText("SetCallbackSuccess success");
                }))
                .addOnFailureListener(new HmsFailureListener((Exception e) =>
                {
                    TestTip.Inst.ShowText("SetCallbackSuccess fail");
                }));
        }

        public void SetIntentSuccess()
        {
            mFusedLocationProviderClient
                .requestLocationUpdates(mLocationRequest, LocationCommon.GetPendingIntent())
                .addOnSuccessListener(new LocationSuccessListener((AndroidJavaObject o) =>
                {
                    TestTip.Inst.ShowText("set intent success");
                }))
                .addOnFailureListener(new HmsFailureListener((Exception e) =>
                {
                    TestTip.Inst.ShowText("set intent fail");
                }));
        }

        public void SetSettingsFailuer(Exception e)
        {
            int statusCode = e.Call<int>("getStatusCode");
            TestTip.Inst.ShowText("SetSettingsFailuer, error code: " + statusCode.ToString());
        }

        public void RemoveUpdates()
        {
            Task task = null;
            switch (requestType)
            {
                case CALLBACK :
                    task = mFusedLocationProviderClient.removeLocationUpdates(mLocationCallback);
                    break;
                case INTENT:
                    task = mFusedLocationProviderClient.removeLocationUpdates(LocationCommon.GetPendingIntent());
                    break;
                case LocationHD:
                    task = mFusedLocationProviderClient.removeLocationUpdates(mLocationCallback);
                    break;;
            }

            if (task != null)
            {
                task.addOnSuccessListener(new LocationSuccessListener((AndroidJavaObject o) =>
                    {
                        TestTip.Inst.ShowText("remove update success");
                    }))
                    .addOnFailureListener(new HmsFailureListener((Exception e) =>
                    {
                        TestTip.Inst.ShowText("remove update failure");
                    }));
            }
        }
    }
}