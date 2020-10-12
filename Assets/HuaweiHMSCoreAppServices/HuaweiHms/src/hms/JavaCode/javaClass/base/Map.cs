using UnityEngine;
using System.Collections.Generic;

namespace HuaweiHms
{
    public class Map_Data : IHmsBaseClass{
        public string name => "java.util.Map";
    }
    public class Map :HmsClass<Map_Data>
    {
        public Map (): base() { }

        public Map<K, V> toMap<K, V>()
        {
            var map = new Map<K,V>();
            map.obj = obj;
            return map;
        }
    }
    
    public class Map<K,V> : Map
    {
        public Set<K> keySet()
        {
            return Call<Set<K>>("keySet");
        }

        public V getOrDefault(K key, V value)
        {
            return Call<V>("getOrDefault", key, value);
        }
    }
}