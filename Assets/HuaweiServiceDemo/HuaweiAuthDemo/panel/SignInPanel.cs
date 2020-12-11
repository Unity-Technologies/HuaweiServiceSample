using HuaweiAuthDemo;
using HuaweiService;
using HuaweiService.Auth;
using UnityEngine;
using UnityEngine.UI;

namespace HuaweiAuthDemo
{
    public class SignInPanel : AbstractPanel
    {
        [SerializeField] private Button phoneLogin = default;

        [SerializeField] private Button EmailLogin = default;

        [SerializeField] private Button HWIDLogin = default;

        [SerializeField] private Button HWIDGmaeLogin = default;

        [SerializeField] private Button GOOGLELogin = default;

        [SerializeField] private Button GOOGLEPLAYLogin = default;

        [SerializeField] private Button TWITTERLogin = default;

        [SerializeField] private Button WechatLogin = default;

        [SerializeField] private Button QQLogin = default;

        [SerializeField] private Button FaceBookLogin = default;


        [SerializeField] private Button WeiboLogin = default;
        
        [SerializeField] private Button AnonymousLogin = default;
        [SerializeField] private Button LogOut = default;

        [SerializeField] private Button self_owner;
        

        // Start is called before the first frame update

        private void FixedUpdate()
        {
            BuildAGConnectAuthCredentialList();
        }

        public void Start()
        {
           haveCurrentUser(this);
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
                    PanelController.popupinstance.ShowInfo("Login in successfully");
                    PanelController.userInfo.ParentPanel = this;
                    PanelController.getInstance().OpenPanel(PanelController.userInfo);
                })).addOnFailureListener(new HuaweiOnFailureListener((e
                ) =>
                {
                    Error error=new Error();
                    error.message = e.toString();
                    PanelController.popupinstance.ShowError(error);
                    
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
            PanelController.getInstance()
                .OpenPanel(PanelController.getInstance().GetComponentInChildren<DetailLogin>());
        }
        
    }
}
