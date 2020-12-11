using UnityEngine;
using System.Collections.Generic;
using HuaweiService;

namespace HuaweiService.Auth
{
    public class VerifyCodeResult_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.auth.VerifyCodeResult";
    }
    public class VerifyCodeResult :HmsClass<VerifyCodeResult_Data>
    {
        public VerifyCodeResult (string arg0, string arg1): base(arg0, arg1) { }
        public VerifyCodeResult (): base() { }
        public string getShortestInterval() {
            return Call<string>("getShortestInterval");
        }
        public string getValidityPeriod() {
            return Call<string>("getValidityPeriod");
        }
    }
}