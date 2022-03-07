using System;
using UnityEngine;
using HuaweiService;
using HuaweiService.IAP;
using Exception = HuaweiService.Exception;

namespace HuaweiServiceDemo{

    public delegate void IAPCallBack<T>(T o);
    public class HmsIapListener<T>:OnSuccessListener{
        public IAPCallBack<T> CallBack;
        public HmsIapListener(IAPCallBack<T> c){
            CallBack = c;
        }
        public void onSuccess(T arg0)
        {
            TestTip.Inst.ShowText("OnSuccessListener onSuccess");
            if(CallBack != null)
            {
                CallBack.Invoke(arg0);
            }
        }
        
        public override void onSuccess(AndroidJavaObject arg0){
            TestTip.Inst.ShowText("OnSuccessListener onSuccess");
            if(CallBack !=null)
            {
                Type type = typeof(T);
                IHmsBase ret = (IHmsBase)Activator.CreateInstance(type);
                ret.obj = arg0;
                CallBack.Invoke((T)ret);
            }
        }

        public void onActivityResult(int requestCode, int resultCode, Intent data) {
            TestTip.Inst.ShowText ("onActivityResult");
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
                        String inAppPurchaseData = purchaseResultInfo.getInAppPurchaseData();
                        String inAppPurchaseDataSignature = purchaseResultInfo.getInAppDataSignature();
                        // 使用您应用的IAP公钥验证签名
                        // 若验签成功，则进行发货
                        // 若用户购买商品为消耗型商品，您需要在发货成功后调用consumeOwnedPurchase接口进行消耗
                        break;
                    default:
                        break;
                }
            }
        }
    }
    

}