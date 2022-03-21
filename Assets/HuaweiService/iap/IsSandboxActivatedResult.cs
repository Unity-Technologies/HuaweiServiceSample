using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.IAP
{
    public class IsSandboxActivatedResult_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.iap.entity.IsSandboxActivatedResult";
    }
    public class IsSandboxActivatedResult :HmsClass<IsSandboxActivatedResult_Data>
    {
        public IsSandboxActivatedResult (): base() { }
        public string getErrMsg() {
            return Call<string>("getErrMsg");
        }
        public Boolean getIsSandboxApk() {
            return Call<Boolean>("getIsSandboxApk");
        }
        public Boolean getIsSandboxUser() {
            return Call<Boolean>("getIsSandboxUser");
        }
        public int getReturnCode() {
            return Call<int>("getReturnCode");
        }
        public string getVersionFrMarket() {
            return Call<string>("getVersionFrMarket");
        }
        public string getVersionInApk() {
            return Call<string>("getVersionInApk");
        }
    }
}