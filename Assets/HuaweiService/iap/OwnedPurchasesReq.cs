using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.IAP
{
    public class OwnedPurchasesReq_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.iap.entity.OwnedPurchasesReq";
    }
    public class OwnedPurchasesReq :HmsClass<OwnedPurchasesReq_Data>
    {
        public OwnedPurchasesReq (): base() { }
        public string getContinuationToken() {
            return Call<string>("getContinuationToken");
        }
        public int getPriceType() {
            return Call<int>("getPriceType");
        }
        public string getSignatureAlgorithm() {
            return Call<string>("getSignatureAlgorithm");
        }
        public void setContinuationToken(string arg0) {
            Call("setContinuationToken", arg0);
        }
        public void setPriceType(int arg0) {
            Call("setPriceType", arg0);
        }
        public void setSignatureAlgorithm(string arg0) {
            Call("setSignatureAlgorithm", arg0);
        }
    }
}