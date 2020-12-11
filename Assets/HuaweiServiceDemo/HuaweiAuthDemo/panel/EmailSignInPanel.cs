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
    public class EmailSignInPanel : AbstractPanel
    {

        [SerializeField] TMP_InputField email = default;

        [SerializeField] TMP_InputField password = default;
        
        [SerializeField] TMP_InputField verifyCode = default;

        Button m_LoginBtn;

        public Button resetPassword;

        public Button signUpButton;

        public Button SmsCodeSend;

        public Button resetPasswordSmsCode;
        private AGConnectAuthCredential credential;

        private void Start()
        {
            var buttons = GetComponentsInChildren<Button>();

            foreach (var button in buttons)
            {
                if (button.name == "SignInButton")
                {
                    m_LoginBtn = button;
                }
            }

            m_LoginBtn.onClick.AddListener(OnLoginClicked);

            signUpButton.onClick.AddListener(()=>SignUpClicked());
            
            SmsCodeSend.onClick.AddListener(()=>sendSmsCode(VerifyCodeSettings.ACTION_REGISTER_LOGIN));
            resetPassword.onClick.AddListener(()=>ResetpasswordClick());
            resetPasswordSmsCode.onClick.AddListener(()=>sendSmsCode(VerifyCodeSettings.ACTION_RESET_PASSWORD));
        }

        public void ResetpasswordClick()
        {
            try{
                AGConnectAuth.getInstance().resetPassword(email.text.Trim(), password.text.Trim(), verifyCode.text.Trim()).addOnSuccessListener(new HuaweiOnsuccessListener<AndroidJavaObject>((temp) =>
            {
                PanelController.popupinstance.ShowInfo("reset successfully!");
            })).addOnFailureListener(new HuaweiOnFailureListener((e
            ) =>
            {
                Error error=new Error();
                error.message = e.toString();
                PanelController.popupinstance.ShowError(error);
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
                .OpenPanel(PanelController.getInstance().GetComponentInChildren<EmailSignUpPanel>());
        }

        public void OnLoginClicked()
        {
            try
            {
                if (verifyCode.text.Trim() != "")
                {
                    credential =
                        EmailAuthProvider.credentialWithVerifyCode(email.text.Trim(), password.text.Trim(),verifyCode.text.Trim());
                }
                else
                { 
                    credential =
                        EmailAuthProvider.credentialWithPassword(email.text, password.text);
                }

                if (credential.getProvider() == AGConnectAuthCredential.Email_Provider)
                {
                    AGConnectAuth.getInstance().signIn(credential)
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
            }
            catch (System.Exception e)
            {
                Error error = new Error();
                error.message = e.Message;
                PanelController.popupinstance.ShowError(error);
            }

        }
        

        public void sendSmsCode(int registerOrreset)
        {
           try{ VerifyCodeSettings settings = new VerifyCodeSettings.Builder()
                .action(registerOrreset)   
                .sendInterval(30) 
                .locale(Locale.CHINA) 
                .build();
            HuaweiService.Task task= EmailAuthProvider.requestVerifyCode(email.text.Trim(), settings);
            task.addOnSuccessListener(TaskExecutors.uiThread(),
                    new HuaweiOnsuccessListener<VerifyCodeResult>((codeResult) =>
                    {
                        PanelController.popupinstance.ShowInfo("code send successfully!");
                       
                    }))
                .addOnFailureListener(TaskExecutors.uiThread(), new HuaweiOnFailureListener((e) =>
                {
                    Error error=new Error();
                    error.message = e.toString();
                    PanelController.popupinstance.ShowError(error);
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

