using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class Map_Data : IHmsBaseClass{
        public string name => "java.util.Map";
    }
    public class Map :HmsClass<Map_Data>
    {
        public Map (): base() { }

        public Set<string> keySet()
        {
            return Call<Set<string>>("keySet");
        }
        
        public string getOrDefault(string key, string value)
        {
            return Call<string>("getOrDefault", key, value);
        }
    }
}