using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.IAP
{
    public class StartIapActivityReq_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.iap.entity.StartIapActivityReq";
    }
    public class StartIapActivityReq :HmsClass<StartIapActivityReq_Data>
    {
        public const int TYPE_PAYINFO_ACTIVITY = 1;
        public const int TYPE_SUBSCRIBE_MANAGER_ACTIVITY = 2;
        public const int TYPE_SUBSCRIBE_EDIT_ACTIVITY = 3;
        public StartIapActivityReq (): base() { }
        public int getType() {
            return Call<int>("getType");
        }
        public string getSubscribeProductId() {
            return Call<string>("getSubscribeProductId");
        }
        public void setType(int arg0) {
            Call("setType", arg0);
        }
        public void setSubscribeProductId(string arg0) {
            Call("setSubscribeProductId", arg0);
        }
    }
}