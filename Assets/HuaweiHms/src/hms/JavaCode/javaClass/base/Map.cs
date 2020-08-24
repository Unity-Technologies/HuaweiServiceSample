using UnityEngine;
using System.Collections.Generic;

namespace HuaweiHms
{
    public class Map_Data : IHmsBaseClass{
        public string name => "java.util.Map";
    }
    public class Map :HmsClass<Map_Data>
    {
        public Map (): base() { }
    }
}