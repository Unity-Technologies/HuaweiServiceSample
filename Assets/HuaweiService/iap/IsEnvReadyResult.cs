using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.IAP
{
    public class IsEnvReadyResult_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.iap.entity.IsEnvReadyResult";
    }
    public class IsEnvReadyResult :HmsClass<IsEnvReadyResult_Data>
    {
        public IsEnvReadyResult (): base() { }
        public int getAccountFlag() {
            return Call<int>("getAccountFlag");
        }
        public string getCarrierId() {
            return Call<string>("getCarrierId");
        }
        public string getCountry() {
            return Call<string>("getCountry");
        }
        public int getReturnCode() {
            return Call<int>("getReturnCode");
        }
        public void setAccountFlag(int arg0) {
            Call("setAccountFlag", arg0);
        }
        public void setReturnCode(int arg0) {
            Call("setReturnCode", arg0);
        }
        public void setCountry(string arg0) {
            Call("setCountry", arg0);
        }
        public void setCarrierId(string arg0) {
            Call("setCarrierId", arg0);
        }
    }
}