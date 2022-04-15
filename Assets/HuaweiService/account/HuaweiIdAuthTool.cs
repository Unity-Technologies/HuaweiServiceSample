using UnityEngine;
using System.Collections.Generic;
using HuaweiService.Auth;

namespace HuaweiService.Account
{
    public class HuaweiIdAuthTool_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.support.hwid.tools.HuaweiIdAuthTool";
    }
    public class HuaweiIdAuthTool :HmsClass<HuaweiIdAuthTool_Data>
    {
        public HuaweiIdAuthTool (): base() { }
        public static void deleteAuthInfo(Activity arg0, string arg1) {
            CallStatic("deleteAuthInfo", arg0, arg1);
        }
        public static void deleteAuthInfo(Context arg0, string arg1) {
            CallStatic("deleteAuthInfo", arg0, arg1);
        }
        public static string requestUnionId(Context arg0, string arg1) {
            return CallStatic<string>("requestUnionId", arg0, arg1);
        }
        public static string requestUnionId(Activity arg0, string arg1) {
            return CallStatic<string>("requestUnionId", arg0, arg1);
        }
        public static string requestAccessToken(Activity arg0, string arg1, List arg2) {
            return CallStatic<string>("requestAccessToken", arg0, arg1, arg2);
        }
        public static string requestAccessToken(Activity arg0, Auth.Account arg1, List arg2) {
            return CallStatic<string>("requestAccessToken", arg0, arg1, arg2);
        }
        public static string requestAccessToken(Context arg0, Auth.Account arg1, List arg2, Bundle arg3) {
            return CallStatic<string>("requestAccessToken", arg0, arg1, arg2, arg3);
        }
        public static string requestAccessToken(Activity arg0, Auth.Account arg1, List arg2, Bundle arg3) {
            return CallStatic<string>("requestAccessToken", arg0, arg1, arg2, arg3);
        }
        public static string requestAccessToken(Context arg0, string arg1, List arg2, Bundle arg3) {
            return CallStatic<string>("requestAccessToken", arg0, arg1, arg2, arg3);
        }
        public static string requestAccessToken(Activity arg0, string arg1, List arg2, Bundle arg3) {
            return CallStatic<string>("requestAccessToken", arg0, arg1, arg2, arg3);
        }
        public static string requestAccessToken(Context arg0, string arg1, List arg2) {
            return CallStatic<string>("requestAccessToken", arg0, arg1, arg2);
        }
        public static string requestAccessToken(Context arg0, Auth.Account arg1, List arg2) {
            return CallStatic<string>("requestAccessToken", arg0, arg1, arg2);
        }
    }
}