using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.push
{
    public class BaseException_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.push.BaseException";
    }
    public class BaseException :HmsClass<BaseException_Data>
    {
        public BaseException (int arg0): base(arg0) { }
        public BaseException (): base() { }
        public int getErrorCode() {
            return Call<int>("getErrorCode");
        }
        public string getMessage() {
            return Call<string>("getMessage");
        }
    }
}