using UnityEngine;
using System.Collections.Generic;

namespace HuaweiHms
{
    public class Uri_Data : IHmsBaseClass{
        public string name => "android.net.Uri";
    }
    public class Uri :HmsClass<Uri_Data>
    {
        public Uri (): base() { }
    }
}