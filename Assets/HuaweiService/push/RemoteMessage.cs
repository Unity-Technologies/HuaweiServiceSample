using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.push
{
    public class RemoteMessage_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.push.RemoteMessage";
    }
    public class RemoteMessage :HmsClass<RemoteMessage_Data>
    {
        public const int PRIORITY_UNKNOWN = 0;
        public const int PRIORITY_HIGH = 1;
        public const int PRIORITY_NORMAL = 2;
        public RemoteMessage (Bundle arg0): base(arg0) { }
        public RemoteMessage (Parcel arg0): base(arg0) { }
        public RemoteMessage (): base() { }
        public string getCollapseKey() {
            return Call<string>("getCollapseKey");
        }
        public string getData() {
            return Call<string>("getData");
        }
        public Map getDataOfMap() {
            return Call<Map>("getDataOfMap");
        }
        public string getMessageId() {
            return Call<string>("getMessageId");
        }
        public string getMessageType() {
            return Call<string>("getMessageType");
        }
        public Notification getNotification() {
            return Call<Notification>("getNotification");
        }
        public int getOriginalUrgency() {
            return Call<int>("getOriginalUrgency");
        }
        public int getUrgency() {
            return Call<int>("getUrgency");
        }
        public int getTtl() {
            return Call<int>("getTtl");
        }
        public long getSentTime() {
            return Call<long>("getSentTime");
        }
        public string getTo() {
            return Call<string>("getTo");
        }
        public string getFrom() {
            return Call<string>("getFrom");
        }
        public string getToken() {
            return Call<string>("getToken");
        }
    
        public class Notification_Data : IHmsBaseClass{
            public string name => "com.huawei.hms.push.RemoteMessage$Notification";
        }
        public class Notification :HmsClass<Notification_Data>
        {
            public Notification (): base() { }
            public string getTitle() {
                return Call<string>("getTitle");
            }
            public string getTitleLocalizationKey() {
                return Call<string>("getTitleLocalizationKey");
            }
            public string[] getTitleLocalizationArgs() {
                return Call<string[]>("getTitleLocalizationArgs");
            }
            public string getBodyLocalizationKey() {
                return Call<string>("getBodyLocalizationKey");
            }
            public string[] getBodyLocalizationArgs() {
                return Call<string[]>("getBodyLocalizationArgs");
            }
            public string getBody() {
                return Call<string>("getBody");
            }
            public string getIcon() {
                return Call<string>("getIcon");
            }
            public string getSound() {
                return Call<string>("getSound");
            }
            public string getTag() {
                return Call<string>("getTag");
            }
            public string getColor() {
                return Call<string>("getColor");
            }
            public string getClickAction() {
                return Call<string>("getClickAction");
            }
            public string getChannelId() {
                return Call<string>("getChannelId");
            }
            public Uri getImageUrl() {
                return Call<Uri>("getImageUrl");
            }
            public Uri getLink() {
                return Call<Uri>("getLink");
            }
            public int getNotifyId() {
                return Call<int>("getNotifyId");
            }
            public bool isDefaultLight() {
                return Call<bool>("isDefaultLight");
            }
            public bool isDefaultSound() {
                return Call<bool>("isDefaultSound");
            }
            public bool isDefaultVibrate() {
                return Call<bool>("isDefaultVibrate");
            }
            public Long getWhen() {
                return Call<Long>("getWhen");
            }
            public int[] getLightSettings() {
                return Call<int[]>("getLightSettings");
            }
            public Integer getBadgeNumber() {
                return Call<Integer>("getBadgeNumber");
            }
            public bool isAutoCancel() {
                return Call<bool>("isAutoCancel");
            }
            public Integer getImportance() {
                return Call<Integer>("getImportance");
            }
            public string getTicker() {
                return Call<string>("getTicker");
            }
            public long[] getVibrateConfig() {
                return Call<long[]>("getVibrateConfig");
            }
            public Integer getVisibility() {
                return Call<Integer>("getVisibility");
            }
            public string getIntentUri() {
                return Call<string>("getIntentUri");
            }
        }
    
        public class Builder_Data : IHmsBaseClass{
            public string name => "com.huawei.hms.push.RemoteMessage$Builder";
        }
        public class Builder :HmsClass<Builder_Data>
        {
            public Builder (string arg0): base(arg0) { }
            public Builder (): base() { }
            public Builder addData(string arg0, string arg1) {
                return Call<Builder>("addData", arg0, arg1);
            }
            public Builder setData(Map arg0) {
                return Call<Builder>("setData", arg0);
            }
            public Builder clearData() {
                return Call<Builder>("clearData");
            }
            public Builder setMessageId(string arg0) {
                return Call<Builder>("setMessageId", arg0);
            }
            public Builder setMessageType(string arg0) {
                return Call<Builder>("setMessageType", arg0);
            }
            public Builder setTtl(int arg0) {
                return Call<Builder>("setTtl", arg0);
            }
            public Builder setCollapseKey(string arg0) {
                return Call<Builder>("setCollapseKey", arg0);
            }
            public Builder setSendMode(int arg0) {
                return Call<Builder>("setSendMode", arg0);
            }
            public Builder setReceiptMode(int arg0) {
                return Call<Builder>("setReceiptMode", arg0);
            }
            public RemoteMessage build() {
                return Call<RemoteMessage>("build");
            }
        }
    }
}