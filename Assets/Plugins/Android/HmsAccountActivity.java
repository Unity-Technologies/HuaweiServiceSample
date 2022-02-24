package com.hms.hms_account_activity;

import com.unity3d.player.UnityPlayerActivity;
import com.unity3d.player.UnityPlayer;
import androidx.core.app.ActivityCompat;
import android.os.Bundle;
import android.app.Activity;
import android.content.Intent;
import android.content.Context;
import java.lang.Boolean;
import com.huawei.hmf.tasks.OnFailureListener;
import com.huawei.hmf.tasks.OnSuccessListener;
import com.huawei.hmf.tasks.OnCompleteListener;
import com.huawei.hmf.tasks.Task;
import com.huawei.hms.support.account.AccountAuthManager;
import com.huawei.hms.support.account.request.AccountAuthParams;
import com.huawei.hms.support.account.request.AccountAuthParamsHelper;
import com.huawei.hms.support.account.result.AuthAccount;
import com.huawei.hms.support.account.service.AccountAuthService;
import com.huawei.hms.support.sms.ReadSmsManager;
import com.hms.hms_account_activity.AccountCallback;
import android.util.Log;
import android.view.View;

public class HmsAccountActivity extends Activity {
    private static final String TAG = "HmsAccountActivity";
    private static AccountAuthService mAuthManager;
    private static AccountAuthParams mAuthParam;
    private static AccountCallback mCallback;
    private static AuthAccount mAuthAccount;
    private static String mAccessToken;
    private static String mPhoneNumber;
    
    private static String _intent = "test";

    public static void setIntent(String intent){
        Log.e(TAG,"setIntent: "+_intent+"  "+intent);
        _intent=intent;
    }
    public static void setAccessToken(String token){
        Log.e(TAG,"setAccessToken: "+mAccessToken+"  "+token);
        mAccessToken=token;
    }
    public static void setAuthParam(AccountAuthParams AuthParam){
        mAuthParam=AuthParam;
    }
        
    public static void setPhoneNumber(String phoneNumber){
            Log.e(TAG,"setPhoneNumber: "+mPhoneNumber+"  "+phoneNumber);
            mPhoneNumber=phoneNumber;
    }

    public static AuthAccount getAuthAccount(){
        return mAuthAccount;
    }
    

    public static void setCallback(AccountCallback callback){
        Log.e(TAG,"setCallback: ");
        mCallback=callback;
    }
    
    public class Constant {
        public static final int IS_LOG = 1;
        //login
        public static final int REQUEST_SIGN_IN_LOGIN = 1002;
        //login by code
        public static final int REQUEST_SIGN_IN_LOGIN_CODE = 1003;
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        Log.e(TAG, "onCreate" + _intent);
        super.onCreate(savedInstanceState);
        switch (_intent) {
            case "signIn":
                signIn();
                break;       
            case "independentSignIn":
                independentSignIn(mAccessToken);
                break;
            default:
                Log.e(TAG, "switch _intent default");
        }
    }
            
    public void signIn() {
       Log.e(TAG,"signIn");
       mAuthManager = AccountAuthManager.getService(this, mAuthParam);
       startActivityForResult(mAuthManager.getSignInIntent(), Constant.REQUEST_SIGN_IN_LOGIN);
    }
    
    public static Intent getActivityIntent(Activity activity){
        return new Intent(activity, HmsAccountActivity.class);
    }
    
    public static void start(){
            Activity activity=UnityPlayer.currentActivity;
            Intent intent = new Intent(activity, HmsAccountActivity.class);
            activity.startActivity(intent);
    }
    
   public static Activity getCurrentActivity(){
       Log.e(TAG,"HmsAccountActivity getCurrentActivity");
       return UnityPlayer.currentActivity;
   }
   public static Context getCurrentContext(){
          Log.e(TAG,"getCurrentContext Context");
          return UnityPlayer.currentActivity.getApplicationContext();
//        return Activity.this;
  }

    public void independentSignIn(String accessToken){
        Log.e(TAG,"independentSignIn accessToken"+accessToken);
        mAuthParam = new AccountAuthParamsHelper(AccountAuthParams.DEFAULT_AUTH_REQUEST_PARAM)
                .setProfile()
                .setAuthorizationCode()
                .createParams();
        mAuthManager = AccountAuthManager.getService(this, mAuthParam);
        Intent intent=mAuthManager.getIndependentSignInIntent(accessToken);
        startActivityForResult(intent,10011);
    }


   @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        Log.e(TAG,"onActivityResult"+_intent+requestCode);
        Log.e(TAG,"signIn onActivityResult get code success "+requestCode+resultCode+data);
        if(requestCode==Constant.REQUEST_SIGN_IN_LOGIN||requestCode==Constant.REQUEST_SIGN_IN_LOGIN_CODE){
            Task<AuthAccount> authAccountTask = AccountAuthManager.parseAuthResultFromIntent(data);
            if (authAccountTask.isSuccessful()) {
                Log.e(TAG,"signIn onActivityResult parseAuthResultFromIntent isSuccessful");
                mAuthAccount=authAccountTask.getResult();
                Log.e(TAG,"mAuthAccount getAccessToken "+mAuthAccount.getAccessToken());
            }else{
                Log.e(TAG,"signIn onActivityResult parseAuthResultFromIntent fail");
            }
        }
        if(mCallback!=null){
            Log.e(TAG,"signIn onActivityResult call mCallback");
            mCallback.onActivityResult(requestCode, resultCode);
        }
        finish();
    }

}
