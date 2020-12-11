using UnityEngine;
using HuaweiService;

namespace HuaweiService.Auth
{

    public class LoginService
    {
        private static AndroidJavaObject activity = Common.GetActivity();

        public static void startHWID(OnSuccessListener sucessCallback,OnFailureListener failCallback)
        {
            activity.Call("startHWID",sucessCallback,failCallback);
        }

        public static void startHWGame(OnSuccessListener sucessCallback,OnFailureListener failCallback)
        {
            activity.Call("startHWGame",sucessCallback,failCallback);
        }

        public static void startGoogle(string client_id,OnSuccessListener successCallback,OnFailureListener failCallback)
        {
            activity.Call("startGoogle",client_id,successCallback,failCallback);
        }

        public static void startGooglePlay(string client_id,OnSuccessListener successCallback,OnFailureListener failCallback)
        {
            activity.Call("startGooglePlay",client_id,successCallback,failCallback);
        }

        public static void startTwitter(string App_id,string App_secret,OnSuccessListener successCallback,OnFailureListener failCallback)
        {
            activity.Call("startTwitter",App_id,App_secret,successCallback,failCallback);
        }

        public static void startWechatLogin(string APP_ID,string APP_SECRET,OnSuccessListener successCallback,OnFailureListener failCallback)
        {
            activity.Call("startWechatLogin",APP_ID,APP_SECRET,successCallback,failCallback);
        }

        public static void startQQ(string app_id,OnSuccessListener successCallback,OnFailureListener failCallback)
        {
            activity.Call("startQQ",app_id,successCallback,failCallback);
        }

        public static void startFacebook(string APP_ID,OnSuccessListener successCallback,OnFailureListener failCallback)
        {
            activity.Call("startFacebook",APP_ID,successCallback,failCallback);
        }

        public static void startWeibo(string app_id, OnSuccessListener successCallback,
            OnFailureListener failCallback)
        {
            activity.Call("startWeibo",app_id,successCallback,failCallback);
        }
    }
}