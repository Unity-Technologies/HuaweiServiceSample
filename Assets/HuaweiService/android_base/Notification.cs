using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class Notification_Data : IHmsBaseClass{
        public string name => "android.app.Notification";
    }
    public class Notification :HmsClass<Notification_Data>
    {
        public static AudioAttributes AUDIO_ATTRIBUTES_DEFAULT => HmsUtil.GetStaticValue<AudioAttributes>("AUDIO_ATTRIBUTES_DEFAULT");
    
        public const int BADGE_ICON_LARGE = 2;
        public const int BADGE_ICON_NONE = 0;
        public const int BADGE_ICON_SMALL = 1;
        public const string CATEGORY_ALARM = "alarm";
        public const string CATEGORY_CALL = "call";
        public const string CATEGORY_EMAIL = "email";
        public const string CATEGORY_ERROR = "err";
        public const string CATEGORY_EVENT = "event";
        public const string CATEGORY_MESSAGE = "msg";
        public const string CATEGORY_NAVIGATION = "navigation";
        public const string CATEGORY_PROGRESS = "progress";
        public const string CATEGORY_PROMO = "promo";
        public const string CATEGORY_RECOMMENDATION = "recommendation";
        public const string CATEGORY_REMINDER = "reminder";
        public const string CATEGORY_SERVICE = "service";
        public const string CATEGORY_SOCIAL = "social";
        public const string CATEGORY_STATUS = "status";
        public const string CATEGORY_SYSTEM = "sys";
        public const string CATEGORY_TRANSPORT = "transport";
        public const int COLOR_DEFAULT = 0;
        public static HuaweiService.Auth.Parcelable.Creator CREATOR => HmsUtil.GetStaticValue<HuaweiService.Auth.Parcelable.Creator>("CREATOR");
    
        public const int DEFAULT_ALL = -1;
        public const int DEFAULT_LIGHTS = 4;
        public const int DEFAULT_SOUND = 1;
        public const int DEFAULT_VIBRATE = 2;
        public const string EXTRA_AUDIO_CONTENTS_URI = "android.audioContents";
        public const string EXTRA_BACKGROUND_IMAGE_URI = "android.backgroundImageUri";
        public const string EXTRA_BIG_TEXT = "android.bigText";
        public const string EXTRA_CHANNEL_GROUP_ID = "android.intent.extra.CHANNEL_GROUP_ID";
        public const string EXTRA_CHANNEL_ID = "android.intent.extra.CHANNEL_ID";
        public const string EXTRA_CHRONOMETER_COUNT_DOWN = "android.chronometerCountDown";
        public const string EXTRA_COLORIZED = "android.colorized";
        public const string EXTRA_COMPACT_ACTIONS = "android.compactActions";
        public const string EXTRA_CONVERSATION_TITLE = "android.conversationTitle";
        public const string EXTRA_HISTORIC_MESSAGES = "android.messages.historic";
        public const string EXTRA_INFO_TEXT = "android.infoText";
        public const string EXTRA_IS_GROUP_CONVERSATION = "android.isGroupConversation";
        public const string EXTRA_LARGE_ICON = "android.largeIcon";
        public const string EXTRA_LARGE_ICON_BIG = "android.largeIcon.big";
        public const string EXTRA_MEDIA_SESSION = "android.mediaSession";
        public const string EXTRA_MESSAGES = "android.messages";
        public const string EXTRA_MESSAGING_PERSON = "android.messagingUser";
        public const string EXTRA_NOTIFICATION_ID = "android.intent.extra.NOTIFICATION_ID";
        public const string EXTRA_NOTIFICATION_TAG = "android.intent.extra.NOTIFICATION_TAG";
        public const string EXTRA_PEOPLE = "android.people";
        public const string EXTRA_PEOPLE_LIST = "android.people.list";
        public const string EXTRA_PICTURE = "android.picture";
        public const string EXTRA_PROGRESS = "android.progress";
        public const string EXTRA_PROGRESS_INDETERMINATE = "android.progressIndeterminate";
        public const string EXTRA_PROGRESS_MAX = "android.progressMax";
        public const string EXTRA_REMOTE_INPUT_DRAFT = "android.remoteInputDraft";
        public const string EXTRA_REMOTE_INPUT_HISTORY = "android.remoteInputHistory";
        public const string EXTRA_SELF_DISPLAY_NAME = "android.selfDisplayName";
        public const string EXTRA_SHOW_CHRONOMETER = "android.showChronometer";
        public const string EXTRA_SHOW_WHEN = "android.showWhen";
        public const string EXTRA_SMALL_ICON = "android.icon";
        public const string EXTRA_SUB_TEXT = "android.subText";
        public const string EXTRA_SUMMARY_TEXT = "android.summaryText";
        public const string EXTRA_TEMPLATE = "android.template";
        public const string EXTRA_TEXT = "android.text";
        public const string EXTRA_TEXT_LINES = "android.textLines";
        public const string EXTRA_TITLE = "android.title";
        public const string EXTRA_TITLE_BIG = "android.title.big";
        public const int FLAG_AUTO_CANCEL = 16;
        public const int FLAG_FOREGROUND_SERVICE = 64;
        public const int FLAG_GROUP_SUMMARY = 512;
        public const int FLAG_HIGH_PRIORITY = 128;
        public const int FLAG_INSISTENT = 4;
        public const int FLAG_LOCAL_ONLY = 256;
        public const int FLAG_NO_CLEAR = 32;
        public const int FLAG_ONGOING_EVENT = 2;
        public const int FLAG_ONLY_ALERT_ONCE = 8;
        public const int FLAG_SHOW_LIGHTS = 1;
        public const int GROUP_ALERT_ALL = 0;
        public const int GROUP_ALERT_CHILDREN = 2;
        public const int GROUP_ALERT_SUMMARY = 1;
        public const string INTENT_CATEGORY_NOTIFICATION_PREFERENCES = "android.intent.category.NOTIFICATION_PREFERENCES";
        public const int PRIORITY_DEFAULT = 0;
        public const int PRIORITY_HIGH = 1;
        public const int PRIORITY_LOW = -1;
        public const int PRIORITY_MAX = 2;
        public const int PRIORITY_MIN = -2;
        public const int STREAM_DEFAULT = -1;
        public const int VISIBILITY_PRIVATE = 0;
        public const int VISIBILITY_PUBLIC = 1;
        public const int VISIBILITY_SECRET = -1;
        public Notification (Parcel arg0): base(arg0) { }
        public Notification (int arg0, string arg1, long arg2): base(arg0, arg1, arg2) { }
        public Notification (): base() { }
        public class Builder_Data : IHmsBaseClass{
            public string name => "android.app.Notification$Builder";
        }
        public class Builder :HmsClass<Builder_Data>
        {
            public Builder (Context arg0, string arg1): base(arg0, arg1) { }
            public Builder (Context arg0): base(arg0) { }
            public Builder (): base() { }
            public Notification build() {
                return Call<Notification>("build");
            }
            public Notification getNotification() {
                return Call<Notification>("getNotification");
            }
        }
    }
}