using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class URLConnection_Data : IHmsBaseClass{
        public string name => "java.net.URLConnection";
    }
    public class URLConnection :HmsClass<URLConnection_Data>
    {
        public URLConnection (): base() { }
    }
}