using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class Date_Data : IHmsBaseClass{
        public string name => "java.util.Date";
    }
    public class Date :HmsClass<Date_Data>
    {
        public Date (string arg0): base(arg0) { }
        public Date (int arg0, int arg1, int arg2, int arg3, int arg4, int arg5): base(arg0, arg1, arg2, arg3, arg4, arg5) { }
        public Date (int arg0, int arg1, int arg2, int arg3, int arg4): base(arg0, arg1, arg2, arg3, arg4) { }
        public Date (): base() { }
        public Date (long arg0): base(arg0) { }
        public Date (int arg0, int arg1, int arg2): base(arg0, arg1, arg2) { }
    }
}