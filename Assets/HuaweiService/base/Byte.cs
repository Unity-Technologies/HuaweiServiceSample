using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class Byte_Data : IHmsBaseClass{
        public string name => "java.lang.Byte";
    }
    public class Byte :HmsClass<Byte_Data>
    {
        public const int SIZE = 8;
        public const int BYTES = 1;
        public Byte (byte arg0): base(arg0) { }
        public Byte (string arg0): base(arg0) { }
        public Byte (): base() { }
        public byte byteValue() {
            return Call<byte>("byteValue");
        }
    }
}