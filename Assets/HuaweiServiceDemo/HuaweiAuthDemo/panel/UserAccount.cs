using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

using HuaweiService;
using HuaweiService.Auth;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

namespace HuaweiAuthDemo
{
    public class UserAccount : AbstractPanel
    {
        public Text UserNikeName;

        public Text UserPhoneNumber;

        public Text UserEmail;

        public Text photoUrl;

        public Text UserId;

        public Text UserProviderId;

        public Text UserProviderInfo;

        public Text UserToken;

        public Text UserExtra;
        public Text MessageInfo;

        public Text isAnonymous;
        private AGConnectUser agConnectUser;
    
        public Button LogOut;

        public Button modifyPhone;

        public Button modifyEmail;

        public Button modifyPhonePassword;

        public Button modifyEmailPassword;

        public Button deleteUser;

        public Button Link;
        void Start()
        {
            UserNikeName.text = "Null";
            UserEmail.text = "Null";
            UserPhoneNumber.text = "Null";
            LogOut.onClick.AddListener(()=>LogOutClick());
            modifyEmail.onClick.AddListener(()=>
            {
                if (UserEmail.text == ""||UserEmail.text=="Null")
                {
                    PanelController.popupinstance.ShowInfo("the email is Null, you can't modify it");
                    MessageInfo.text = "the email is Null, you can't modify it";
                    return;
                }
                OnModifyClick(true, false);
            });
            modifyPhone.onClick.AddListener(()=>
            {
                if (UserPhoneNumber.text == "" || UserPhoneNumber.text == "Null")
                {
                    PanelController.popupinstance.ShowInfo("the phone is Null, you can't modify it");
                    MessageInfo.text = "the phone is Null, you can't modify it";
                    return;
                }
                OnModifyClick(false, false);
            });
            modifyEmailPassword.onClick.AddListener(()=>
            {
                if (UserEmail.text == "" || UserEmail.text == "Null")
                {
                    PanelController.popupinstance.ShowInfo("the email is Null, you can't modify it");
                    MessageInfo.text = "the email is Null, you can't modify it";
                    return;
                }
                OnModifyClick(true, true);
            });
            modifyPhonePassword.onClick.AddListener(()=>
            { 
                if (UserPhoneNumber.text == "" || UserPhoneNumber.text == "Null")
                {
                    PanelController.popupinstance.ShowInfo("the phone is Null, you can't modify it");
                    MessageInfo.text = "the phone is Null, you can't modify it";
                    return;
                }
                
                OnModifyClick(false, true);
            });
            deleteUser.onClick.AddListener(() =>
            {
                AGConnectAuth.getInstance().deleteUser();
                PanelController.popupinstance.ShowInfo("the user has been delete!");
                PanelController.getInstance()
                    .OpenPanel(PanelController.getInstance().GetComponentInChildren<SignInPanel>());
            });
            
            Link.onClick.AddListener(() =>
            {
                PanelController.getInstance().GetComponentInChildren<LinkThirdParty>().ParentPanel = this;
                PanelController.getInstance()
                    .OpenPanel(PanelController.getInstance().GetComponentInChildren<LinkThirdParty>());
                
            });
           
        }

        public void OnModifyClick(bool isPhoneOrEmail,bool ismodifyPassword)
        {
            UpdateAccount.isPhoneOrEmail = isPhoneOrEmail;
            UpdateAccount.isModifyPassword = ismodifyPassword;
            PanelController.getInstance()
                .OpenPanel(PanelController.getInstance().GetComponentInChildren<UpdateAccount>());
        }
        

        public override void OpenPanel()
        {
           base.OpenPanel();
            try
            {
                agConnectUser = AGConnectAuth.getInstance().getCurrentUser();
                if (agConnectUser != null)
                {
                    UserNikeName.text= agConnectUser.getDisplayName();
                    UserEmail.text=agConnectUser.getEmail();
                    UserPhoneNumber.text=agConnectUser.getPhone();
                    photoUrl.text = agConnectUser.getPhotoUrl();
                    UserId.text = agConnectUser.getUid();
                    UserProviderId.text = agConnectUser.getProviderId();
                   UserProviderInfo.text = transferProviderInfo(agConnectUser.getProviderInfo());
                   agConnectUser.getToken(false).addOnSuccessListener(new HuaweiOnsuccessListener<TokenResult>(
                       (result) =>
                       {
                           UserToken.text = result.getToken() + "  " + result.getExpirePeriod();
                       }
                   ));

                   agConnectUser.getUserExtra().addOnSuccessListener(new HuaweiOnsuccessListener<AGConnectUserExtra>(
                       (UserExtraInfo) =>
                       {
                          UserExtra.text= UserExtraInfo.getCreateTime()+"  "+UserExtraInfo.getLastSignInTime();
                       }));
                   isAnonymous.text = agConnectUser.isAnonymous()
                       ? "true"
                       : "false" + "  " + agConnectUser.getEmailVerified() + "   "+agConnectUser.getPasswordSetted();
                   
                }
            }
            catch (System.Exception e)
            {
                Error error = new Error();
                error.message = e.Message;
                PanelController.popupinstance.ShowError(error);
            }

        }

         public string transferProviderInfo(List info)
        {
            var Builder = new StringBuilder();
            AndroidJavaObject[] mapList=info.toArray();
            for (int i = 0; i < mapList.Length; i++)
            {
                Map temp=HmsUtil.GetHmsBase<Map>(mapList[i]);
                string[] keyArray=temp.keySet().toArray();
                for (int j = 0; j < keyArray.Length; j++)
                {
                    Builder.Append(keyArray[i] + "  ");
                    Builder.Append(temp.getOrDefault(keyArray[i], "")+"  ");
                }
                
            }

            return Builder.ToString();
        }
        
        
        public void LogOutClick()
        {
            try
            {
                if (AGConnectAuth.getInstance() != null)
                {
                    AGConnectAuth.getInstance().signOut();
                    PanelController.popupinstance.ShowInfo("User has been sign out!");
                    PanelController.getInstance().OpenPanel(PanelController.getInstance().GetComponentInChildren<SignInPanel>());
                }
                
            } catch (System.Exception e)
            {
                Error error = new Error();
                error.message = e.Message;
                PanelController.popupinstance.ShowError(error);
            }
            
            PanelController.getInstance().OpenPanel(PanelController.getInstance().GetComponentInChildren<SignInPanel>());
        }
    }
}