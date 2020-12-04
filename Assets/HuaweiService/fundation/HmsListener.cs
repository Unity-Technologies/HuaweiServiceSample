using System;
using System.Collections.Generic;
using UnityEngine;

namespace HuaweiService{
    public interface IHmsBaseListener
    {
        string name{get;}
        string buildName{get;}
    }
    public class HmsListener<T> : AndroidJavaProxy,IHmsBase where T:IHmsBaseListener,new()
    {
        private static string _name = "";
        private static string _buildName = "";
        public static string name{
            get{
                return _name == ""?_name = (new T()).name:_name;
            }
        }
        public static string buildName{
            get{
                return _buildName == ""?_buildName = (new T()).buildName:_buildName;
            }
        }
        public AndroidJavaObject _obj;
        public AndroidJavaObject obj{
            get{
                return _obj == null?_obj = HmsListenerManager.GetListener(buildName,this):_obj;
            }
            set{
                _obj = value;
            }
        }
        public HmsListener() : base(name)
        {
            
        }
        public object param{ 
            get{ 
                if(obj!=null){
                    return obj;
                }
                return this;
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
    }
    public class HmsListenerManager{
        private const string BUILD_CLASS_NAME = "com.unity.hms.listener.{0}";

        private static Dictionary<string, AndroidJavaClass> _listenerBuilders = new Dictionary<string, AndroidJavaClass>();

        private static AndroidJavaClass getBuilder(string buildName)
        {
            if (!_listenerBuilders.ContainsKey(buildName))
            {
                var builder = new AndroidJavaClass(String.Format(BUILD_CLASS_NAME, buildName));
                _listenerBuilders.Add(buildName, builder);
            }
            return _listenerBuilders[buildName];
        }
        
        public static AndroidJavaObject GetListener(string buildName,AndroidJavaProxy proxy)
        {
            if(buildName == ""){
                return null;
            }
            return getBuilder(buildName).CallStatic<AndroidJavaObject>(buildName, proxy);
        }
    }
}