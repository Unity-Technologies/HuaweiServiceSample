using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.IAP
{
    public class InAppPurchaseData_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.iap.entity.InAppPurchaseData";
    }
    public class InAppPurchaseData :HmsClass<InAppPurchaseData_Data>
    {
        public const int NOT_PRESENT = -2147483648;
        public InAppPurchaseData (string arg0): base(arg0) { }
        public InAppPurchaseData (): base() { }
        public int getAccountFlag() {
            return Call<int>("getAccountFlag");
        }
        public string getAppInfo() {
            return Call<string>("getAppInfo");
        }
        public string getApplicationId() {
            return Call<string>("getApplicationId");
        }
        public int getCancelledSubKeepDays() {
            return Call<int>("getCancelledSubKeepDays");
        }
        public long getCancellationTime() {
            return Call<long>("getCancellationTime");
        }
        public int getCancelReason() {
            return Call<int>("getCancelReason");
        }
        public long getCancelTime() {
            return Call<long>("getCancelTime");
        }
        public int getCancelWay() {
            return Call<int>("getCancelWay");
        }
        public int getConsumptionState() {
            return Call<int>("getConsumptionState");
        }
        public string getCountry() {
            return Call<string>("getCountry");
        }
        public string getCurrency() {
            return Call<string>("getCurrency");
        }
        public long getDaysLasted() {
            return Call<long>("getDaysLasted");
        }
        public int getDeferFlag() {
            return Call<int>("getDeferFlag");
        }
        public string getDeveloperChallenge() {
            return Call<string>("getDeveloperChallenge");
        }
        public string getDeveloperPayload() {
            return Call<string>("getDeveloperPayload");
        }
        public long getExpirationDate() {
            return Call<long>("getExpirationDate");
        }
        public int getExpirationIntent() {
            return Call<int>("getExpirationIntent");
        }
        public long getGraceExpirationTime() {
            return Call<long>("getGraceExpirationTime");
        }
        public int getIntroductoryFlag() {
            return Call<int>("getIntroductoryFlag");
        }
        public int getKind() {
            return Call<int>("getKind");
        }
        public string getLastOrderId() {
            return Call<string>("getLastOrderId");
        }
        public int getNotifyClosed() {
            return Call<int>("getNotifyClosed");
        }
        public long getNumOfDiscount() {
            return Call<long>("getNumOfDiscount");
        }
        public long getNumOfPeriods() {
            return Call<long>("getNumOfPeriods");
        }
        public string getOrderID() {
            return Call<string>("getOrderID");
        }
        public long getOriPurchaseTime() {
            return Call<long>("getOriPurchaseTime");
        }
        public string getOriSubscriptionId() {
            return Call<string>("getOriSubscriptionId");
        }
        public string getPackageName() {
            return Call<string>("getPackageName");
        }
        public string getPayOrderId() {
            return Call<string>("getPayOrderId");
        }
        public string getPayType() {
            return Call<string>("getPayType");
        }
        public long getPrice() {
            return Call<long>("getPrice");
        }
        public int getPriceConsentStatus() {
            return Call<int>("getPriceConsentStatus");
        }
        public string getProductGroup() {
            return Call<string>("getProductGroup");
        }
        public string getProductId() {
            return Call<string>("getProductId");
        }
        public string getProductName() {
            return Call<string>("getProductName");
        }
        public int getPurchaseState() {
            return Call<int>("getPurchaseState");
        }
        public long getPurchaseTime() {
            return Call<long>("getPurchaseTime");
        }
        public string getPurchaseToken() {
            return Call<string>("getPurchaseToken");
        }
        public int getPurchaseType() {
            return Call<int>("getPurchaseType");
        }
        public int getQuantity() {
            return Call<int>("getQuantity");
        }
        public long getRenewPrice() {
            return Call<long>("getRenewPrice");
        }
        public int getRenewStatus() {
            return Call<int>("getRenewStatus");
        }
        public long getResumeTime() {
            return Call<long>("getResumeTime");
        }
        public int getRetryFlag() {
            return Call<int>("getRetryFlag");
        }
        public string getSubscriptionId() {
            return Call<string>("getSubscriptionId");
        }
        public int getTrialFlag() {
            return Call<int>("getTrialFlag");
        }
        public bool isAutoRenewing() {
            return Call<bool>("isAutoRenewing");
        }
        public bool isSubValid() {
            return Call<bool>("isSubValid");
        }
    
        public class PurchaseState
        {
            public const int INITIALIZED = -2147483648;
            public const int PURCHASED = 0;
            public const int CANCELED = 1;
            public const int REFUNDED = 2;
            public const int PENDING = 3;
        }
    }
}