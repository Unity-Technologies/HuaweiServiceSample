using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.IAP
{
    public class ProductInfoReq_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.iap.entity.ProductInfoReq";
    }
    public class ProductInfoReq :HmsClass<ProductInfoReq_Data>
    {
        public ProductInfoReq (): base() { }
        public int getPriceType() {
            return Call<int>("getPriceType");
        }
        public List getProductIds() {
            return Call<List>("getProductIds");
        }
        public void setPriceType(int arg0) {
            Call("setPriceType", arg0);
        }
        public void setProductIds(List arg0) {
            Call("setProductIds", arg0);
        }
    }
}