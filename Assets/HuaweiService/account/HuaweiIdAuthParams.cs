using UnityEngine;
using System.Collections.Generic;
using HuaweiService.Auth;

namespace HuaweiService.Account
{
    public class HuaweiIdAuthParams_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.support.hwid.request.HuaweiIdAuthParams";
    }
    public class HuaweiIdAuthParams :HmsClass<HuaweiIdAuthParams_Data>
    {
        public static HuaweiIdAuthParams DEFAULT_AUTH_REQUEST_PARAM => HmsUtil.GetStaticValue<HuaweiIdAuthParams>("DEFAULT_AUTH_REQUEST_PARAM");
    
        public static HuaweiIdAuthParams DEFAULT_AUTH_REQUEST_PARAM_GAME => HmsUtil.GetStaticValue<HuaweiIdAuthParams>("DEFAULT_AUTH_REQUEST_PARAM_GAME");
    
        public static Parcelable.Creator CREATOR => HmsUtil.GetStaticValue<Parcelable.Creator>("CREATOR");
    
        public HuaweiIdAuthParams (): base() { }
        public List getRequestScopeList() {
            return Call<List>("getRequestScopeList");
        }
        public int hashCode() {
            return Call<int>("hashCode");
        }
        public bool equals(AndroidJavaObject arg0) {
            return Call<bool>("equals", arg0);
        }
    }
}