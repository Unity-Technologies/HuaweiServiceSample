using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class Double_Data : IHmsBaseClass{
        public string name => "java.lang.Double";
    }
    public class Double :HmsClass<Double_Data>
    {
        public const int MAX_EXPONENT = 1023;
        public const int MIN_EXPONENT = -1022;
        public const int SIZE = 64;
        public const int BYTES = 8;
        public Double (double arg0): base(arg0) { }
        public Double (string arg0): base(arg0) { }
        public Double (): base() { }
        public double doubleValue() {
            return Call<double>("doubleValue");
        }
    }
}