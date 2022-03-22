using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.IAP
{
    public class PurchaseResultInfo_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.iap.entity.PurchaseResultInfo";
    }
    public class PurchaseResultInfo :HmsClass<PurchaseResultInfo_Data>
    {
        public PurchaseResultInfo (): base() { }
        public string getErrMsg() {
            return Call<string>("getErrMsg");
        }
        public string getInAppDataSignature() {
            return Call<string>("getInAppDataSignature");
        }
        public string getInAppPurchaseData() {
            return Call<string>("getInAppPurchaseData");
        }
        public int getReturnCode() {
            return Call<int>("getReturnCode");
        }
        public string getSignatureAlgorithm() {
            return Call<string>("getSignatureAlgorithm");
        }
    }
}