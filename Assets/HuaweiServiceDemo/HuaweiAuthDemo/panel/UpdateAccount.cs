using System;
using HuaweiAuthDemo;
using HuaweiService;
using HuaweiService.Auth;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HuaweiAuthDemo
{
    public class UpdateAccount:AbstractPanel
    {
        public static bool isPhoneOrEmail = false;
        public static bool isModifyPassword =false;
        private HuaweiService.Task task;
        private HuaweiService.Task modifyTask;
        private AGConnectUser agConnectUser;
        private AGConnectAuth instance;
        [SerializeField]
        public TMP_InputField emailorPhone = default;

        public TMP_InputField verifyCode = default;
        
        public TMP_InputField newemailorPhoneorpassword = default;

        public Button smscodeSend=default;

        public Button modifyButton=default;

        public Text showMessage = default;

        public void Start()
        {
            smscodeSend.onClick.AddListener(()=>verify(isModifyPassword?VerifyCodeSettings.ACTION_RESET_PASSWORD:VerifyCodeSettings.ACTION_REGISTER_LOGIN));
           modifyButton.onClick.AddListener(()=>OnModifyClick());
        }

        public void verify(int resetOrregister)
        {
            VerifyCodeSettings settings = new VerifyCodeSettings.Builder()
                .action(resetOrregister)
                .sendInterval(30)
                .locale(Locale.CHINA)
                .build();
            if (isPhoneOrEmail)
            {
                task = EmailAuthProvider.requestVerifyCode(isModifyPassword?emailorPhone.text.Trim():newemailorPhoneorpassword.text.Trim(), settings);
            }
            else
            {
                task = PhoneAuthProvider.requestVerifyCode("+86",isModifyPassword?emailorPhone.text.Trim():newemailorPhoneorpassword.text.Trim(), settings);
            }

            task.addOnSuccessListener(TaskExecutors.uiThread(),
                    new HuaweiOnsuccessListener<VerifyCodeResult>(
                        (codeResult) =>
                        {
                            showMessage.text = "code send successfully!";
                            PanelController.popupinstance.ShowInfo("code send successfully!"); 
                        }))
                .addOnFailureListener(TaskExecutors.uiThread(), new HuaweiOnFailureListener((e) =>
                {
                    Error error=new Error();
                    error.message = e.toString();
                    PanelController.popupinstance.ShowError(error);
                    showMessage.text = e.toString();
                }));
        }

        public void OnModifyClick()
        {
            instance = AGConnectAuth.getInstance();
            agConnectUser = instance.getCurrentUser();
            if (agConnectUser != null)
            {
                try
                {
                    if (!isModifyPassword)
                    {
                        if (isPhoneOrEmail)
                        {
                            modifyTask = agConnectUser
                                .updateEmail(newemailorPhoneorpassword.text.Trim(), verifyCode.text.Trim());
                        }
                        else
                        {
                            modifyTask = agConnectUser
                                .updatePhone("+86", newemailorPhoneorpassword.text.Trim(), verifyCode.text.Trim());
                        }
                    }
                    else
                    {
                        modifyTask = agConnectUser.updatePassword(
                            newemailorPhoneorpassword.text.Trim(),
                            verifyCode.text.Trim(),
                            isPhoneOrEmail
                                ? AGConnectAuthCredential.Email_Provider
                                : AGConnectAuthCredential.Phone_Provider);
                    }
                    modifyTask.addOnSuccessListener(new HuaweiOnsuccessListener<SignInResult>((signresult) =>
                    {
                        PanelController.popupinstance.ShowInfo("modify successfully!");
                        showMessage.text = "modify successfully!";
                        PanelController.getInstance().OpenPanel(PanelController.userInfo);
                    })).addOnFailureListener(new HuaweiOnFailureListener((e
                    ) =>
                    {
                        Error error=new Error();
                        error.message = e.toString();
                        PanelController.popupinstance.ShowError(error);
                        showMessage.text = e.toString();
                    }));
                }
                catch (System.Exception e)
                {
                    Error error = new Error();
                    error.message = e.Message;
                    showMessage.text = e.Message;
                    PanelController.popupinstance.ShowError(error);

                }

            }
            else
            {
                showMessage.text = "User is null!";
            }
        }

        public override void OpenPanel()
        {
            base.OpenPanel();
            
        }
    }
}