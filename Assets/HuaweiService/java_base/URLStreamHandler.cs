using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class URLStreamHandler_Data : IHmsBaseClass{
        public string name => "java.net.URLStreamHandler";
    }
    public class URLStreamHandler :HmsClass<URLStreamHandler_Data>
    {
        public URLStreamHandler (): base() { }
    }
}