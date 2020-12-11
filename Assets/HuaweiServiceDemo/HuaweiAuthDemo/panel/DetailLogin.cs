
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using HuaweiAuthDemo;
using HuaweiService;
using HuaweiService.Auth;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Exception = System.Exception;


namespace HuaweiAuthDemo
{
    public class DetailLogin : AbstractPanel
    {
        public static int Provider;
        public static string LINK = "link";
        public static string LOGIN = "login";
        public Button Link;
        public Button UnLink;
        public Button Login;

        public static Text infoText;

        void Start()
        {
            var texts=GetComponentsInChildren<Text>();
            foreach (var text in texts)
            {
                if (text.name == "InfoText")
                {
                    infoText = text;
                    break;
                }
            }

            var buttons = GetComponentsInChildren<Button>();
            foreach (var button in buttons)
            {
                if (button.name == "Link")
                {
                    Link = button;
                    Link.onClick.AddListener(() =>
                    {
                        if (ParentPanel is SignInPanel)
                        {
                            PanelController.popupinstance.ShowInfo("You should login first!");
                            return;
                        }
                        OnClick(Provider, LINK);
                    });
                }
                else if (button.name == "Login")
                {
                    Login = button;
                    Login.onClick.AddListener(() =>
                    {
                        if (ParentPanel is LinkThirdParty)
                        {
                            PanelController.popupinstance.ShowInfo("You have already login in, can't login again!");
                            return;
                        }
                        OnClick(Provider, LOGIN);
                    });
                }
                else if (button.name == "UnLink")
                {
                    UnLink = button;
                    UnLink.onClick.AddListener(() =>
                    {
                        if (ParentPanel is SignInPanel)
                        {
                            PanelController.popupinstance.ShowInfo("You should login first!");
                            return;
                        }
                        OnUnLinkClick(Provider);
                    });
                }
            }
        }

        public void FixedUpdate()
        {
        }

        public void OnClick(int provider, string Way)
        {
            if (provider == AGConnectAuthCredential.HMS_Provider)
            {
                HWID(Way);
            }
            else if (provider == AGConnectAuthCredential.HWGame_Provider)
            {
                Huaweigame(Way);
            }
            else if (provider == AGConnectAuthCredential.Google_Provider)
            {
                GoogleLogin(Way);
            }
            else if (provider == AGConnectAuthCredential.GoogleGame_Provider)
            {
                GooglePlayLogin(Way);
            }
            else if (provider == AGConnectAuthCredential.Twitter_Provider)
            {
                TwitterLogin(Way);
            }
            else if (provider == AGConnectAuthCredential.WeiXin_Provider)
            {
                startWechatLogin(Way);
            }
            else if (provider == AGConnectAuthCredential.QQ_Provider)
            {
                startQQLogin(Way);
            }
            else if (provider == AGConnectAuthCredential.Facebook_Provider)
            {
                startFacebookLogin(Way);
            }
            else if (provider == AGConnectAuthCredential.WeiBo_Provider)
            {
                startWeiboLogin(Way);
            }else if (provider == AGConnectAuthCredential.SelfBuild_Provider)
            {
                startSelf_own(Way);
            }
        }

        public void failedSteps(string arg0)
        {
            infoText.text ="start onFailure callback";
            Error error = new Error();
            error.message = arg0;
            PanelController.popupinstance.ShowError(error);
        }
        public void OnUnLinkClick(int provider)
        {
            if (AGConnectAuth.getInstance().getCurrentUser() != null)
            {
                AGConnectAuth.getInstance().getCurrentUser().unlink(provider);
            }

            infoText.text = "unlink success!";
            PanelController.popupinstance.ShowInfo("unlink success!");

        }

        public void startSelf_own(string Way)
        {
            string token = "Replace me";
            if (token!=""&&token!="Replace me")
            {
                   AGConnectAuthCredential credential = SelfBuildProvider.credentialWithToken(token);
                   thirdPartySignIn(Way, credential);
            }
            else
            {
                   PanelController.popupinstance.ShowInfo("Token is null");
            }
        }

