using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.location
{
    public class ActivityIdentificationResponse_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.location.ActivityIdentificationResponse";
    }
    public class ActivityIdentificationResponse :HmsClass<ActivityIdentificationResponse_Data>
    {
        public ActivityIdentificationResponse (ActivityIdentificationData arg0, long arg1, long arg2): base(arg0, arg1, arg2) { }
        public ActivityIdentificationResponse (List arg0, long arg1, long arg2): base(arg0, arg1, arg2) { }
        public ActivityIdentificationResponse (): base() { }
        public static ActivityIdentificationResponse getDataFromIntent(Intent arg0) {
            return CallStatic<ActivityIdentificationResponse>("getDataFromIntent", arg0);
        }
        public int getActivityPossibility(int arg0) {
            return Call<int>("getActivityPossibility", arg0);
        }
        public long getElapsedTimeFromReboot() {
            return Call<long>("getElapsedTimeFromReboot");
        }
        public ActivityIdentificationData getMostActivityIdentification() {
            return Call<ActivityIdentificationData>("getMostActivityIdentification");
        }
        public List getActivityIdentificationDatas() {
            return Call<List>("getActivityIdentificationDatas");
        }
        public long getTime() {
            return Call<long>("getTime");
        }
        public static bool containDataFromIntent(Intent arg0) {
            return CallStatic<bool>("containDataFromIntent", arg0);
        }
    }
}