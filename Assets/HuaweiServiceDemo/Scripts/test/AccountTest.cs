using HuaweiService;
using HuaweiService.Account;
using UnityEngine;
using AccountAuthParamsHelper = HuaweiService.Account.AccountAuthParamsHelper;

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
            //independent sign in
            public static  int REQUEST_SIGN_IN_LOGIN_INDEPENDENT = 1004;
        }
        public override void RegisterEvent(TestEvent registerEvent)
        {
            registerEvent("createAuthParam", createAuthParam);
            registerEvent("Signin", Signin);
            registerEvent("silentSignin", silentSignin);
            registerEvent("getInfo", getInfo);
            registerEvent("getChannel", getChannel);
            registerEvent("independentSignIn", independentSignIn);
            registerEvent("ReadSmsManagerStart", readSmsManagerStart);
            registerEvent("consentReadSmsManager", consentReadSmsManager);
            registerEvent("signOut", signOut);
            registerEvent("cancelAuthorization", cancelAuthorization);
        }


        public void MyOnActivityResultCallback(int requestCode, int resultCode,AndroidJavaObject obj)
        {
            var data = new Intent();
            data.obj = obj;
            if (requestCode == Constant.REQUEST_SIGN_IN_LOGIN || requestCode == Constant.REQUEST_SIGN_IN_LOGIN_CODE||requestCode==Constant.REQUEST_SIGN_IN_LOGIN_INDEPENDENT)
            {
                TestTip.Inst.ShowText($"MyOnActivityResultCallback requestCode is signIn");
                var authAccountTask = AccountAuthManager.parseAuthResultFromIntent(data);
                if (authAccountTask.isSuccessful()) {
                    mAuthAccount = new AuthAccount();
                    mAuthAccount.obj=authAccountTask.getResult();
                    TestTip.Inst.ShowText("signIn onActivityResult parseAuthResultFromIntent success");
                }else{
                    TestTip.Inst.ShowText("signIn onActivityResult parseAuthResultFromIntent fail");
                }
            }
        }
        public class AccountSuccessListener:OnSuccessListener{
            public SuccessCallBack CallBack;
            public AccountSuccessListener(SuccessCallBack c){
                CallBack = c;
            }
            public override void onSuccess(AndroidJavaObject arg0){
                TestTip.Inst.ShowText("OnSuccessListener onSuccess");
                if(CallBack !=null){
                    CallBack.Invoke(arg0);
                }
            }
        }
        
        public void createAuthParam()
        {
            var activity = new UnityPlayerActivity();
            var callback = new AccountCallback();
            callback.setCallback(MyOnActivityResultCallback);
            AccountActivity.setCallback(callback);
            mAuthParam = new AccountAuthParamsHelper(AccountAuthParams.DEFAULT_AUTH_REQUEST_PARAM).setAccessToken().setUid().setAuthorizationCode().setEmail().setId().setIdToken().setProfile().setCarrierId().createParams();
            // setAccessToken can be lost by getRequestScopeList
            
            // var scopeList = mAuthParam.getRequestScopeList();   
            // mAuthParam = new AccountAuthParamsHelper(AccountAuthParams.DEFAULT_AUTH_REQUEST_PARAM).setScopeList(scopeList).createParams(); 
            mAuthManager=AccountAuthManager.getService(activity, mAuthParam);
            AccountActivity.setAuthParam(mAuthParam);
            TestTip.Inst.ShowText($"helper createAuthParam {mAuthParam}");
        }
        public void Signin()
        {
            AccountActivity.setIntent("signIn");
            AccountActivity.start(new UnityPlayerActivity());
        }
        
        public void silentSignin()
        {
            var task=mAuthManager.silentSignIn();
            task.addOnSuccessListener(new HmsSuccessListener<AuthAccount>((c) =>
            {
                TestTip.Inst.ShowText($"silentSignin success {c}");
                mAuthAccount = c;
            })).addOnFailureListener(new HmsFailureListener((e) =>
            {
                TestTip.Inst.ShowText($"silentSignin failed {e}");
                Signin();
            }));
        }
        public void getInfo()
        {
            var token = mAuthAccount.getAccessToken();
            var displayName = mAuthAccount.getDisplayName();
            var account = mAuthAccount.getAccount(new Context());
            var email = mAuthAccount.getEmail();
            var fName = mAuthAccount.getFamilyName();
            var gName = mAuthAccount.getGivenName();
            var scope = mAuthAccount.getAuthorizedScopes();
            var idToken = mAuthAccount.getIdToken();
            var avatarUri =mAuthAccount.getAvatarUri();
            var authorizationCode =mAuthAccount.getAuthorizationCode();
            var serviceCountryCode = mAuthAccount.getServiceCountryCode();
            var unionId =mAuthAccount.getUnionId();
            var openId =mAuthAccount.getOpenId();
            var uid =mAuthAccount.getUid();
            
            var accountFlag =mAuthAccount.getAccountFlag();
            var carrierId =mAuthAccount.getCarrierId();
            TestTip.Inst.ShowText($"getInfo :\n token{token}\n displayName{displayName}\n account{account}\n email{email}\n fName{fName}\n gName{gName}\n scope{scope}\n idToken{idToken}\n" +
                                  $" avatarUri{avatarUri}\n authorizationCode{authorizationCode}\n serviceCountryCode{serviceCountryCode}\n unionId{unionId}\n openId{openId}\n uid{uid}\n accountFlag{accountFlag}\n carrierId{carrierId}\n");
        }
        
        public void independentSignIn()
        {
            AccountActivity.setIntent("independentSignIn");
            AccountActivity.setAccessToken(mAuthAccount.getAccessToken());
            AccountActivity.start(new UnityPlayerActivity());
        }
        public void readSmsManagerStart()
        {
            ReadSmsManager.start(new UnityPlayerActivity()).addOnSuccessListener(new AccountSuccessListener((c) =>
            {
                TestTip.Inst.ShowText($"readSmsManagerStart success {c}");
            })).addOnFailureListener(new HmsFailureListener((e) =>
            {
                TestTip.Inst.ShowText($"readSmsManagerStart failed {e}");
            }));
        }
        public void consentReadSmsManager()
        {
            ReadSmsManager.startConsent(new UnityPlayerActivity(),"").addOnSuccessListener(new AccountSuccessListener((c) =>
            {
                TestTip.Inst.ShowText($"consentReadSmsManager success {c}");
            })).addOnFailureListener(new HmsFailureListener((e) =>
            {
                TestTip.Inst.ShowText($"consentReadSmsManager failed {e}");
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
            task.addOnSuccessListener(new AccountSuccessListener((c) =>
            {
                TestTip.Inst.ShowText($"signOut success {c}");
            })).addOnFailureListener(new HmsFailureListener((e) =>
            {
                TestTip.Inst.ShowText($"signOut failed {e}");
            }));
        }

        public void cancelAuthorization()
        {
            var task=mAuthManager.cancelAuthorization();
            task.addOnSuccessListener(new AccountSuccessListener((c) =>
            {
                TestTip.Inst.ShowText($"cancelAuthorization success {c}");
            })).addOnFailureListener(new HmsFailureListener((e) =>
            {
                TestTip.Inst.ShowText($"cancelAuthorization failed {e}");
            }));
        }
        
    }
}