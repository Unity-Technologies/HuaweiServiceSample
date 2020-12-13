using System.Collections.Generic;
using UnityEngine;

namespace HuaweiService.CloudFunction
{
    public class FunctionCallable_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.function.FunctionCallable";
    }
    public class FunctionCallable : HmsClass<FunctionCallable_Data> {
        private FunctionWrapper wrapper;
        public FunctionCallable () : base () {
            wrapper = new FunctionWrapper ();
        }
        public Task call () {
            return Call<Task> ("call");
        }
        public Task call<T> (T arg0) {
            var json = JsonSerializer.ToJson (arg0);
            var node = wrapper.jsonToMap (json);
            
            return Call<Task> ("call", node);
        }
        public long getTimeout () {
            return Call<long> ("getTimeout");
        }
        public void setTimeout (long arg0, TimeUnit arg1) {
            Call ("setTimeout", arg0, arg1);
        }
        public FunctionCallable clone (long arg0, TimeUnit arg1) {
            return Call<FunctionCallable> ("clone", arg0, arg1);
        }
    }

    public class FunctionWrapper_Data : IHmsBaseClass {
        public string name => "com.huawei.unity.function.FunctionWrapper";
    }
    public class FunctionWrapper : HmsClass<FunctionWrapper_Data> {
        public FunctionWrapper () : base () { }

        public AndroidJavaObject jsonToMap (string arg0) {
            return Call<AndroidJavaObject> ("jsonToMap", arg0);
        }
    }
}