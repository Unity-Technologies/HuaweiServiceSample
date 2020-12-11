using UnityEngine;
using System.Collections.Generic;
using HuaweiService;

namespace HuaweiService.Auth
{
    public class Locale_Data : IHmsBaseClass{
        public string name => "java.util.Locale";
    }
    public class Locale :HmsClass<Locale_Data>
    {
        public static Locale CHINA => HmsUtil.GetStaticValue<Locale>("CHINA");
        public Locale (string arg0): base(arg0) { }
        public Locale (string arg0, string arg1): base(arg0, arg1) { }
        public Locale (string arg0, string arg1, string arg2): base(arg0, arg1, arg2) { }
        public Locale (): base() { }
    }
}