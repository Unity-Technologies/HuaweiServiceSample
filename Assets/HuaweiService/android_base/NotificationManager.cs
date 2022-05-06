using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class NotificationManager_Data : IHmsBaseClass{
        public string name => "android.app.NotificationManager";
    }
    public class NotificationManager :HmsClass<NotificationManager_Data>
    {
        public const string ACTION_APP_BLOCK_STATE_CHANGED = "android.app.action.APP_BLOCK_STATE_CHANGED";
        public const string ACTION_INTERRUPTION_FILTER_CHANGED = "android.app.action.INTERRUPTION_FILTER_CHANGED";
        public const string ACTION_NOTIFICATION_CHANNEL_BLOCK_STATE_CHANGED = "android.app.action.NOTIFICATION_CHANNEL_BLOCK_STATE_CHANGED";
        public const string ACTION_NOTIFICATION_CHANNEL_GROUP_BLOCK_STATE_CHANGED = "android.app.action.NOTIFICATION_CHANNEL_GROUP_BLOCK_STATE_CHANGED";
        public const string ACTION_NOTIFICATION_POLICY_ACCESS_GRANTED_CHANGED = "android.app.action.NOTIFICATION_POLICY_ACCESS_GRANTED_CHANGED";
        public const string ACTION_NOTIFICATION_POLICY_CHANGED = "android.app.action.NOTIFICATION_POLICY_CHANGED";
        public const string EXTRA_BLOCKED_STATE = "android.app.extra.BLOCKED_STATE";
        public const string EXTRA_NOTIFICATION_CHANNEL_GROUP_ID = "android.app.extra.NOTIFICATION_CHANNEL_GROUP_ID";
        public const string EXTRA_NOTIFICATION_CHANNEL_ID = "android.app.extra.NOTIFICATION_CHANNEL_ID";
        public const int IMPORTANCE_DEFAULT = 3;
        public const int IMPORTANCE_HIGH = 4;
        public const int IMPORTANCE_LOW = 2;
        public const int IMPORTANCE_MAX = 5;
        public const int IMPORTANCE_MIN = 1;
        public const int IMPORTANCE_NONE = 0;
        public const int IMPORTANCE_UNSPECIFIED = -1000;
        public const int INTERRUPTION_FILTER_ALARMS = 4;
        public const int INTERRUPTION_FILTER_ALL = 1;
        public const int INTERRUPTION_FILTER_NONE = 3;
        public const int INTERRUPTION_FILTER_PRIORITY = 2;
        public const int INTERRUPTION_FILTER_UNKNOWN = 0;
        public NotificationManager (): base() { }
        public void createNotificationChannel(NotificationChannel arg0) {
            Call("createNotificationChannel", arg0);
        }
    }
}