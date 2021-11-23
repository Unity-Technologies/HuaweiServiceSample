using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.credential
{
    public class AccessNetworkManager_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.common.network.AccessNetworkManager";
    }
    public class AccessNetworkManager :HmsClass<AccessNetworkManager_Data>
    {
        public AccessNetworkManager (): base() { }
        public static AccessNetworkManager getInstance() {
            return CallStatic<AccessNetworkManager>("getInstance");
        }
        public void addCallback(AccessNetworkCallback arg0) {
            Call("addCallback", arg0);
        }
        public void setAccessNetwork(bool arg0) {
            Call("setAccessNetwork", arg0);
        }
    }
}