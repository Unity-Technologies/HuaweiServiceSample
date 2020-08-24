using UnityEngine;
using System.Collections.Generic;

namespace HuaweiHms
{
    public class ConsentStatus_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.ads.consent.constant.ConsentStatus";
    }
    public class ConsentStatus :HmsClass<ConsentStatus_Data>
    {
        public ConsentStatus (): base() { }
        private static Dictionary<string, ConsentStatus> maps = new Dictionary<string, ConsentStatus>();
        private static ConsentStatus GetEnum(string name)
        {
            if (!maps.ContainsKey(name))
            {
                var obj = clz.GetStatic<AndroidJavaObject>(name);
                maps.Add(name,HmsUtil.GetHmsBase<ConsentStatus>(obj));
            }
            return maps[name];
        }
        public static ConsentStatus PERSONALIZED => GetEnum("PERSONALIZED");
        public static ConsentStatus NON_PERSONALIZED => GetEnum("NON_PERSONALIZED");
        public static ConsentStatus UNKNOWN => GetEnum("UNKNOWN");

        public int getValue() {
            return Call<int>("getValue");
        }
        public static ConsentStatus forValue(int arg0) {
            return CallStatic<ConsentStatus>("forValue", arg0);
        }
        public static bool operator ==(ConsentStatus a, ConsentStatus b)
        {
            if(Equals(a, null))
            {
               return Equals(b, null);
            }
            return a.Equals(b);
        }
    
        public static bool operator !=(ConsentStatus a, ConsentStatus b)
        {
            return !(a==b);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return Call<bool>("equals", obj);
        }
    }
}