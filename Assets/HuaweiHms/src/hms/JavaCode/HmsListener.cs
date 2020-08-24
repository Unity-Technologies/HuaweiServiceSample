using System;
using System.Collections.Generic;
using UnityEngine;

namespace HuaweiHms{
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
    }
    public class HmsListenerManager{
        private const string BUILD_CLASS_NAME = "com.unity.hms.listener.ListenerBuilder";
        private static AndroidJavaClass _listenrBuilder;
        private static AndroidJavaClass listenerBuilder{
            get{
                if(_listenrBuilder == null){
                    _listenrBuilder = new AndroidJavaClass(BUILD_CLASS_NAME);
                }
                return _listenrBuilder;
            }
        }
        public static AndroidJavaObject GetListener(string buildName,AndroidJavaProxy proxy)
        {
            if(buildName == ""){
                return null;
            }
            return listenerBuilder.CallStatic<AndroidJavaObject>(buildName, proxy);
        }
    }
}