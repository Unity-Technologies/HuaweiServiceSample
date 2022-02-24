using HuaweiService;
using HuaweiService.Account;
using HuaweiService.Auth;
using UnityEngine;
using System;
using HuaweiService.IAP;
using UnityEngine.HuaweiAppGallery;
using UnityEngine.HuaweiAppGallery.Listener;
using AccountAuthParamsHelper = HuaweiService.Account.AccountAuthParamsHelper;
using Uri = HuaweiService.Uri;
using Void = HuaweiService.Void;

namespace HuaweiServiceDemo
{
    public class AccountTest : Test<AccountTest>
    {

        public  AccountAuthParams mAuthParam;
        public AccountAuthService mAuthManager;
        public AuthAccount mAuthAccount;
        
        public class Constant {
            public static  int IS_LOG = 1;
            //login
            public static  int REQUEST_SIGN_IN_LOGIN = 1002;
            //login by code
            public static  int REQUEST_SIGN_IN_LOGIN_CODE = 1003;
        }
        public override void RegisterEvent(TestEvent registerEvent)
        {
            registerEvent("createAuthParam", createAuthParam);
            registerEvent("Signin", Signin);
            registerEvent("getInfo", getInfo);
            registerEvent("getChannel", getChannel);
            registerEvent("independentSignIn", independentSignIn);
            registerEvent("consent", consent);
            registerEvent("signOut", signOut);
            registerEvent("cancelAuthorization", cancelAuthorization);
        }

        public void createAuthParam()
        {
            var activity = new UnityPlayerActivity();
            var _mAuthParam = new AccountAuthParamsHelper(AccountAuthParams.DEFAULT_AUTH_REQUEST_PARAM).setUid().setAuthorizationCode().setEmail().setId().setIdToken().setProfile().setCarrierId().createParams();
            var scopeList = _mAuthParam.getRequestScopeList();
            mAuthParam = new AccountAuthParamsHelper().setScopeList(scopeList).createParams();
            mAuthManager=AccountAuthManager.getService(activity, mAuthParam);
            AccountActivity.setAuthParam(mAuthParam);
            TestTip.Inst.ShowText($"helper createAuthParam {mAuthParam}");
        }
        public void MyOnActivityResultCallback(int requestCode, int resultCode)
        {
            TestTip.Inst.ShowText($"MyOnActivityResultCallback run callback {requestCode} {resultCode} ");
            if (requestCode == Constant.REQUEST_SIGN_IN_LOGIN || requestCode == Constant.REQUEST_SIGN_IN_LOGIN_CODE)
            {
                mAuthAccount = AccountActivity.getAuthAccount();
                TestTip.Inst.ShowText($"MyOnActivityResultCallback getAuthAccount {mAuthAccount}");
            }
        }
        public void Signin()
        {
            AccountActivity.setIntent("signIn");
            var callback = new AccountCallback();
            callback.setCallback(MyOnActivityResultCallback);
            AccountActivity.setCallback(callback);
            AccountActivity.start();
        }
        public void getInfo()
        {
            var token = mAuthAccount.getAccessToken();
            AccountActivity.setAccessToken(token);
            var displayName = mAuthAccount.getDisplayName();
            var account = mAuthAccount.getAccount(new Context());
            var email = mAuthAccount.getEmail();
            var fName = mAuthAccount.getFamilyName();
            var gName = mAuthAccount.getGivenName();
            var scope = mAuthAccount.getAuthorizedScopes();
            var avatarUri =mAuthAccount.getAvatarUri();
            var authorizationCode =mAuthAccount.getAuthorizationCode();
            var unionId =mAuthAccount.getUnionId();
            var openId =mAuthAccount.getOpenId();
            // var uid =mAuthAccount.getUid(); MISS!!!!!!!!!!!!
            
            var accountFlag =mAuthAccount.getAccountFlag();
            var carrierId =mAuthAccount.getCarrierId();
            TestTip.Inst.ShowText($"getInfo :\n token{token}\n displayName{displayName}\n account{account}\n email{email}\n fName{fName}\n gName{gName}\n scope{scope}\n" +
                                  $" avatarUri{avatarUri}\n authorizationCode{authorizationCode}\n unionId{unionId}\n openId{openId}\n accountFlag{accountFlag}\n carrierId{carrierId}\n");
        }
        
        public void independentSignIn()
        {
            AccountActivity.setIntent("independentSignIn");
            AccountActivity.start();
        }
        
        public void consent()
        {
            var activity=new UnityPlayerActivity();
            ReadSmsManager.startConsent(activity,"").addOnSuccessListener(new LocationSuccessListener((c) =>
            {
                TestTip.Inst.ShowText($"consent success {c}");
            })).addOnFailureListener(new HmsFailureListener((e) =>
            {
                TestTip.Inst.ShowText($"consent failed {e}");
            }));
        }
        


        public void getChannel()
        {
            var task = mAuthManager.getChannel();
            task.addOnSuccessListener(new HmsSuccessListener<AccountIcon>((c) =>
            {
                TestTip.Inst.ShowText($"getChannel success {c} {c.getDescription()}");
            }));
            task.addOnFailureListener(new HmsFailureListener((e) =>
            {
                TestTip.Inst.ShowText($"getChannel failed {e}");
            }));
        }
        

        public void signOut()
        {
            var task=mAuthManager.signOut();
            task.addOnSuccessListener(new HmsSuccessListener<Void>((c) =>
            {
                TestTip.Inst.ShowText($"signOut success {c}");
            }));
            task.addOnFailureListener(new HmsFailureListener((e) =>
            {
                TestTip.Inst.ShowText($"signOut failed {e}");
            }));
        }

        public void cancelAuthorization()
        {
            var task=mAuthManager.cancelAuthorization();
            task.addOnSuccessListener(new HmsSuccessListener<Void>((c) =>
            {
                TestTip.Inst.ShowText($"cancelAuthorization success {c}");
            }));
            task.addOnFailureListener(new HmsFailureListener((e) =>
            {
                TestTip.Inst.ShowText($"cancelAuthorization failed {e}");
            }));
        }
        
    }
}