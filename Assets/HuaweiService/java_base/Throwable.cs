using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class Throwable_Data : IHmsBaseClass{
        public string name => "java.lang.Throwable";
    }
    public class Throwable :HmsClass<Throwable_Data>
    {
        public Throwable (Throwable arg0): base(arg0) { }
        public Throwable (string arg0, Throwable arg1): base(arg0, arg1) { }
        public Throwable (string arg0): base(arg0) { }
        public Throwable (): base() { }
    }
}