using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.IAP
{
    public class PurchaseIntentReq_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.iap.entity.PurchaseIntentReq";
    }
    public class PurchaseIntentReq :HmsClass<PurchaseIntentReq_Data>
    {
        public PurchaseIntentReq (): base() { }
        public string getDeveloperPayload() {
            return Call<string>("getDeveloperPayload");
        }
        public int getPriceType() {
            return Call<int>("getPriceType");
        }
        public string getProductId() {
            return Call<string>("getProductId");
        }
        public string getReservedInfor() {
            return Call<string>("getReservedInfor");
        }
        public string getSignatureAlgorithm() {
            return Call<string>("getSignatureAlgorithm");
        }
        public void setDeveloperPayload(string arg0) {
            Call("setDeveloperPayload", arg0);
        }
        public void setPriceType(int arg0) {
            Call("setPriceType", arg0);
        }
        public void setProductId(string arg0) {
            Call("setProductId", arg0);
        }
        public void setReservedInfor(string arg0) {
            Call("setReservedInfor", arg0);
        }
        public void setSignatureAlgorithm(string arg0) {
            Call("setSignatureAlgorithm", arg0);
        }
    }
}