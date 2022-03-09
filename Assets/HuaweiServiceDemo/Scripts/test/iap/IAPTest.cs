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
            registerEvent("obtain Product Info", ObtainProductInfo);
            registerEvent("is env ready", IsEnvReady);
            registerEvent("is env ready true", IsEnvReadyTrue);
            registerEvent("create Purchase Intent(Consumables)", () => CreatePurchaseIntent("Buy goods"));
            registerEvent("create Purchase Intent(Subscription)", () => CreatePurchaseIntent("Subscription service"));
            //registerEvent("obtain Product Info", GetProduct);
        }
        public void MyOnActivityResultCallback(int requestCode, int resultCode,AndroidJavaObject obj)
        {
            TestTip.Inst.ShowText ("ppppppppp");
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
                        // 检查是否存在未发货商品
                        break;
                    case OrderStatusCode.ORDER_STATE_SUCCESS:
                        TestTip.Inst.ShowText ("order success");
                        // 支付成功
                        string inAppPurchaseData = purchaseResultInfo.getInAppPurchaseData();
                        string inAppPurchaseDataSignature = purchaseResultInfo.getInAppDataSignature();
                        // 使用您应用的IAP公钥验证签名
                        // 若验签成功，则进行发货
                        // 若用户购买商品为消耗型商品，您需要在发货成功后调用consumeOwnedPurchase接口进行消耗
                        break;
                    default:
                        break;
                }
            }
        }

        public void CreatePurchaseIntent(string type)
        {
            PurchaseIntentReq req = new PurchaseIntentReq();
            if (type == "Buy goods")
            {
                req.setProductId("test06");
                req.setPriceType(0);
            }
            else
            {
                req.setProductId("test03");
                req.setPriceType(2);
            }
            req.setDeveloperPayload("test");
            Activity activity = new UnityPlayerActivity();
            Task task = Iap.getIapClient(activity).createPurchaseIntent(req);

            var callback = new IapCallback();
            callback.setCallback(MyOnActivityResultCallback);
            IapActivity.setCallback(callback);

            task.addOnSuccessListener (new HmsIapListener<PurchaseIntentResult> ((result) =>
            {
                Status status = result.getStatus();
                if (status.hasResolution())
                {
                    status.startResolutionForResult(activity, 6666);
                }

            })).addOnFailureListener (new HmsFailureListener ((exception) => {
                TestTip.Inst.ShowText ("exception msg is " + exception.toString ());
            }));
        }

        public void ObtainProductInfo()
        {
            List productIdList = new List();
            productIdList.add("test01");
            ProductInfoReq req = new ProductInfoReq();
            req.setPriceType(0);
            req.setProductIds(productIdList);
            Activity activity = new UnityPlayerActivity();
            Task task = Iap.getIapClient(activity).obtainProductInfo(req);
            task.addOnSuccessListener (new HmsSuccessListener<ProductInfoResult> ((result) =>
            {
                // productInfoList = result.getProductInfoList().toType<Lists<ProductInfo>>();
                productInfoList = result.getProductInfoList();
                // info = result.getProductInfoList().toType<ProductInfo>(productInfoList.get(0));
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
                TestTip.Inst.ShowText("product info Subspri");
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
                TestTip.Inst.ShowText ("result.getCarrierId() " + result.getCarrierId());
                TestTip.Inst.ShowText ("result.getCountry() " + result.getCountry());
                int flag = result.getAccountFlag();
                TestTip.Inst.ShowText ("Account flag is " + flag);
                int returnCode = result.getReturnCode();
                TestTip.Inst.ShowText ("Return code is " + returnCode);
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
                TestTip.Inst.ShowText ("Account flag is " + flag);
                int returnCode = result.getReturnCode();
                TestTip.Inst.ShowText ("Return code is " + returnCode);

            })).addOnFailureListener (new HmsFailureListener ((exception) => {
                TestTip.Inst.ShowText ("exception msg is " + exception.toString ());
            }));
        }
        
    }
}