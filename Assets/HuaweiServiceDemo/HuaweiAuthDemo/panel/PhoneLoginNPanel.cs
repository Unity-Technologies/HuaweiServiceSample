using System.Collections;
using System.Collections.Generic;
using HuaweiAuthDemo;
using HuaweiService;
using HuaweiService.Auth;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HuaweiAuthDemo
{
    public class PhoneLoginNPanel : AbstractPanel
    {
        public TMP_InputField smsCode = default;

        [SerializeField] TMP_InputField phoneNumber = default;
        
        [SerializeField] TMP_InputField password = default;

         public Button SignUpButton = default;

         public Button ResetPassword;

         public Button smsCodeSend = default;

         public Button SignInButton = default;

        public Button resetPasswordSmsCode;
        
        private static VerifyCodeSettings settings;

        private AGConnectAuthCredential credential;
        

        public Text infoMessage;
        public void Start()
        {
            infoMessage.text = "Message Info";
            SignUpButton.onClick.AddListener(() => SignUpClicked());
            ResetPassword.onClick.AddListener(()=>resetPassword());
            resetPasswordSmsCode.onClick.AddListener(()=>phoneVerify(phoneNumber.text.Trim(),"+86",VerifyCodeSettings.ACTION_RESET_PASSWORD));

        }

        public void resetPassword()
        {
            try
            {
                AGConnectAuth.getInstance().resetPassword("+86", phoneNumber.text.Trim(), password.text.Trim(), smsCode.text.Trim())
                    .addOnSuccessListener(new HuaweiOnsuccessListener<AndroidJavaObject>((temp) =>
                    {
                        PanelController.popupinstance.ShowInfo("reset successfully!");
                        infoMessage.text = "reset successfully!";
                    })).addOnFailureListener(new HuaweiOnFailureListener((e
                    ) =>
                    {
                        Error error=new Error();
                        error.message = e.toString();
                        PanelController.popupinstance.ShowError(error);
                        infoMessage.text = e.toString();

                    }));
            }
            catch (System.Exception e)
            {
                Error error = new Error();
                error.message = e.Message;
                PanelController.popupinstance.ShowError(error);

            }
        }


        public void SignUpClicked()
        {
            PanelController.getInstance()
                .OpenPanel(PanelController.getInstance().GetComponentInChildren<PhoneSignUpPanel>());
        }

        public void OnLoginClicked()
        {
            try
            {
                if (smsCode.text.Trim() == "")
                {
                    credential =
                        PhoneAuthProvider.credentialWithPassword("+86", phoneNumber.text.Trim(), password.text.Trim());
                }
                else
                {
                    credential =
                        PhoneAuthProvider.credentialWithVerifyCode("+86", phoneNumber.text.Trim(), password.text.Trim(),
                            smsCode.text.Trim());
                }

                AGConnectAuth.getInstance().signIn(credential)
                    .addOnSuccessListener(new HuaweiOnsuccessListener<SignInResult>((signresult) =>
                    {
                        PanelController.popupinstance.ShowInfo("Login success!");
                        PanelController.userInfo.ParentPanel = this;
                        infoMessage.text = "login success!";
                        PanelController.getInstance().OpenPanel(PanelController.userInfo);
                    })).addOnFailureListener(new HuaweiOnFailureListener((e
                    ) =>
                    {
                        Error error=new Error();
                        error.message = e.toString();
                        PanelController.popupinstance.ShowError(error);
                        infoMessage.text = e.toString();
                    }));
            }
            catch (System.Exception e)
            {
                Error error = new Error();
                error.message = e.Message;
                PanelController.popupinstance.ShowError(error);
            }

        }

        public void OnCodeClicked()
        {
            phoneVerify(phoneNumber.text.Trim(), "+86",VerifyCodeSettings.ACTION_REGISTER_LOGIN);
        }
        
        public static VerifyCodeSettings GenerateSettings(int Number)
        {
            return  new VerifyCodeSettings.Builder()
                .action(Number)
                .sendInterval(30)
                .locale(Locale.CHINA)
                .build();
        }

        public  void phoneVerify(string phoneNumber, string countryCodeStr,int registerOrreset)
        {
            try
            {
                settings = GenerateSettings(registerOrreset);
                HuaweiService.Task task = PhoneAuthProvider.requestVerifyCode(countryCodeStr, phoneNumber,settings);
                task.addOnSuccessListener(TaskExecutors.uiThread(),
                        new HuaweiOnsuccessListener<VerifyCodeResult>((codeResult) =>
                        {
                            PanelController.popupinstance.ShowInfo("sms code send successfully!");
                            infoMessage.text = "sms code send successfully!";
                            
                        }))
                    .addOnFailureListener(TaskExecutors.uiThread(), new HuaweiOnFailureListener((e) =>
                    {
                        Error error=new Error();
                        error.message = e.toString();
                        PanelController.popupinstance.ShowError(error);
                        infoMessage.text = e.toString();
                    }));
            }catch (System.Exception e)
            {
                Error error = new Error();
                error.message = e.Message;
                PanelController.popupinstance.ShowError(error);
            }

        }
    }
}

