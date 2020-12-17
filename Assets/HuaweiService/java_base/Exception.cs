using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class Exception_Data : IHmsBaseClass{
        public string name => "java.lang.Exception";
    }
    public class Exception :HmsClass<Exception_Data>
    {
        public Exception (Throwable arg0): base(arg0) { }
        public Exception (string arg0, Throwable arg1): base(arg0, arg1) { }
        public Exception (string arg0): base(arg0) { }
        public Exception (): base() { }
        public string toString() {
            return Call<string>("toString");
        }
    }
}