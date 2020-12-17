using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.CloudDB
{
    public class ListenerHandler_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.cloud.database.ListenerHandler";
    }
    public class ListenerHandler :HmsClass<ListenerHandler_Data>
    {
        public ListenerHandler (): base() { }
        public void remove() {
            Call("remove");
        }
    }
}