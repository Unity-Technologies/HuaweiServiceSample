using System.Collections;
using UnityEngine;

using System.Collections.Generic;

namespace HuaweiService
{
    public class List_Data_two:IHmsBaseClass{
        public string name => "java.util.ArrayList";
    }
    public class Lists<E>: HmsClass<List_Data_two>
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
    
        // public virtual E[] toArray() {
        //     var x =  Call<AndroidJavaObject[]>("toArray");
        //     E[] array = new E[x.Length];
        //     array[0].obj = x[0];
        //     return array;
        // }
    
        public virtual AndroidJavaObject[] toArray(AndroidJavaObject[] arg0) {
            return Call<AndroidJavaObject[]>("toArray", arg0);
        }
        
        public int size() {
            return Call<int>("size");
        }
        
        public AndroidJavaObject get(int arg0) {
            return Call<AndroidJavaObject>("get", arg0);
        }

        public IEnumerator GetEnumerator()
        {
            return Call<IEnumerator>("");
        }
    }
}