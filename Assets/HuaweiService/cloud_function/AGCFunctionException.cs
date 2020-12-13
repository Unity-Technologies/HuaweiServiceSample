using UnityEngine;
using System.Collections.Generic;
namespace HuaweiService.CloudFunction
{
    public class AGCFunctionException_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.function.AGCFunctionException";
    }
    public class AGCFunctionException :HmsClass<AGCFunctionException_Data>
    {
        public const int UNKNOW_ERROR_CODE = -1;
        public AGCFunctionException (string arg0, int arg1): base(arg0, arg1) { }
        public AGCFunctionException (): base() { }
        public int getCode() {
            return Call<int>("getCode");
        }
        public string getMessage() {
            return Call<string>("getMessage");
        }
    }
}