using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class URL_Data : IHmsBaseClass{
        public string name => "java.net.URL";
    }
    public class URL :HmsClass<URL_Data>
    {
        public URL (URL arg0, string arg1, URLStreamHandler arg2): base(arg0, arg1, arg2) { }
        public URL (URL arg0, string arg1): base(arg0, arg1) { }
        public URL (string arg0): base(arg0) { }
        public URL (string arg0, string arg1, int arg2, string arg3): base(arg0, arg1, arg2, arg3) { }
        public URL (string arg0, string arg1, string arg2): base(arg0, arg1, arg2) { }
        public URL (string arg0, string arg1, int arg2, string arg3, URLStreamHandler arg4): base(arg0, arg1, arg2, arg3, arg4) { }
        public URL (): base() { }
        public URLConnection openConnection() {
            return Call<URLConnection>("openConnection");
        }
        public URLConnection openConnection(Proxy arg0) {
            return Call<URLConnection>("openConnection", arg0);
        }
    }
}