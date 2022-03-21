using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.IAP
{
    public class ConsumeOwnedPurchaseReq_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.iap.entity.ConsumeOwnedPurchaseReq";
    }
    public class ConsumeOwnedPurchaseReq :HmsClass<ConsumeOwnedPurchaseReq_Data>
    {
        public ConsumeOwnedPurchaseReq (): base() { }
        public string getDeveloperChallenge() {
            return Call<string>("getDeveloperChallenge");
        }
        public string getPurchaseToken() {
            return Call<string>("getPurchaseToken");
        }
        public string getSignatureAlgorithm() {
            return Call<string>("getSignatureAlgorithm");
        }
        public void setDeveloperChallenge(string arg0) {
            Call("setDeveloperChallenge", arg0);
        }
        public void setPurchaseToken(string arg0) {
            Call("setPurchaseToken", arg0);
        }
        public void setSignatureAlgorithm(string arg0) {
            Call("setSignatureAlgorithm", arg0);
        }
    }
}