        public void HWID(string way)
        {
            LoginManager.getInstance().startHWID(new HuaweiOnsuccessListener<string>((Token) =>
         {
             HWIDLoginSteps(Token, way);

         }), new HuaweiOnFailureListener((exception) =>
            {
                failedSteps(exception.toString());
            }));
         
        }


        public void Huaweigame(string way)
        {
            LoginManager.getInstance().startHWGame(new HuaweiOnsuccessListener<string>((Token) =>
            {
                 HWGameLoginSteps(Token,way);
            }), new HuaweiOnFailureListener((exception) =>
            {
                failedSteps(exception.toString());
            }));
        }

        public void GoogleLogin(string way)
        {
            LoginManager.getInstance().startGoogle("Replace me", 
                new HuaweiOnsuccessListener<string>((Token) =>
            {
                GoogleLoginSteps(Token, way);

            }), new HuaweiOnFailureListener((exception) =>
                {
                    failedSteps(exception.toString());
                }));
            
        }

        public void GooglePlayLogin(string way)
        {
            LoginManager.getInstance().startGooglePlay("Replace me",
                new HuaweiOnsuccessListener<string>(
                (Token) =>
                {
                    GoogleGameSteps(Token, way);
                }), new HuaweiOnFailureListener((exception) =>
                {
                    failedSteps(exception.toString());
                }));
        }

        public void TwitterLogin(string way)
        {
            LoginManager.getInstance().startTwitter("Replace me", "Replace me", 
                new HuaweiOnsuccessListener<string>((Token) =>
                {
                    TwitterSteps(Token, way);
                }), new HuaweiOnFailureListener((exception) =>
                {
                    failedSteps(exception.toString());
                }));
        }

        public void startWechatLogin(string way)
        {
            LoginManager.getInstance().startWechatLogin("Replace me", "Replace me", 
                new HuaweiOnsuccessListener<string>((Token) =>
                {
                    WechatSteps(Token, way);
                }), new HuaweiOnFailureListener((exception) =>
                {
                    failedSteps(exception.toString());
                }));
        }

        public void startQQLogin(string way)
        {
            LoginManager.getInstance().startQQ("Replace me", 
                new HuaweiOnsuccessListener<string>((JsonObject) =>
                {
                    QQSteps(JsonObject, way);
                }), new HuaweiOnFailureListener((exception) =>
                {
                    failedSteps(exception.toString());
                }));
        }

        public void startFacebookLogin(string way)
        {
            LoginManager.getInstance().startFacebook("Replace me",new HuaweiOnsuccessListener<string>((JsonObejct) =>
            {
                FaceBookSteps(JsonObejct, way);
            }), new HuaweiOnFailureListener((exception) =>
            {
                failedSteps(exception.toString());
            }));
        }

        public void startWeiboLogin(string way)
        {

            LoginManager.getInstance().startWeibo("Replace me", 
                new HuaweiOnsuccessListener<string>((JsonObejct) =>
                {
                    WeiboSteps(JsonObejct, way);
                }), new HuaweiOnFailureListener((exception) =>
                {
                    failedSteps(exception.toString());
                }));
        }

        public override void OpenPanel()
        {
            base.OpenPanel();
            
        }

        public static void showInfo(string info)
        {
            infoText.text = info;
        }

