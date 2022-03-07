using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.IAP
{
    public class PurchaseIntentResult_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.iap.entity.PurchaseIntentResult";
    }
    public class PurchaseIntentResult :HmsClass<PurchaseIntentResult_Data>
    {
        public PurchaseIntentResult (): base() { }
        public string getErrMsg() {
            return Call<string>("getErrMsg");
        }
        public string getPaymentData() {
            return Call<string>("getPaymentData");
        }
        public string getPaymentSignature() {
            return Call<string>("getPaymentSignature");
        }
        public int getReturnCode() {
            return Call<int>("getReturnCode");
        }
        public Status getStatus() {
            return Call<Status>("getStatus");
        }
    }
}