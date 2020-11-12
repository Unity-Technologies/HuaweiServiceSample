using UnityEngine;
using System.Collections.Generic;

namespace HuaweiHms
{
    public class MessageLocation_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.appmessaging.Location";
    }
    public class MessageLocation :HmsClass<MessageLocation_Data>
    {
        public static MessageLocation BOTTOM => HmsUtil.GetStaticValue<MessageLocation>("BOTTOM");
    
        public static MessageLocation CENTER => HmsUtil.GetStaticValue<MessageLocation>("CENTER");
    
        public MessageLocation (): base() { }
    }
}