        public void thirdPartySignIn(string way,AGConnectAuthCredential credential)
        {
            if (way == LOGIN)
            {
                AGConnectAuth.getInstance().signIn(credential)
                    .addOnSuccessListener(new HuaweiOnsuccessListener<SignInResult>(C =>
                    {
                        PanelController.popupinstance.ShowInfo("Login success!");
                        Debug.Log("Login success!");
                        PanelController.userInfo.ParentPanel = this;
                        PanelController.getInstance().OpenPanel(PanelController.userInfo);
                       
                    }))
                    .addOnFailureListener(new HuaweiOnFailureListener((exception) =>
                    {
                        failedSteps(exception.toString());
                    }));
            }
            else
            {
                AGConnectAuth.getInstance().getCurrentUser().link(credential)
                    .addOnSuccessListener(new HuaweiOnsuccessListener<SignInResult>(C =>
                    {
                        PanelController.popupinstance.ShowInfo("Link success!");
                        PanelController.userInfo.ParentPanel = this;
                        PanelController.getInstance().OpenPanel(PanelController.userInfo);
                    }))
                    .addOnFailureListener(new HuaweiOnFailureListener((exception) =>
                    {
                        failedSteps(exception.toString());
                    }));

            }
        }
        public void HWIDLoginSteps(string arg0,string way)
        {
            HWIDGetBack obj = JsonAuthorizeData<HWIDGetBack>.FromJson(arg0.ToString());
            infoText.text = obj.Token;
            AGConnectAuthCredential credential = HwIdAuthProvider.credentialWithToken(obj.Token);
            thirdPartySignIn(way, credential);
        }

        public void HWGameLoginSteps(string arg0, string way)
        {
            HWGameGetBack player=JsonAuthorizeData<HWGameGetBack>.FromJson(arg0.ToString());
            AGConnectAuthCredential credential = new HWGameAuthProvider.Builder()
                .setPlayerSign(player.PlayerSign)
                .setPlayerId(player.PlayerId)
                .setDisplayName(player.DisplayName)
                .setImageUrl(player.ImageUrl)
                .setPlayerLevel(player.PlayerLevel)
                .setSignTs(player.SignTs)
                .build();
            thirdPartySignIn(way, credential);

        }

        public void GoogleLoginSteps(string arg0, string way)
        {
            GoogleGetBack obj=JsonAuthorizeData<GoogleGetBack>.FromJson(arg0.ToString());
            AGConnectAuthCredential credential =
                GoogleAuthProvider.credentialWithToken(obj.Token);
            thirdPartySignIn(way, credential);
        }

        public void GoogleGameSteps(string Token, string way)
        {
            GooglePlayGetBack obj=JsonAuthorizeData<GooglePlayGetBack>.FromJson(Token.ToString());
            AGConnectAuthCredential credential =
                GoogleGameAuthProvider.credentialWithToken(obj.Token);

            thirdPartySignIn(way, credential);

        }

        public void TwitterSteps(string Token,string way)
        {
            TwitterGetBack obj=JsonAuthorizeData<TwitterGetBack>.FromJson(Token.ToString());
            AGConnectAuthCredential credential =
                TwitterAuthProvider.credentialWithToken(obj.Token, obj.Secret);
            thirdPartySignIn(way, credential);
        }


        public void WechatSteps(string Token, string way)
        {
            WechatGetBack obj=JsonAuthorizeData<WechatGetBack>.FromJson(Token.ToString());
            AGConnectAuthCredential credential =
                WeixinAuthProvider.credentialWithToken(obj.Token, obj.OpenId);
            infoText.text = obj.Token;
            thirdPartySignIn(way, credential);
        }


        public void QQSteps(string Token, string way)
        {
            QQGetBack obj=JsonAuthorizeData<QQGetBack>.FromJson(Token.ToString());
            AGConnectAuthCredential credential =
                QQAuthProvider.credentialWithToken(obj.Token, obj.OpenId);
            thirdPartySignIn(way, credential);
        }

        public void FaceBookSteps(string JsonObject, string way)
        {
            FacebookGetBack obj=JsonAuthorizeData<FacebookGetBack>.FromJson(JsonObject.ToString());

            AGConnectAuthCredential credential = FacebookAuthProvider.credentialWithToken(obj.Token);
            thirdPartySignIn(way, credential);
        }

        public void WeiboSteps(string JsonObject, string way)
        {
            WeiboGetBack obj=JsonAuthorizeData<WeiboGetBack>.FromJson(JsonObject.ToString());
            AGConnectAuthCredential credential =
                WeiboAuthProvider.credentialWithToken(obj.Token, obj.Uid);

            thirdPartySignIn(way, credential);
        }
        
    }
}
