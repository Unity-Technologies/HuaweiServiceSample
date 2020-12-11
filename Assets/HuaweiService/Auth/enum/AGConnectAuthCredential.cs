using UnityEngine;
using System.Collections.Generic;
using HuaweiService;

namespace HuaweiService.Auth
{
    public class AGConnectAuthCredential_Data : IHmsBaseClass
    {
        public string name => "com.huawei.agconnect.auth.AGConnectAuthCredential";

    }
    
    public class AGConnectAuthCredential: HmsClass<AGConnectAuthCredential_Data>
    {
    
        public static int Anonymous = 0;
        public static int HMS_Provider = 1;
        public static int Facebook_Provider = 2;
        public static int Twitter_Provider = 3;
        public static int WeiXin_Provider = 4;
        public static int HWGame_Provider = 5;
        public static int QQ_Provider = 6;
        public static int WeiBo_Provider = 7;
        public static int Google_Provider = 8;
        public static int GoogleGame_Provider = 9;
        public static int SelfBuild_Provider = 10;
        public static int Phone_Provider = 11;
        public static int Email_Provider = 12;
        
        public int getProvider() {
            return Call<int>("getProvider");
        }
    }
}