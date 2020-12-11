using System;
using UnityEngine;

namespace HuaweiService.Auth
{
    [System.Serializable] 
    public class HWIDGetBack
    {
        public string Token;

    }
    [System.Serializable] 
    public class HWGameGetBack
    {
        public string PlayerSign;
        public string PlayerId;
        public string DisplayName;
        public string ImageUrl;
        public int PlayerLevel;
        public string SignTs;
    }
    [System.Serializable] 
    public class GoogleGetBack
    {
        public string Token;
    }
    [System.Serializable] 
    public class GooglePlayGetBack
    {
        public string Token;
    }
    [System.Serializable] 
    public class TwitterGetBack
    {
        public string Token;
        public string Secret;
    }
    [System.Serializable] 
    public class WechatGetBack
    {
        public string Token;
        public string OpenId;
    }
    [System.Serializable] 
    public class QQGetBack
    {
        public string Token;
        public string OpenId;
    }
    [System.Serializable] 
    public class FacebookGetBack
    {
        public string Token;
    }
    [System.Serializable] 
    public class WeiboGetBack
    {
        public string Token;
        public string Uid;
    }

    public class JsonAuthorizeData<T>
    {
        public static T FromJson(string str)
        {
            return JsonUtility.FromJson<T>(str);
        }
    }
  
}