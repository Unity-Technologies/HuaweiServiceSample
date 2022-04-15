using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.Account
{
    public class HuaweiIdAuthResult_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.support.hwid.result.HuaweiIdAuthResult";
    }
    public class HuaweiIdAuthResult :HmsClass<HuaweiIdAuthResult_Data>
    {
        public HuaweiIdAuthResult (): base() { }
        public AuthHuaweiId getHuaweiId() {
            return Call<AuthHuaweiId>("getHuaweiId");
        }
        public void setAuthHuaweiId(AuthHuaweiId arg0) {
            Call("setAuthHuaweiId", arg0);
        }
        public bool isSuccess() {
            return Call<bool>("isSuccess");
        }
    }
}