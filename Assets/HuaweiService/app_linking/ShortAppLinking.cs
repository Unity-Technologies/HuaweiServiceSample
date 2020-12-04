using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.AppLinking
{
    public class ShortAppLinking_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.applinking.ShortAppLinking";
    }
    public class ShortAppLinking :HmsClass<ShortAppLinking_Data>
    {
        public ShortAppLinking (): base() { }
        public Uri getShortUrl() {
            return Call<Uri>("getShortUrl");
        }
        public Uri getTestUrl() {
            return Call<Uri>("getTestUrl");
        }
    
        public class LENGTH_Data : IHmsBaseClass{
            public string name => "com.huawei.agconnect.applinking.ShortAppLinking$LENGTH";
        }
        public class LENGTH :HmsClass<LENGTH_Data>
        {
            public static LENGTH SHORT => HmsUtil.GetStaticValue<LENGTH>("SHORT");
        
            public static LENGTH LONG => HmsUtil.GetStaticValue<LENGTH>("LONG");
        
            public LENGTH (): base() { }
        }
    }
}