using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class URI_Data : IHmsBaseClass{
        public string name => "java.net.URI";
    }
    public class URI :HmsClass<URI_Data>
    {
        public URI (string arg0, string arg1, string arg2): base(arg0, arg1, arg2) { }
        public URI (string arg0, string arg1, string arg2, string arg3): base(arg0, arg1, arg2, arg3) { }
        public URI (string arg0, string arg1, string arg2, string arg3, string arg4): base(arg0, arg1, arg2, arg3, arg4) { }
        public URI (string arg0): base(arg0) { }
        public URI (string arg0, string arg1, string arg2, int arg3, string arg4, string arg5, string arg6): base(arg0, arg1, arg2, arg3, arg4, arg5, arg6) { }
        public URI (): base() { }
    }
}