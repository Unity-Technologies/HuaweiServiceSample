using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.appmessage
{
    public class AppMessage_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.appmessaging.model.AppMessage";
    }
    public class AppMessage :HmsClass<AppMessage_Data>
    {
        public AppMessage (): base() { }
        public long getId() {
            return Call<long>("getId");
        }
        public long getStartTime() {
            return Call<long>("getStartTime");
        }
        public long getEndTime() {
            return Call<long>("getEndTime");
        }
        public int getFrequencyType() {
            return Call<int>("getFrequencyType");
        }
        public int getFrequencyValue() {
            return Call<int>("getFrequencyValue");
        }
        public int getTestFlag() {
            return Call<int>("getTestFlag");
        }
        public bool isTestMessage() {
            return Call<bool>("isTestMessage");
        }
    }
}