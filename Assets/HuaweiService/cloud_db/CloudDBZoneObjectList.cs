using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.CloudDB
{
    public class CloudDBZoneObjectList_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.cloud.database.CloudDBZoneObjectList";
    }
    public class CloudDBZoneObjectList :HmsClass<CloudDBZoneObjectList_Data>
    {
        public CloudDBZoneObjectList (): base() { }
        public int size() {
            return Call<int>("size");
        }
        public CloudDBZoneObject get(int index) {
            return Call<CloudDBZoneObject>("get", index);
        }
        public CloudDBZoneObject next() {
            return Call<CloudDBZoneObject>("next");
        }
        public bool hasNext() {
            return Call<bool>("hasNext");
        }
    }

    public class CloudDBZoneObjectList<T> :CloudDBZoneObjectList where T : IDatabaseModel,new()
    {
        public int size() {
            return Call<int>("size");
        }
        public T get(int arg0) {
            T t = new T();
            t.SetObj(base.get(arg0).obj);
            return t;
        }
        public T next() {
            T t = new T();
            t.SetObj(base.next().obj);
            return t;
        }
        public bool hasNext() {
            return Call<bool>("hasNext");
        }
    }
}