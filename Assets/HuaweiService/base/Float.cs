using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class Float_Data : IHmsBaseClass{
        public string name => "java.lang.Float";
    }
    public class Float :HmsClass<Float_Data>
    {
        public const int MAX_EXPONENT = 127;
        public const int MIN_EXPONENT = -126;
        public const int SIZE = 32;
        public const int BYTES = 4;
        public Float (string arg0): base(arg0) { }
        public Float (double arg0): base(arg0) { }
        public Float (float arg0): base(arg0) { }
        public Float (): base() { }
        public float floatValue() {
            return Call<float>("floatValue");
        }
    }
}