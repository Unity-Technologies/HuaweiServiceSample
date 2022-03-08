using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class NotificationChannel_Data : IHmsBaseClass{
        public string name => "android.app.NotificationChannel";
    }
    public class NotificationChannel :HmsClass<NotificationChannel_Data>
    {
        public static HuaweiService.Auth.Parcelable.Creator CREATOR => HmsUtil.GetStaticValue<HuaweiService.Auth.Parcelable.Creator>("CREATOR");
    
        public const string DEFAULT_CHANNEL_ID = "miscellaneous";
        public NotificationChannel (string arg0, string arg1, int arg2): base(arg0, arg1, arg2) { }
        public NotificationChannel (): base() { }
    }
}