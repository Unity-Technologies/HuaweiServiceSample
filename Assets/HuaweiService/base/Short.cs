using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class Short_Data : IHmsBaseClass{
        public string name => "java.lang.Short";
    }
    public class Short :HmsClass<Short_Data>
    {
        public const int SIZE = 16;
        public const int BYTES = 2;
        public Short (short arg0): base(arg0) { }
        public Short (string arg0): base(arg0) { }
        public Short (): base() { }
        public short shortValue() {
            return Call<short>("shortValue");
        }
    }
}