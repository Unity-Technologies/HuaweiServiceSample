using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.appmessage
{
    public class Location_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.appmessaging.Location";
    }
    public class Location :HmsClass<Location_Data>
    {
        public static Location BOTTOM => HmsUtil.GetStaticValue<Location>("BOTTOM");
    
        public static Location CENTER => HmsUtil.GetStaticValue<Location>("CENTER");
    
        public Location (): base() { }
    }
}