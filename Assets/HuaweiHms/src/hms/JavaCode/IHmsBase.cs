using UnityEngine;

namespace HuaweiHms{
    public interface IHmsBase
    {
        AndroidJavaObject obj{get;set;}
        object param{get;}
    }
}