using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class PendingIntent_Data : IHmsBaseClass{
        public string name => "android.app.PendingIntent";
    }
    public class PendingIntent :HmsClass<PendingIntent_Data>
    {
        public const int FLAG_CANCEL_CURRENT = 268435456;
        public const int FLAG_IMMUTABLE = 67108864;
        public const int FLAG_NO_CREATE = 536870912;
        public const int FLAG_ONE_SHOT = 1073741824;
        public const int FLAG_UPDATE_CURRENT = 134217728;
        public PendingIntent (): base() { }
        public static PendingIntent getBroadcast(Context arg0, int arg1, Intent arg2, int arg3) {
            return CallStatic<PendingIntent>("getBroadcast", arg0, arg1, arg2, arg3);
        }
    }
}