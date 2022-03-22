using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class HashSet_Data : IHmsBaseClass{
        public string name => "java.util.HashSet";
    }
    public class HashSet<T> :HmsClass<HashSet_Data>
    {
        public HashSet (int arg0): base(arg0) { }
        public HashSet (int arg0, float arg1): base(arg0, arg1) { }
        public HashSet (Collection arg0): base(arg0) { }
        public HashSet (): base() { }
        public bool add (T arg0) {
            return Call<bool>("add", arg0);
        }
    }
}