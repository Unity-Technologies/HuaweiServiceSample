using UnityEngine;

namespace HuaweiService{
    public interface IHmsBase
    {
        AndroidJavaObject obj{get;set;}
        object param{get;}
    }
}