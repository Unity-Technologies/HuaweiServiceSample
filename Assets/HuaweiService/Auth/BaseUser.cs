using UnityEngine;
using System.Collections.Generic;
using HuaweiService;

namespace HuaweiService.Auth
{
    public class BaseUser_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.auth.BaseUser";
    }
    public class BaseUser :HmsClass<BaseUser_Data>
    {
        public BaseUser (): base() { }
        public string getPassword() {
            return Call<string>("getPassword");
        }
        public string getVerifyCode() {
            return Call<string>("getVerifyCode");
        }
    }
}