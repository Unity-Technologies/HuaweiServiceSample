using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class CustomCredentialsProvider_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.CustomCredentialsProvider";
    }
    public class CustomCredentialsProvider :HmsClass<CustomCredentialsProvider_Data>
    {
        public CustomCredentialsProvider (): base() { }
        public Task getTokens(bool arg0) {
            return Call<Task>("getTokens", arg0);
        }
    }
}