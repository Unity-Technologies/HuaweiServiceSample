using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.IAP
{
    public class IapApiException_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.iap.IapApiException";
    }
    public class IapApiException :HmsClass<IapApiException_Data>
    {
        public IapApiException (Status arg0): base(arg0) { }
        public IapApiException (): base() { }
        public Status getStatus() {
            return Call<Status>("getStatus");
        }
        public int getStatusCode() {
            return Call<int>("getStatusCode");
        }
    }
}