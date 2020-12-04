using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class Set_Data : IHmsBaseClass{
        public string name => "java.util.Map";
    }
    public class Set<T> :HmsClass<Set_Data>
    {
        public Set (): base() { }

        public T[] toArray()
        {
            return Call<T[]>("toArray");
        }
    }
}