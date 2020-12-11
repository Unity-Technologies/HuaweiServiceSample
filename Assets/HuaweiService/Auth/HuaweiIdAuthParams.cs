using UnityEngine;
using System.Collections.Generic;
using HuaweiService;

namespace HuaweiService.Auth
{
    public class HuaweiIdAuthParams_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.support.hwid.request.HuaweiIdAuthParams";
    }
    public class HuaweiIdAuthParams :HmsClass<HuaweiIdAuthParams_Data>
    {
        public HuaweiIdAuthParams (): base() { }

        public static HuaweiIdAuthParams DEFAULT_AUTH_REQUEST_PARAM =>
            HmsUtil.GetStaticValue<HuaweiIdAuthParams>("DEFAULT_AUTH_REQUEST_PARAM");
        public static HuaweiIdAuthParams DEFAULT_AUTH_REQUEST_PARAM_GAME =  HmsUtil.GetStaticValue<HuaweiIdAuthParams>("DEFAULT_AUTH_REQUEST_PARAM_GAME");
        
        public HuaweiIdAuthParams clone() {
            return Call<HuaweiIdAuthParams>("clone");
        }
        public bool equals(AndroidJavaObject arg0) {
            return Call<bool>("equals", arg0);
        }
        public static HuaweiIdAuthParams fromJson(string arg0) {
            return CallStatic<HuaweiIdAuthParams>("fromJson", arg0);
        }
        public static HuaweiIdAuthParams fromJsonObject(JSONObject arg0) {
            return CallStatic<HuaweiIdAuthParams>("fromJsonObject", arg0);
        }
        public JSONObject toJsonObject() {
            return Call<JSONObject>("toJsonObject");
        }
        public void setSignInParams(string arg0) {
            Call("setSignInParams", arg0);
        }
        public int hashCode() {
            return Call<int>("hashCode");
        }
    }
}