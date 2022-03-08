using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class AudioAttributes_Data : IHmsBaseClass{
        public string name => "android.media.AudioAttributes";
    }
    public class AudioAttributes :HmsClass<AudioAttributes_Data>
    {
        public const int CONTENT_TYPE_MOVIE = 3;
        public const int CONTENT_TYPE_MUSIC = 2;
        public const int CONTENT_TYPE_SONIFICATION = 4;
        public const int CONTENT_TYPE_SPEECH = 1;
        public const int CONTENT_TYPE_UNKNOWN = 0;
        public static HuaweiService.Auth.Parcelable.Creator CREATOR => HmsUtil.GetStaticValue<HuaweiService.Auth.Parcelable.Creator>("CREATOR");
    
        public const int FLAG_AUDIBILITY_ENFORCED = 1;
        public const int FLAG_HW_AV_SYNC = 16;
        public const int FLAG_LOW_LATENCY = 256;
        public const int USAGE_ALARM = 4;
        public const int USAGE_ASSISTANCE_ACCESSIBILITY = 11;
        public const int USAGE_ASSISTANCE_NAVIGATION_GUIDANCE = 12;
        public const int USAGE_ASSISTANCE_SONIFICATION = 13;
        public const int USAGE_ASSISTANT = 16;
        public const int USAGE_GAME = 14;
        public const int USAGE_MEDIA = 1;
        public const int USAGE_NOTIFICATION = 5;
        public const int USAGE_NOTIFICATION_COMMUNICATION_DELAYED = 9;
        public const int USAGE_NOTIFICATION_COMMUNICATION_INSTANT = 8;
        public const int USAGE_NOTIFICATION_COMMUNICATION_REQUEST = 7;
        public const int USAGE_NOTIFICATION_EVENT = 10;
        public const int USAGE_NOTIFICATION_RINGTONE = 6;
        public const int USAGE_UNKNOWN = 0;
        public const int USAGE_VOICE_COMMUNICATION = 2;
        public const int USAGE_VOICE_COMMUNICATION_SIGNALLING = 3;
        public AudioAttributes (): base() { }
    }
}