using HuaweiAuthDemo;
using HuaweiService;
using HuaweiService.Auth;
using UnityEngine;

namespace HuaweiAuthDemo
{

    public class EmailSignUpPanel : AbstractPasswordConfirmationPanel
    {
        public void OnSignUpClicked()
        {
            EmailUser emailUser = new EmailUser.Builder()
                    .setEmail(emailorPhone.text)
                    .setVerifyCode(verifyCode.text)
                    .setPassword(password.text)
                    .build();
                
                AGConnectAuth.getInstance().createUser(emailUser)
                    .addOnSuccessListener(new HuaweiOnsuccessListener<SignInResult>((signresult) =>
                    {
                        PanelController.popupinstance.ShowInfo("sign up successfully!"); 
                        PanelController.userInfo.ParentPanel = this;
                        PanelController.getInstance().OpenPanel(PanelController.userInfo);
                        
                    })).addOnFailureListener(new HuaweiOnFailureListener((e
                    ) =>
                    {
                        Error error=new Error();
                        error.message = "Login failed" + e.ToString();
                        PanelController.popupinstance.ShowError(error);
                    }));

        }

        public void verify()
        {
            bool result = false;
            VerifyCodeSettings settings = new VerifyCodeSettings.Builder()
                .action(VerifyCodeSettings.ACTION_REGISTER_LOGIN)
                .sendInterval(30)
                .locale(Locale.CHINA)
                .build();
            HuaweiService.Task task = EmailAuthProvider.requestVerifyCode(emailorPhone.text, settings);
            task.addOnSuccessListener(TaskExecutors.uiThread(),
                    new HuaweiOnsuccessListener<VerifyCodeResult>(
                        (codeResult) =>
                        {
                            result = true; 
                            PanelController.popupinstance.ShowInfo("sms code send successfully!"); 
                        }))
                .addOnFailureListener(TaskExecutors.uiThread(), new HuaweiOnFailureListener((e) =>
                {
                    Error error=new Error();
                    error.message = e.toString();
                    PanelController.popupinstance.ShowError(error);

                }));
        }

        public void onVerifyButtonClick()
        {
            Debug.Log("enter"); 
            verify();
        }

        public override void OpenPanel()
        {
            base.OpenPanel();
            
        }
    }
    
}
