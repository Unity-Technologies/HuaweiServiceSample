using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class Proxy_Data : IHmsBaseClass{
        public string name => "java.net.Proxy";
    }
    public class Proxy :HmsClass<Proxy_Data>
    {
        public Proxy (Type arg0, SocketAddress arg1): base(arg0, arg1) { }
        public Proxy (): base() { }
    
        public class Type_Data : IHmsBaseClass{
            public string name => "java.net.Proxy$Type";
        }
        public class Type :HmsClass<Type_Data>
        {
            public static Type DIRECT => HmsUtil.GetStaticValue<Type>("DIRECT");
        
            public static Type HTTP => HmsUtil.GetStaticValue<Type>("HTTP");
        
            public static Type SOCKS => HmsUtil.GetStaticValue<Type>("SOCKS");
        
            public Type (): base() { }
        }
    }
}