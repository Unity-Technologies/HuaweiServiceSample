using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class ClassLoader_Data : IHmsBaseClass{
        public string name => "java.lang.ClassLoader";
    }
    public class ClassLoader :HmsClass<ClassLoader_Data>
    {
        public ClassLoader (): base() { }
    }
}