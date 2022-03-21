using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.IAP
{
    public class ConsumeOwnedPurchaseResult_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.iap.entity.ConsumeOwnedPurchaseResult";
    }
    public class ConsumeOwnedPurchaseResult :HmsClass<ConsumeOwnedPurchaseResult_Data>
    {
        public ConsumeOwnedPurchaseResult (): base() { }
        public string getConsumePurchaseData() {
            return Call<string>("getConsumePurchaseData");
        }
        public string getDataSignature() {
            return Call<string>("getDataSignature");
        }
        public string getErrMsg() {
            return Call<string>("getErrMsg");
        }
        public int getReturnCode() {
            return Call<int>("getReturnCode");
        }
        public string getSignatureAlgorithm() {
            return Call<string>("getSignatureAlgorithm");
        }
    }
}