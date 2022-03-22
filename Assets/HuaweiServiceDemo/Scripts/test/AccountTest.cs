using HuaweiService;
using HuaweiService.Account;
using HuaweiService.Auth;
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
            init();
            registerEvent("createAuthParam", createAuthParam);
            registerEvent("Signin", Signin);
            registerEvent("getInfo", getInfo);
            registerEvent("cancelAuthorization", cancelAuthorization);
            registerEvent("manualCreateParam", manualCreateParam);
            registerEvent("silentSignin", silentSignin);
            registerEvent("independentSignIn", independentSignIn);
            registerEvent("getChannel", getChannel);
            registerEvent("ReadSmsManagerStart", readSmsManagerStart);
            registerEvent("consentReadSmsManager", consentReadSmsManager);
            registerEvent("signOut", signOut);
        }

        public void init()
        {
            var callback = new AccountCallback();
            callback.setCallback(MyOnActivityResultCallback);
            AccountActivity.setCallback(callback);
        }

        public void MyOnActivityResultCallback(int requestCode, int resultCode,AndroidJavaObject obj)
        {
            var data = new Intent();
            data.obj = obj;
            if (requestCode == Constant.REQUEST_SIGN_IN_LOGIN || requestCode == Constant.REQUEST_SIGN_IN_LOGIN_CODE)
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
            }else if (requestCode == Constant.REQUEST_SIGN_IN_LOGIN_INDEPENDENT)
            {
                TestTip.Inst.ShowText($"MyOnActivityResultCallback requestCode is independentSignIn");
                var authAccountTask = AccountAuthManager.parseAuthResultFromIntent(data);
                if (authAccountTask.isSuccessful()) {
                    var authAccount = new AuthAccount();
                    authAccount.obj=authAccountTask.getResult();
                    TestTip.Inst.ShowText($"signIn onActivityResult parseAuthResultFromIntent success,\n authorizationCode is {authAccount.getAuthorizationCode()}");
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
            mAuthParam = new AccountAuthParamsHelper().setAccessToken().setUid().setAuthorizationCode().setEmail().setId().setIdToken().setProfile().setCarrierId().createParams();
            mAuthManager=AccountAuthManager.getService(new UnityPlayerActivity(), mAuthParam);
            AccountActivity.setAuthParam(mAuthParam);
            TestTip.Inst.ShowText($"helper createAuthParam {mAuthParam}");
        }

        public void manualCreateParam()
        {
            // create authParam which does not contain profile scope
            var emailScope = new Scope("email");
            var scopeList = new List();
            scopeList.add(emailScope.obj);
            mAuthParam = new AccountAuthParamsHelper().setAccessToken().setId().setScopeList(scopeList).createParams(); 
            mAuthManager=AccountAuthManager.getService(new UnityPlayerActivity(), mAuthParam);
            AccountActivity.setAuthParam(mAuthParam);
            TestTip.Inst.ShowText($"manualCreateParam {mAuthParam}");
        }
        public void independentSignIn()
        {
            // CALL independentSignIn .If param exists, nothing will happen
            mAuthParam = new AccountAuthParamsHelper().setProfile().createParams();
            AccountActivity.setAuthParam(mAuthParam);
            AccountActivity.setIntent("independentSignIn");
            AccountActivity.setAccessToken(mAuthAccount.getAccessToken());
            AccountActivity.setRequestCode(Constant.REQUEST_SIGN_IN_LOGIN_INDEPENDENT);
            AccountActivity.start(new UnityPlayerActivity());
        }

        public void Signin()
        {
            AccountActivity.setIntent("signIn");
            AccountActivity.setRequestCode(Constant.REQUEST_SIGN_IN_LOGIN);
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