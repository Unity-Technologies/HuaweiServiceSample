using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.IAP
{
    public class PurchaseIntentWithPriceReq_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.iap.entity.PurchaseIntentWithPriceReq";
    }
    public class PurchaseIntentWithPriceReq :HmsClass<PurchaseIntentWithPriceReq_Data>
    {
        public PurchaseIntentWithPriceReq (): base() { }
        public string getAmount() {
            return Call<string>("getAmount");
        }
        public string getCountry() {
            return Call<string>("getCountry");
        }
        public string getCurrency() {
            return Call<string>("getCurrency");
        }
        public string getDeveloperPayload() {
            return Call<string>("getDeveloperPayload");
        }
        public int getPriceType() {
            return Call<int>("getPriceType");
        }
        public string getProductId() {
            return Call<string>("getProductId");
        }
        public string getProductName() {
            return Call<string>("getProductName");
        }
        public string getReservedInfor() {
            return Call<string>("getReservedInfor");
        }
        public string getSdkChannel() {
            return Call<string>("getSdkChannel");
        }
        public string getServiceCatalog() {
            return Call<string>("getServiceCatalog");
        }
        public void setAmount(string arg0) {
            Call("setAmount", arg0);
        }
        public void setCountry(string arg0) {
            Call("setCountry", arg0);
        }
        public void setCurrency(string arg0) {
            Call("setCurrency", arg0);
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
        public void setProductName(string arg0) {
            Call("setProductName", arg0);
        }
        public void setReservedInfor(string arg0) {
            Call("setReservedInfor", arg0);
        }
        public void setSdkChannel(string arg0) {
            Call("setSdkChannel", arg0);
        }
        public void setServiceCatalog(string arg0) {
            Call("setServiceCatalog", arg0);
        }
    }
}