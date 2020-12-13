using System.Collections.Generic;
using UnityEngine;

namespace HuaweiService.CloudFunction{
    public class AGConnectFunction_Data : IHmsBaseClass {
        public string name => "com.huawei.agconnect.function.AGConnectFunction";
    }
    public class AGConnectFunction : HmsClass<AGConnectFunction_Data> {
        public static AGConnectFunction getInstance () {
            return CallStatic<AGConnectFunction> ("getInstance");
        }
        public FunctionCallable wrap (string arg0) {
            return Call<FunctionCallable> ("wrap", arg0);
        }
    }
}