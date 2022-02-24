using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.Account
{
    public class NetworkTool_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.support.hwid.tools.NetworkTool";
    }
    public class NetworkTool :HmsClass<NetworkTool_Data>
    {
        public NetworkTool (): base() { }
        public static string buildNetworkUrl(string arg0, bool arg1) {
            return CallStatic<string>("buildNetworkUrl", arg0, arg1);
        }
        public static string buildNetworkCookie(string arg0, string arg1, string arg2, string arg3, bool arg4, bool arg5, Long arg6) {
            return CallStatic<string>("buildNetworkCookie", arg0, arg1, arg2, arg3, arg4, arg5, arg6);
        }
    }
}