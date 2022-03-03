using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.IAP
{
    public class ProductInfo_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.iap.entity.ProductInfo";
    }
    public class ProductInfo :HmsClass<ProductInfo_Data>
    {
        public ProductInfo (): base() { }
        public string getCurrency() {
            return Call<string>("getCurrency");
        }
        public long getMicrosPrice() {
            return Call<long>("getMicrosPrice");
        }
        public int getOfferUsedStatus() {
            return Call<int>("getOfferUsedStatus");
        }
        public string getOriginalLocalPrice() {
            return Call<string>("getOriginalLocalPrice");
        }
        public long getOriginalMicroPrice() {
            return Call<long>("getOriginalMicroPrice");
        }
        public string getPrice() {
            return Call<string>("getPrice");
        }
        public int getPriceType() {
            return Call<int>("getPriceType");
        }
        public string getProductDesc() {
            return Call<string>("getProductDesc");
        }
        public string getProductId() {
            return Call<string>("getProductId");
        }
        public string getProductName() {
            return Call<string>("getProductName");
        }
        public int getStatus() {
            return Call<int>("getStatus");
        }
        public string getSubFreeTrialPeriod() {
            return Call<string>("getSubFreeTrialPeriod");
        }
        public string getSubGroupId() {
            return Call<string>("getSubGroupId");
        }
        public string getSubGroupTitle() {
            return Call<string>("getSubGroupTitle");
        }
        public string getSubPeriod() {
            return Call<string>("getSubPeriod");
        }
        public int getSubProductLevel() {
            return Call<int>("getSubProductLevel");
        }
        public string getSubSpecialPeriod() {
            return Call<string>("getSubSpecialPeriod");
        }
        public int getSubSpecialPeriodCycles() {
            return Call<int>("getSubSpecialPeriodCycles");
        }
        public string getSubSpecialPrice() {
            return Call<string>("getSubSpecialPrice");
        }
        public long getSubSpecialPriceMicros() {
            return Call<long>("getSubSpecialPriceMicros");
        }
        public void setCurrency(string arg0) {
            Call("setCurrency", arg0);
        }
        public void setMicrosPrice(long arg0) {
            Call("setMicrosPrice", arg0);
        }
        public void setOfferUsedStatus(int arg0) {
            Call("setOfferUsedStatus", arg0);
        }
        public void setOriginalLocalPrice(string arg0) {
            Call("setOriginalLocalPrice", arg0);
        }
        public void setOriginalMicroPrice(long arg0) {
            Call("setOriginalMicroPrice", arg0);
        }
        public void setPrice(string arg0) {
            Call("setPrice", arg0);
        }
        public void setPriceType(int arg0) {
            Call("setPriceType", arg0);
        }
        public void setProductDesc(string arg0) {
            Call("setProductDesc", arg0);
        }
        public void setProductId(string arg0) {
            Call("setProductId", arg0);
        }
        public void setProductName(string arg0) {
            Call("setProductName", arg0);
        }
        public void setStatus(int arg0) {
            Call("setStatus", arg0);
        }
        public void setSubFreeTrialPeriod(string arg0) {
            Call("setSubFreeTrialPeriod", arg0);
        }
        public void setSubGroupId(string arg0) {
            Call("setSubGroupId", arg0);
        }
        public void setSubGroupTitle(string arg0) {
            Call("setSubGroupTitle", arg0);
        }
        public void setSubPeriod(string arg0) {
            Call("setSubPeriod", arg0);
        }
        public void setSubProductLevel(int arg0) {
            Call("setSubProductLevel", arg0);
        }
        public void setSubSpecialPeriod(string arg0) {
            Call("setSubSpecialPeriod", arg0);
        }
        public void setSubSpecialPeriodCycles(int arg0) {
            Call("setSubSpecialPeriodCycles", arg0);
        }
        public void setSubSpecialPrice(string arg0) {
            Call("setSubSpecialPrice", arg0);
        }
        public void setSubSpecialPriceMicros(long arg0) {
            Call("setSubSpecialPriceMicros", arg0);
        }
    }
}