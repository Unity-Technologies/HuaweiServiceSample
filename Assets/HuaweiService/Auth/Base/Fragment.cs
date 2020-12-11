using UnityEngine;
using System.Collections.Generic;
using HuaweiService;

namespace HuaweiService.Auth
{
    public class Fragment_Data : IHmsBaseClass{
        public string name => "android.app.Fragment";
    }
    public class Fragment :HmsClass<Fragment_Data>
    {
        public Fragment (): base() { }
    }
}