using UnityEngine;
using System.Collections.Generic;
using HuaweiService;

namespace HuaweiService.Auth
{
    public class HuaweiIdAuthParamsHelper_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.support.hwid.request.HuaweiIdAuthParamsHelper";
    }
    public class HuaweiIdAuthParamsHelper :HmsClass<HuaweiIdAuthParamsHelper_Data>
    {
        public HuaweiIdAuthParamsHelper (): base() { }
        public HuaweiIdAuthParamsHelper (HuaweiIdAuthParams arg0): base(arg0) { }
        public HuaweiIdAuthParamsHelper setUid() {
            return Call<HuaweiIdAuthParamsHelper>("setUid");
        }
        public HuaweiIdAuthParamsHelper setAuthorizationCode() {
            return Call<HuaweiIdAuthParamsHelper>("setAuthorizationCode");
        }
        public HuaweiIdAuthParamsHelper setAccessToken() {
            return Call<HuaweiIdAuthParamsHelper>("setAccessToken");
        }
        public HuaweiIdAuthParamsHelper setDialogAuth() {
            return Call<HuaweiIdAuthParamsHelper>("setDialogAuth");
        }
        public HuaweiIdAuthParamsHelper setScopeList(List<Scope> arg0) {
            return Call<HuaweiIdAuthParamsHelper>("setScopeList", arg0);
        }
        public HuaweiIdAuthParams createParams() {
            return Call<HuaweiIdAuthParams>("createParams");
        }
        public HuaweiIdAuthParamsHelper setEmail() {
            return Call<HuaweiIdAuthParamsHelper>("setEmail");
        }
        public HuaweiIdAuthParamsHelper setId() {
            return Call<HuaweiIdAuthParamsHelper>("setId");
        }
        public HuaweiIdAuthParamsHelper setIdToken() {
            return Call<HuaweiIdAuthParamsHelper>("setIdToken");
        }
        public HuaweiIdAuthParamsHelper setProfile() {
            return Call<HuaweiIdAuthParamsHelper>("setProfile");
        }
        public HuaweiIdAuthParamsHelper setShippingAddress() {
            return Call<HuaweiIdAuthParamsHelper>("setShippingAddress");
        }
        public HuaweiIdAuthParamsHelper setMobileNumber() {
            return Call<HuaweiIdAuthParamsHelper>("setMobileNumber");
        }
        public HuaweiIdAuthParamsHelper setIncludeGranted(bool arg0) {
            return Call<HuaweiIdAuthParamsHelper>("setIncludeGranted", arg0);
        }
    }
}