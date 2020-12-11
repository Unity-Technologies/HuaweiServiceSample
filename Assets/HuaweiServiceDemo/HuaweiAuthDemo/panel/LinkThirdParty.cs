using System.Collections;
using System.Collections.Generic;
using HuaweiAuthDemo;
using HuaweiService.Auth;
using UnityEngine;
using UnityEngine.UI;

namespace HuaweiAuthDemo
{


    public class LinkThirdParty : AbstractPanel
    {
        // Start is called before the first frame update
        void Start()
        {
            var buttons = GetComponentsInChildren<Button>();
            foreach (var button in buttons)
            {
                if (button.name == "HWID")
                {
                    button.onClick.AddListener(() => OnLinkClicked(AGConnectAuthCredential.HMS_Provider));
                }
                else if (button.name == "HWGame")
                {
                    button.onClick.AddListener(() => OnLinkClicked(AGConnectAuthCredential.HWGame_Provider));
                }
                else if (button.name == "Wechat")
                {
                    button.onClick.AddListener(() => OnLinkClicked(AGConnectAuthCredential.WeiXin_Provider));
                }
                else if (button.name == "Facebook")
                {
                    button.onClick.AddListener(() => OnLinkClicked(AGConnectAuthCredential.Facebook_Provider));
                }
                else if (button.name == "Twitter")
                {
                    button.onClick.AddListener(() => OnLinkClicked(AGConnectAuthCredential.Twitter_Provider));
                }
                else if (button.name == "weibo")
                {
                    button.onClick.AddListener(() => OnLinkClicked(AGConnectAuthCredential.WeiBo_Provider));
                }
                else if (button.name == "QQ")
                {
                    button.onClick.AddListener(() => OnLinkClicked(AGConnectAuthCredential.QQ_Provider));
                }
                else if (button.name == "Google")
                {
                    button.onClick.AddListener(() => OnLinkClicked(AGConnectAuthCredential.Google_Provider));
                }
                else if (button.name == "GooglePlay")
                {
                    button.onClick.AddListener(() => OnLinkClicked(AGConnectAuthCredential.GoogleGame_Provider));
                }
            }

        }

        public void OnLinkClicked(int provider)
        {
            DetailLogin.Provider = provider;
            PanelController.getInstance().GetComponentInChildren<DetailLogin>().ParentPanel = this;
            PanelController.getInstance()
                .OpenPanel(PanelController.getInstance().GetComponentInChildren<DetailLogin>());
        }
        
    }
}
