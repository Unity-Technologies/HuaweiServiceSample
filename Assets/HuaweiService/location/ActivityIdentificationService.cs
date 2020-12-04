using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.location
{
    public class ActivityIdentificationService_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.location.ActivityIdentificationService";
    }
    public class ActivityIdentificationService :HmsClass<ActivityIdentificationService_Data>
    {
        public ActivityIdentificationService (Context arg0): base(arg0) { }
        public ActivityIdentificationService (Activity arg0): base(arg0) { }
        public ActivityIdentificationService (): base() { }
        public Task deleteActivityConversionUpdates(PendingIntent arg0) {
            return Call<Task>("deleteActivityConversionUpdates", arg0);
        }
        public Task deleteActivityIdentificationUpdates(PendingIntent arg0) {
            return Call<Task>("deleteActivityIdentificationUpdates", arg0);
        }
        public Task createActivityConversionUpdates(ActivityConversionRequest arg0, PendingIntent arg1) {
            return Call<Task>("createActivityConversionUpdates", arg0, arg1);
        }
        public Task createActivityIdentificationUpdates(long arg0, PendingIntent arg1) {
            return Call<Task>("createActivityIdentificationUpdates", arg0, arg1);
        }
    }
}