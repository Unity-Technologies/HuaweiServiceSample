using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class List_Data:IHmsBaseClass{
        public string name => "java.util.ArrayList";
    }
    public class List: HmsClass<List_Data>
    {
        public virtual bool add(AndroidJavaObject arg0) {
            return Call<bool>("add", arg0);
        }
        public virtual bool add(string arg0) {
            return Call<bool>("add", arg0);
        }
    
        public virtual void add(int arg0, AndroidJavaObject arg1) {
            Call("add", arg0, arg1);
        }
    
        public virtual AndroidJavaObject[] toArray() {
            return Call<AndroidJavaObject[]>("toArray");
        }
    
        public virtual AndroidJavaObject[] toArray(AndroidJavaObject[] arg0) {
            return Call<AndroidJavaObject[]>("toArray", arg0);
        }
    }
}