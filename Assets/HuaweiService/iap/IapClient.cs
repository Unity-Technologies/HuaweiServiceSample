using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.IAP
{
    public class IapClient_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.iap.IapClient";
    }
    public class IapClient :HmsClass<IapClient_Data>
    {
        public IapClient (): base() { }
        public Task consumeOwnedPurchase(ConsumeOwnedPurchaseReq arg0) {
            return Call<Task>("consumeOwnedPurchase", arg0);
        }
        public Task createPurchaseIntent(PurchaseIntentReq arg0) {
            return Call<Task>("createPurchaseIntent", arg0);
        }
        public Task createPurchaseIntentWithPrice(PurchaseIntentWithPriceReq arg0) {
            return Call<Task>("createPurchaseIntentWithPrice", arg0);
        }
        public void enablePendingPurchase() {
            Call("enablePendingPurchase");
        }
        public Task isEnvReady(bool arg0) {
            return Call<Task>("isEnvReady", arg0);
        }
        public Task isEnvReady() {
            return Call<Task>("isEnvReady");
        }
        public Task isSandboxActivated(IsSandboxActivatedReq arg0) {
            return Call<Task>("isSandboxActivated", arg0);
        }
        public Task obtainOwnedPurchaseRecord(OwnedPurchasesReq arg0) {
            return Call<Task>("obtainOwnedPurchaseRecord", arg0);
        }
        public Task obtainOwnedPurchases(OwnedPurchasesReq arg0) {
            return Call<Task>("obtainOwnedPurchases", arg0);
        }
        public Task obtainProductInfo(ProductInfoReq arg0) {
            return Call<Task>("obtainProductInfo", arg0);
        }
        public PurchaseResultInfo parsePurchaseResultInfoFromIntent(Intent arg0) {
            return Call<PurchaseResultInfo>("parsePurchaseResultInfoFromIntent", arg0);
        }
        public Task startIapActivity(StartIapActivityReq arg0) {
            return Call<Task>("startIapActivity", arg0);
        }
    
        public class PriceType
        {
            public const int IN_APP_CONSUMABLE = 0;
            public const int IN_APP_NONCONSUMABLE = 1;
            public const int IN_APP_SUBSCRIPTION = 2;
        }
    }
}