using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.IAP
{
    public class ProductInfoResult_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.iap.entity.ProductInfoResult";
    }
    public class ProductInfoResult :HmsClass<ProductInfoResult_Data>
    {
        public ProductInfoResult (): base() { }
        public string getErrMsg() {
            return Call<string>("getErrMsg");
        }
        public List getProductInfoList() {
            return Call<List>("getProductInfoList");
        }
        public int getReturnCode() {
            return Call<int>("getReturnCode");
        }
    }
}