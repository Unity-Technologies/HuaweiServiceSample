using System;
using UnityEngine;

namespace HuaweiService
{
    public class HashMap_Data : IHmsBaseClass{
        public string name => "java.util.HashMap";
    }
    public class HashMap :HmsClass<HashMap_Data>
    {
        public HashMap (): base() { }

        public void put(string key, string value)
        {
            IntPtr putMethod = AndroidJNIHelper.GetMethodID(
                obj.GetRawClass(), "put",
                "(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;");
            object[] args = new object[2];

            using (AndroidJavaObject k = new AndroidJavaObject(
                "java.lang.String", key))
            {
                using (AndroidJavaObject v = new AndroidJavaObject(
                    "java.lang.String", value))
                {
                    args[0] = k;
                    args[1] = v;
                    AndroidJNI.CallObjectMethod(obj.GetRawObject(),
                        putMethod, AndroidJNIHelper.CreateJNIArgArray(args));
                }
            }
        }
        
        public void put(string key, int value)
        {
            IntPtr putMethod = AndroidJNIHelper.GetMethodID(
                obj.GetRawClass(), "put",
                "(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;");
            object[] args = new object[2];

            using (AndroidJavaObject k = new AndroidJavaObject(
                "java.lang.String", key))
            {
                using (AndroidJavaObject v = new AndroidJavaObject(
                    "java.lang.Integer", value))
                {
                    args[0] = k;
                    args[1] = v;
                    AndroidJNI.CallObjectMethod(obj.GetRawObject(),
                        putMethod, AndroidJNIHelper.CreateJNIArgArray(args));
                }
            }
        }
        
        public void put(string key, double value)
        {
            IntPtr putMethod = AndroidJNIHelper.GetMethodID(
                obj.GetRawClass(), "put",
                "(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;");
            object[] args = new object[2];

            using (AndroidJavaObject k = new AndroidJavaObject(
                "java.lang.String", key))
            {
                using (AndroidJavaObject v = new AndroidJavaObject(
                    "java.lang.Double", value))
                {
                    args[0] = k;
                    args[1] = v;
                    AndroidJNI.CallObjectMethod(obj.GetRawObject(),
                        putMethod, AndroidJNIHelper.CreateJNIArgArray(args));
                }
            }
        }
    }
}