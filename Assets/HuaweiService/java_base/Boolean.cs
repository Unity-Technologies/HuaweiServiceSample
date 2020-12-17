using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class Boolean_Data : IHmsBaseClass{
        public string name => "java.lang.Boolean";
    }
    public class Boolean :HmsClass<Boolean_Data>
    {
        public Boolean (bool arg0): base(arg0) { }
        public Boolean (string arg0): base(arg0) { }
        public Boolean (): base() { }
        public bool booleanValue() {
            return Call<bool>("booleanValue");
        }
    }
}