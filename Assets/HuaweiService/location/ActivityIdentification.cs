using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.location
{
    public class ActivityIdentification_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.location.ActivityIdentification";
    }
    public class ActivityIdentification :HmsClass<ActivityIdentification_Data>
    {
        public ActivityIdentification (): base() { }
        public static ActivityIdentificationService getService(Activity arg0) {
            return CallStatic<ActivityIdentificationService>("getService", arg0);
        }
        public static ActivityIdentificationService getService(Context arg0) {
            return CallStatic<ActivityIdentificationService>("getService", arg0);
        }
    }
}