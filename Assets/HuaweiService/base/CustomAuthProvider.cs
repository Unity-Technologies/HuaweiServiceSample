using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class CustomAuthProvider_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.CustomAuthProvider";
    }
    public class CustomAuthProvider :HmsClass<CustomAuthProvider_Data>
    {
        public CustomAuthProvider (): base() { }
        public Task getTokens(bool arg0) {
            return Call<Task>("getTokens", arg0);
        }
    }
}