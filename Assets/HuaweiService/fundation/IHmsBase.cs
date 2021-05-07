using UnityEngine;

namespace HuaweiService{
    public interface IHmsBase
    {
        AndroidJavaClass javaClass { get; }
        AndroidJavaObject obj{get;set;}
        object param{get;}
    }
}