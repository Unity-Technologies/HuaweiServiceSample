using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.CloudFunction
{
    public class FunctionResult_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.function.FunctionResult";
    }
    public class FunctionResult :HmsClass<FunctionResult_Data>
    {
        public FunctionResult (): base() { }
        public T getValue<T>(T arg0) {
            var jsonString = Call<string>("getValue");
            return JsonSerializer.FromJson<T>(jsonString);
        }
        public string getValue() {
            return Call<string>("getValue");
        }
    }
}