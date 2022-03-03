using System.Threading.Tasks;
using HuaweiService;
using HuaweiService.IAP;
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
            //registerEvent("obtain Product Info", GetProduct);
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
                info = result.getProductInfoList().toType<ProductInfo>(productInfoList.get(0));
                TestTip.Inst.ShowText ("productList is " + productInfoList);
                TestTip.Inst.ShowText ("productList is " + info);
                TestTip.Inst.ShowText ("productList is " + info.getProductId());
                // foreach (ProductInfo p in productInfoList)
                // {
                //
                // }
                
            })).addOnFailureListener (new HmsFailureListener ((exception) => {
                TestTip.Inst.ShowText ("exception msg is " + exception.toString ());
            }));
            
           
        }

        // public void GetProduct()
        // {
        //     for(ProductInfo a:productIdList)
        //     {
        //         
        //     }
        //     
        // }
    }
}