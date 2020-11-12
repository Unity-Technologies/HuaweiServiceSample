using System;
using UnityEngine;

namespace HuaweiHms{
    public interface IHmsBaseClass
    {
        string name{get;}
    }
    
    public abstract class HmsClass<T> : IHmsBase where T:IHmsBaseClass, new(){
        private AndroidJavaObject _obj;
        private static string _name = "";
        public static string name{
            get
            {
                return _name == ""?_name = (new T()).name:_name;
            }
        }
        public object param{get{return obj;}}
        private object[] construcArgs;
        public HmsClass(params object[] args)
        {
            construcArgs = args;
        }
        public AndroidJavaObject obj{
            get{
                return _obj == null?_obj = new AndroidJavaObject(name,HmsUtil.TransferParams(construcArgs)):_obj;
            }
            set{
                _obj = value;
            }
        }   
        public static AndroidJavaClass _clz;
        public static AndroidJavaClass clz{
            get{
                return _clz == null?_clz = new AndroidJavaClass(name):_clz;
            } 
        }
        public void Call(string name, params object[] args)
        {
            obj.Call(name, HmsUtil.TransferParams(args));
        }
        public K Call<K>(string name, params object[] args)
        {    
            Type type = typeof(K);
            bool isBase = typeof(IHmsBase).IsAssignableFrom(type);
            if(isBase){
                AndroidJavaObject robj = obj.Call<AndroidJavaObject>(name, HmsUtil.TransferParams(args));
                IHmsBase ret = (IHmsBase)Activator.CreateInstance(type);
                ret.obj = robj;
                return (K)ret;
            }
            return obj.Call<K>(name, HmsUtil.TransferParams(args));
        }
        public static void CallStatic(string name, params object[] args)
        {
            clz.CallStatic(name, HmsUtil.TransferParams(args));
        }
        public static K CallStatic<K>(string name, params object[] args)
        {
            Type type = typeof(K);
            bool isBase = typeof(IHmsBase).IsAssignableFrom(type);
            if(isBase){
                AndroidJavaObject robj = clz.CallStatic<AndroidJavaObject>(name, HmsUtil.TransferParams(args));
                IHmsBase ret = (IHmsBase)Activator.CreateInstance(type);
                ret.obj = robj;
                return (K)ret;
            }
            return clz.CallStatic<K>(name, HmsUtil.TransferParams(args));
        }

        public T toType<T>() where T:IHmsBase,new()
        {
            var map = new T();
            map.obj = obj;
            return map;
        }
        
        public static bool operator ==(HmsClass<T> a, HmsClass<T> b) 
        {
            if(Equals(a, null))
            {
                return Equals(b, null);
            }
            return a.Equals(b);
        }
    
        public static bool operator !=(HmsClass<T> a, HmsClass<T> b) 
        {
            return !(a==b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Call<bool>("equals", obj);
        }

        public override string ToString()
        {
            return Call<string>("toString");
        }
    }
}