using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class InputStream_Data : IHmsBaseClass{
        public string name => "java.io.InputStream";
    }
    public class InputStream :HmsClass<InputStream_Data>
    {
        public InputStream (): base() { }
    }
}