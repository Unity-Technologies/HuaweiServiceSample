using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class SocketAddress_Data : IHmsBaseClass{
        public string name => "java.net.SocketAddress";
    }
    public class SocketAddress :HmsClass<SocketAddress_Data>
    {
        public SocketAddress (): base() { }
    }
}