using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.push
{
    public class HmsMessaging_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.push.HmsMessaging";
    }
    public class HmsMessaging :HmsClass<HmsMessaging_Data>
    {
        public const string DEFAULT_TOKEN_SCOPE = "HCM";
        public HmsMessaging (): base() { }
        public static HmsMessaging getInstance(Context arg0) {
            return CallStatic<HmsMessaging>("getInstance", arg0);
        }
        public bool isAutoInitEnabled() {
            return Call<bool>("isAutoInitEnabled");
        }
        public void setAutoInitEnabled(bool arg0) {
            Call("setAutoInitEnabled", arg0);
        }
        public Task subscribe(string arg0) {
            return Call<Task>("subscribe", arg0);
        }
        public Task unsubscribe(string arg0) {
            return Call<Task>("unsubscribe", arg0);
        }
        public void send(RemoteMessage arg0) {
            Call("send", arg0);
        }
        public Task turnOnPush() {
            return Call<Task>("turnOnPush");
        }
        public Task turnOffPush() {
            return Call<Task>("turnOffPush");
        }
    }
}