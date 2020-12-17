using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class Long_Data : IHmsBaseClass{
        public string name => "java.lang.Long";
    }
    public class Long :HmsClass<Long_Data>
    {
        public const int SIZE = 64;
        public const int BYTES = 8;
        public Long (string arg0): base(arg0) { }
        public Long (long arg0): base(arg0) { }
        public Long (): base() { }
        public long longValue() {
            return Call<long>("longValue");
        }
    }
}