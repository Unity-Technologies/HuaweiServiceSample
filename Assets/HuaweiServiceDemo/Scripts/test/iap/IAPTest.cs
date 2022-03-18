using System.Threading.Tasks;
using HuaweiService;
using HuaweiService.IAP;
using UnityEngine;
using Task = HuaweiService.Task;

namespace HuaweiServiceDemo
{
    public class IAPTest : Test<IAPTest>
    {
        public List productInfoList;
        public ProductInfo info;
        public override void RegisterEvent(TestEvent registerEvent)
        {
            init();
            registerEvent("obtain Consumables Product Info", () => ObtainProductInfo("Consumables"));
            registerEvent("obtain Subscription Product Info", () => ObtainProductInfo("Subscription"));
            registerEvent("is env ready", IsEnvReady);
            registerEvent("is env ready true", IsEnvReadyTrue);
            registerEvent("create Consumables Purchase Intent", () => CreatePurchaseIntent("Consumables"));
            registerEvent("create Non-Consumables Purchase Intent", () => CreatePurchaseIntent("Non-Consumables"));
            registerEvent("create Subscription Purchase Intent", () => CreatePurchaseIntent("Subscription"));
            registerEvent("consumables with price", () => CreatePurchaseIntentWithPrice("Consumables"));
            registerEvent("non-consumables with price", () => CreatePurchaseIntentWithPrice("Non-Consumables"));
            registerEvent("consume OwnedPurchase", ObtainOwnedPurchases);
            registerEvent("obtain Consumables Owned Purchase Record", () => ObtainOwnedPurchaseRecord("Consumables"));
            registerEvent("obtain Subscription Owned Purchase Record", () => ObtainOwnedPurchaseRecord("Subscription"));
        }
        public void init(){
            var callback = new IapCallback();
            callback.setCallback(OnActivityResultCallback);
            IapActivity.setCallback(callback);
        }
        public void CreatePurchaseIntent(string type)
        {
            if (type == "Consumables"){
                IapActivity.setIntent("Consumables");
                IapActivity.setConProductId("test12");
                IapActivity.setPriceType(0);
                IapActivity.start(new UnityPlayerActivity());
            }else if(type == "Non-Consumables"){
                IapActivity.setIntent("Non-Consumables");
                IapActivity.setConProductId("test13");
                IapActivity.setPriceType(1);
                IapActivity.start(new UnityPlayerActivity());
            }else{
                IapActivity.setIntent("Subscription");
                IapActivity.setConProductId("test03");
                IapActivity.setPriceType(2);
                IapActivity.start(new UnityPlayerActivity());
            }
        }
        public void CreatePurchaseIntentWithPrice(string type){
            PurchaseIntentWithPriceReq req = new PurchaseIntentWithPriceReq(); 
            req.setCurrency("CNY"); 
            req.setDeveloperPayload("test");
            if(type == "Consumables"){
                req.setPriceType(0); 
            }else{
                req.setPriceType(1); 
            }
            req.setSdkChannel("1"); 
            req.setProductName("test"); 
            req.setAmount("1.00"); 
            req.setProductId("ConsumableProduct2"); 
            req.setServiceCatalog("createPurchaseIntentWithPrice"); 
            req.setCountry("CN"); 
            UnityPlayerActivity activity = new UnityPlayerActivity();
            Task task = Iap.getIapClient(activity).createPurchaseIntentWithPrice(req); 
            task.addOnSuccessListener (new HmsSuccessListener<PurchaseIntentResult> ((result) =>{
                TestTip.Inst.ShowText ("get payment data: " + result.getPaymentData());
                TestTip.Inst.ShowText ("get payment signature: " + result.getPaymentSignature());
                Status status = result.getStatus();
                if (status.hasResolution())
                {
                    status.startResolutionForResult(activity, 6666);
                }
                int returnCode = result.getReturnCode();
                if (returnCode == OrderStatusCode.ORDER_STATE_SUCCESS){
                    TestTip.Inst.ShowText ("goods purchased successfully!");
                }
            })).addOnFailureListener (new HmsFailureListener ((exception) => {
                IapApiException apiException = HmsClassHelper.ConvertObject<IapApiException>(exception.obj);
                TestTip.Inst.ShowText ("exception msg is " + exception.toString ());
                int returnCode = apiException.getStatusCode();
                switch (returnCode) { 
                case OrderStatusCode.ORDER_HWID_NOT_LOGIN: 
                case OrderStatusCode.ORDER_NOT_ACCEPT_AGREEMENT: 
                    Status status = apiException.getStatus(); 
                    if (status != null && status.hasResolution()) { 
                        status.startResolutionForResult(activity, 8888); 
                    } 
                    break; 
                case OrderStatusCode.ORDER_PRODUCT_OWNED: 
                    break; 
                default: 
                    break; 
            } 
            }));
        }
        public void ObtainOwnedPurchaseRecord(string type){
            OwnedPurchasesReq req = new OwnedPurchasesReq();
            if (type == "Consumables"){
                req.setPriceType(0);
            }else{
                req.setPriceType(2);
            }
            Task task = Iap.getIapClient(new UnityPlayerActivity()).obtainOwnedPurchaseRecord(req);
            task.addOnSuccessListener (new HmsSuccessListener<OwnedPurchasesResult> ((result) =>{
                if (result.getReturnCode() == 0){
                    TestTip.Inst.ShowText ("obtain owned purchase record successfully!");
                }
                TestTip.Inst.ShowText ("purchase history is: "+result.getItemList());
            })).addOnFailureListener (new HmsFailureListener ((exception) => {
                    TestTip.Inst.ShowText ("exception msg is " + exception.toString ());
            }));
        }
        public void ObtainOwnedPurchases()
        {
            OwnedPurchasesReq ownedPurchasesReq = new OwnedPurchasesReq();
            ownedPurchasesReq.setPriceType(0);
            Activity activity = new UnityPlayerActivity();
            Task task = Iap.getIapClient(activity).obtainOwnedPurchases(ownedPurchasesReq);
            task.addOnSuccessListener (new HmsIapListener<OwnedPurchasesResult> ((result) =>
            {
                if (result != null && result.getInAppPurchaseDataList() != null)
                {
                    List inAppPurchaseData = result.getInAppPurchaseDataList();
                    TestTip.Inst.ShowText ("owned purchases result is " + inAppPurchaseData);
                    ConsumeOwnedPurchaseReq req = new ConsumeOwnedPurchaseReq();
                    string purchaseToken = "";
                    string inAppPurchaseDataStr = HmsClassHelper.ConvertObject<InAppPurchaseData>(inAppPurchaseData.get(0)).ToString();
                    InAppPurchaseData inAppPurchaseDataBean = new InAppPurchaseData(inAppPurchaseDataStr);
                    purchaseToken = inAppPurchaseDataBean.getPurchaseToken();
                    req.setPurchaseToken(purchaseToken);
                    Activity activity = new UnityPlayerActivity();
                    TestTip.Inst.ShowText ("inAppPurchaseDataBean is " + inAppPurchaseDataBean.ToString());
                    TestTip.Inst.ShowText ("purchaseToken is "+ purchaseToken);
                    Task task = Iap.getIapClient(activity).consumeOwnedPurchase(req);
                    task.addOnSuccessListener (new HmsSuccessListener<ConsumeOwnedPurchaseResult> ((result) =>{
                        if (result.getReturnCode() == 0){
                            TestTip.Inst.ShowText ("consumed goods successfully!");
                        }
                        TestTip.Inst.ShowText ("get signatureAlgorithm is "+result.getSignatureAlgorithm());
                    })).addOnFailureListener (new HmsFailureListener ((exception) => {
                        TestTip.Inst.ShowText ("exception msg is " + exception.toString ());
                    }));
                }
            })).addOnFailureListener (new HmsFailureListener ((exception) => {
                TestTip.Inst.ShowText ("exception msg is " + exception.toString ());
            }));
        }
        public void OnActivityResultCallback(int requestCode, int resultCode,AndroidJavaObject obj)
        {
            TestTip.Inst.ShowText ("OnActivityResultCallback");
            var data = new Intent();
            data.obj = obj;
            if (requestCode == 6666) {
                if (data == null) {
                    TestTip.Inst.ShowText ("data is null");
                    return;
                }
                Activity activity = new UnityPlayerActivity();
                PurchaseResultInfo purchaseResultInfo = Iap.getIapClient(activity).parsePurchaseResultInfoFromIntent(data);
                switch(purchaseResultInfo.getReturnCode()) {
                    case OrderStatusCode.ORDER_STATE_CANCEL:
                        TestTip.Inst.ShowText ("order cancel");
                        break;
                    case OrderStatusCode.ORDER_STATE_FAILED:
                    case OrderStatusCode.ORDER_PRODUCT_OWNED:
                        TestTip.Inst.ShowText ("product owned");
                        break;
                    case OrderStatusCode.ORDER_STATE_SUCCESS:
                        TestTip.Inst.ShowText ("order success!");
                        string inAppPurchaseData = purchaseResultInfo.getInAppPurchaseData();
                        string inAppPurchaseDataSignature = purchaseResultInfo.getInAppDataSignature();
                        TestTip.Inst.ShowText ("inAppPurchase data signature is " + inAppPurchaseDataSignature);
                        TestTip.Inst.ShowText ("inAppPurchase data is " + inAppPurchaseData);
                        TestTip.Inst.ShowText ("signatureAlgorithm is " + purchaseResultInfo.getSignatureAlgorithm());
                        break;
                    default:
                        break;
                }
            }
        }
        public void ObtainProductInfo(string type)
        {
            List productIdList = new List();
            ProductInfoReq req = new ProductInfoReq();
            if (type == "Consumables"){
                productIdList.add("test01");
                req.setPriceType(0);
            }else{
                productIdList.add("test03");
                req.setPriceType(2);
            }
            req.setProductIds(productIdList);
            Activity activity = new UnityPlayerActivity();
            Task task = Iap.getIapClient(activity).obtainProductInfo(req);
            task.addOnSuccessListener (new HmsSuccessListener<ProductInfoResult> ((result) =>
            {
                productInfoList = result.getProductInfoList();
                info = HmsClassHelper.ConvertObject<ProductInfo>(productInfoList.get(0));
                TestTip.Inst.ShowText ("productList is " + productInfoList);
                TestTip.Inst.ShowText ("productList is " + info);
                TestTip.Inst.ShowText ("product info currency is " + info.getCurrency());
                TestTip.Inst.ShowText ("product info micros price is " + info.getMicrosPrice());
                TestTip.Inst.ShowText ("product info getOfferUsedStatus is " + info.getOfferUsedStatus());
                TestTip.Inst.ShowText ("product info getOriginalLocalPrice is " + info.getOriginalLocalPrice());
                TestTip.Inst.ShowText ("product info getOriginalMicroPrice is " + info.getOriginalMicroPrice());
                TestTip.Inst.ShowText ("product info price is " + info.getPrice());
                TestTip.Inst.ShowText ("product info price type is " + info.getPriceType());
                TestTip.Inst.ShowText ("product info product desc is " + info.getProductDesc());
                TestTip.Inst.ShowText ("product info product id is " + info.getProductId());
                TestTip.Inst.ShowText ("product info product name is " + info.getProductName());
                TestTip.Inst.ShowText ("product info status is " + info.getStatus());
                TestTip.Inst.ShowText ("product info SubSpecialPriceMicros is " + info.getSubSpecialPriceMicros());
            })).addOnFailureListener (new HmsFailureListener ((exception) => {
                TestTip.Inst.ShowText ("exception msg is " + exception.toString ());
            }));
        }
        public void IsEnvReadyTrue()
        {
            Activity activity = new UnityPlayerActivity();
            Task task = Iap.getIapClient(activity).isEnvReady(true);
            task.addOnSuccessListener (new HmsSuccessListener<IsEnvReadyResult> ((result) =>
            {
                result.setCountry("CN");
                result.setCarrierId("1SDGTNJUI97806NJJHGN");
                TestTip.Inst.ShowText ("AppTouch scenarios");
            })).addOnFailureListener (new HmsFailureListener ((exception) => {
                TestTip.Inst.ShowText ("exception msg is " + exception.toString ());
            }));
        }
        public void IsEnvReady()
        {
            Activity activity = new UnityPlayerActivity();
            Task task = Iap.getIapClient(activity).isEnvReady();
            task.addOnSuccessListener (new HmsSuccessListener<IsEnvReadyResult> ((result) =>
            {
                if (result.getCarrierId() == null && result.getCountry() == null)
                {
                    TestTip.Inst.ShowText ("Non-AppTouch scenarios");
                }
                else
                {
                    TestTip.Inst.ShowText ("AppTouch scenarios");
                }
                int flag = result.getAccountFlag();
                TestTip.Inst.ShowText ("account flag is " + flag);
                int returnCode = result.getReturnCode();
                TestTip.Inst.ShowText ("return code is " + returnCode);
            })).addOnFailureListener (new HmsFailureListener ((exception) => {
                TestTip.Inst.ShowText ("exception msg is " + exception.toString ());
            }));
        }
    }
}