using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class PersistableBundle_Data : IHmsBaseClass{
        public string name => "android.os.PersistableBundle";
    }
    public class PersistableBundle :HmsClass<PersistableBundle_Data>
    {
        public PersistableBundle (): base() { }
        public PersistableBundle (int arg0): base(arg0) { }
        public PersistableBundle (PersistableBundle arg0): base(arg0) { }
    }
}