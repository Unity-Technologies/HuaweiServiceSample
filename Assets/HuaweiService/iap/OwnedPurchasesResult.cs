using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.IAP
{
    public class OwnedPurchasesResult_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.iap.entity.OwnedPurchasesResult";
    }
    public class OwnedPurchasesResult :HmsClass<OwnedPurchasesResult_Data>
    {
        public OwnedPurchasesResult (): base() { }
        public string getContinuationToken() {
            return Call<string>("getContinuationToken");
        }
        public string getErrMsg() {
            return Call<string>("getErrMsg");
        }
        public List getInAppPurchaseDataList() {
            return Call<List>("getInAppPurchaseDataList");
        }
        public List getInAppSignature() {
            return Call<List>("getInAppSignature");
        }
        public List getItemList() {
            return Call<List>("getItemList");
        }
        public List getPlacedInappPurchaseDataList() {
            return Call<List>("getPlacedInappPurchaseDataList");
        }
        public List getPlacedInappSignatureList() {
            return Call<List>("getPlacedInappSignatureList");
        }
        public int getReturnCode() {
            return Call<int>("getReturnCode");
        }
        public string getSignatureAlgorithm() {
            return Call<string>("getSignatureAlgorithm");
        }
    }
}