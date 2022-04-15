using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class Comparator_Data : IHmsBaseClass{
        public string name => "java.util.Comparator";
    }
    public class Comparator :HmsClass<Comparator_Data>
    {
        public Comparator (): base() { }
    }
}