using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class Class_Data : IHmsBaseClass{
        public string name => "java.lang.Class";
    }
    public class Class :HmsClass<Class_Data>
    {
        public Class (): base() { }
    }
}