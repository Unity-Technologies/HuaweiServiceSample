using HuaweiService;
namespace HuaweiService.Auth
{
   
        public class LoginManager_Data : IHmsBaseClass{
            public string name => "com.hw.unity.Agc.Auth.ThirdPartyLogin.LoginManager";
        }

        public class LoginManager : HmsClass<LoginManager_Data>
        {
            public LoginManager (): base() { }

            public static  LoginManager getInstance()
            {
               return CallStatic<LoginManager>("getInstance");
            }
            public void startHWID(OnSuccessListener sucessCallback,OnFailureListener failCallback)
        {
           Call("startHWID",sucessCallback,failCallback);
        }

        public void startHWGame(OnSuccessListener sucessCallback,OnFailureListener failCallback)
        {
            Call("startHWGame",sucessCallback,failCallback);
        }

        public void startGoogle(string client_id,OnSuccessListener successCallback,OnFailureListener failCallback)
        {
            Call("startGoogle",client_id,successCallback,failCallback);
        }

        public void startGooglePlay(string client_id,OnSuccessListener successCallback,OnFailureListener failCallback)
        {
            Call("startGooglePlay",client_id,successCallback,failCallback);
        }

        public void startTwitter(string App_id,string App_secret,OnSuccessListener successCallback,OnFailureListener failCallback)
        {
            Call("startTwitter",App_id,App_secret,successCallback,failCallback);
        }

        public void startWechatLogin(string APP_ID,string APP_SECRET,OnSuccessListener successCallback,OnFailureListener failCallback)
        {
            Call("startWechatLogin",APP_ID,APP_SECRET,successCallback,failCallback);
        }

        public void startQQ(string app_id,OnSuccessListener successCallback,OnFailureListener failCallback)
        {
            Call("startQQ",app_id,successCallback,failCallback);
        }

        public void startFacebook(string APP_ID,OnSuccessListener successCallback,OnFailureListener failCallback)
        {
            Call("startFacebook",APP_ID,successCallback,failCallback);
        }

        public void startWeibo(string app_id, OnSuccessListener successCallback,
            OnFailureListener failCallback)
        {
            Call("startWeibo",app_id,successCallback,failCallback);
        }
    }

}