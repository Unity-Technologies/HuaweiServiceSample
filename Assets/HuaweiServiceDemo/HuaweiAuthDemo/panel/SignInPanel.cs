using HuaweiAuthDemo;
using HuaweiService;
using HuaweiService.Auth;
using UnityEngine;
using UnityEngine.UI;

namespace HuaweiAuthDemo
{
    public class SignInPanel : AbstractPanel
    {
         public Button phoneLogin = default;

         public Button EmailLogin = default;

         public Button HWIDLogin = default;

         public Button HWIDGmaeLogin = default;

         public Button GOOGLELogin = default;

         public Button GOOGLEPLAYLogin = default;

         public Button TWITTERLogin = default;

         public Button WechatLogin = default;

         public Button QQLogin = default;

         public Button FaceBookLogin = default;


         public Button WeiboLogin = default;
        
         public Button AnonymousLogin = default;
         public Button LogOut = default;

         public Button self_owner;
        

        // Start is called before the first frame update
        

        public void Start()
        {
            haveCurrentUser(this);
           BuildAGConnectAuthCredentialList();
        }

        public void BuildAGConnectAuthCredentialList()
        {
            phoneLogin.onClick.RemoveAllListeners();
            phoneLogin.onClick.AddListener(() => OnPhoneLoginClicked());

            EmailLogin.onClick.RemoveAllListeners();
            EmailLogin.onClick.AddListener(() => OnEmailLoginClicked());

            HWIDLogin.onClick.AddListener(() => OnLoginClicked(AGConnectAuthCredential.HMS_Provider));
            HWIDGmaeLogin.onClick.AddListener(() => OnLoginClicked(AGConnectAuthCredential.HWGame_Provider));

            GOOGLELogin.onClick.AddListener(() => OnLoginClicked(AGConnectAuthCredential.Google_Provider));
            GOOGLEPLAYLogin.onClick.AddListener(() => OnLoginClicked(AGConnectAuthCredential.GoogleGame_Provider));

            TWITTERLogin.onClick.AddListener(() => OnLoginClicked(AGConnectAuthCredential.Twitter_Provider));
            WechatLogin.onClick.AddListener(() => OnLoginClicked(AGConnectAuthCredential.WeiXin_Provider));

            QQLogin.onClick.AddListener(() => OnLoginClicked(AGConnectAuthCredential.QQ_Provider));

            FaceBookLogin.onClick.AddListener(() => OnLoginClicked(AGConnectAuthCredential.Facebook_Provider));
            WeiboLogin.onClick.AddListener(() => OnLoginClicked(AGConnectAuthCredential.WeiBo_Provider));
            AnonymousLogin.onClick.AddListener(() =>
                AnonymousLoginClick());
            self_owner.onClick.AddListener(()=>OnLoginClicked(AGConnectAuthCredential.SelfBuild_Provider));
            
            LogOut.onClick.AddListener(()=>LogOutClick());
            

        }

        public void AnonymousLoginClick()
        {
            AGConnectAuth.getInstance().signInAnonymously()
                .addOnSuccessListener(new HuaweiOnsuccessListener<SignInResult>((signresult) =>
                {
                    UnityMainThread.instance.AddJob(() =>
                    {
                        PanelController.userInfo.ParentPanel = this;
                        PanelController.getInstance().OpenPanel(PanelController.userInfo);
                    });
                })).addOnFailureListener(new HuaweiOnFailureListener((e
                ) =>
                {
                    Error error = new Error();
                    UnityMainThread.instance.AddJob(() =>
                    {
                        error.message = e.toString();
                        PanelController.popupinstance.ShowError(error);
                    });

                }));
        }
        

        public void OnPhoneLoginClicked()
        {
            PanelController.getInstance()
                .OpenPanel(PanelController.getInstance().GetComponentInChildren<PhoneLoginNPanel>());

        }

        public void OnEmailLoginClicked()
        {
            PanelController.getInstance()
                .OpenPanel(PanelController.getInstance().GetComponentInChildren<EmailSignInPanel>());
        }

        public void OnLoginClicked(int provider)
        {
            DetailLogin.Provider = provider;
            PanelController.getInstance().GetComponentInChildren<DetailLogin>().ParentPanel = this;
            PanelController.getInstance()
                .OpenPanel(PanelController.getInstance().GetComponentInChildren<DetailLogin>());
        }
        
    }
}
