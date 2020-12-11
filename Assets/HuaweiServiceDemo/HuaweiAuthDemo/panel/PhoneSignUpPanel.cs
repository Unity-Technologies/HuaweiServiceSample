using HuaweiAuthDemo;
using HuaweiService;
using HuaweiService.Auth;
using UnityEngine;
using UnityEngine.UI;

namespace HuaweiAuthDemo
{
    public class PhoneSignUpPanel: AbstractPasswordConfirmationPanel
    {
        private Dropdown _regionCode;
        private VerifyCodeSettings settings;
        private string regionText;

        private void Start()
        {
            _regionCode = GetComponentInChildren<Dropdown>();
            regionText = _regionCode.options[_regionCode.value].text;
        }
        public void onVerifyButtonClick()
        {
            settings = GenerateSettings(VerifyCodeSettings.ACTION_REGISTER_LOGIN);
            HuaweiService.Task task = PhoneAuthProvider.requestVerifyCode(regionText, emailorPhone.text,settings);
            task.addOnSuccessListener(TaskExecutors.uiThread(),
                    new HuaweiOnsuccessListener<VerifyCodeResult>((codeResult) =>
                    {
                        PanelController.popupinstance.ShowInfo("sms code send successfully!");
                       
                    }))
                .addOnFailureListener(TaskExecutors.uiThread(), new HuaweiOnFailureListener((e) =>
                {
                    Error error=new Error();
                    error.message = e.toString();
                    PanelController.popupinstance.ShowError(error);
                }));

        }

        public VerifyCodeSettings GenerateSettings(int Number)
        {
            return  new VerifyCodeSettings.Builder()
                .action(Number)
                .sendInterval(30)
                .locale(Locale.CHINA)
                .build();
        }

        public void OnSignUpButtonClick()
        {
            if (password.text != passwordConfirmation.text)
            {
                Error error =new Error();
                error.message = "两次输入的密码不一致";
                PanelController.popupinstance.ShowError(error);
                return;
            }

            try
            {
                PhoneUser phoneUser = new PhoneUser.Builder()
                    .setCountryCode(regionText)
                    .setPhoneNumber(emailorPhone.text)
                    .setVerifyCode(verifyCode.text)
                    .setPassword(password.text)
                    .build();
                AGConnectAuth.getInstance().createUser(phoneUser)
                    .addOnSuccessListener(new HuaweiOnsuccessListener<SignInResult>((signresult) =>
                    {
                        PanelController.popupinstance.ShowInfo("sign up successfully!");
                        PanelController.userInfo.ParentPanel = this;
                        PanelController.getInstance().OpenPanel(PanelController.userInfo);
                    })).addOnFailureListener(new HuaweiOnFailureListener((e
                    ) =>
                    {
                        Error error=new Error();
                        error.message = e.toString();
                        PanelController.popupinstance.ShowError(error);
                    }));
            }catch (System.Exception e) {
                Error error=new Error();
                error.message = e.Message;
                PanelController.popupinstance.ShowError(error);
            }
        }

    }
}
