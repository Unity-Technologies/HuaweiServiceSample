using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class Integer_Data : IHmsBaseClass{
        public string name => "java.lang.Integer";
    }
    public class Integer :HmsClass<Integer_Data>
    {
        public const int MIN_VALUE = -2147483648;
        public const int MAX_VALUE = 2147483647;
        public const int SIZE = 32;
        public const int BYTES = 4;
        public Integer (string arg0): base(arg0) { }
        public Integer (int arg0): base(arg0) { }
        public Integer (): base() { }
        public int intValue() {
            return Call<int>("intValue");
        }
    }
}