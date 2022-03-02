package com.unity.hms.account;

import android.os.Bundle;
import android.app.Activity;
import android.content.Intent;
import com.huawei.hms.support.account.AccountAuthManager;
import com.huawei.hms.support.account.request.AccountAuthParams;
import com.huawei.hms.support.account.service.AccountAuthService;
import com.huawei.hms.support.account.request.AccountAuthParamsHelper;
import android.util.Log;

public class HmsAccountActivity extends Activity {
    private static AccountAuthService mAuthManager;
    private static AccountAuthParams mAuthParam;
    private static IAccountCallback mCallback;
    private static String mAccessToken;
    private static int mRequestCode;

    private static String mIntent = "test";

    public static void setIntent(String intent){
        mIntent=intent;
    }
    public static void setAccessToken(String token){
        mAccessToken=token;
    }
    public static void setAuthParam(AccountAuthParams AuthParam){
        mAuthParam=AuthParam;
    }
    public static void setCallback(IAccountCallback callback){
        mCallback=callback;
    }
    public static void setRequestCode(int requestCode){
        mRequestCode=requestCode;
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        switch (mIntent) {
            case "signIn":
                signIn();
                break;
            case "independentSignIn":
                independentSignIn(mAccessToken);
                break;
            default:
                break;
        }
    }

    public static void start(Activity activity){
        Intent intent = new Intent(activity, HmsAccountActivity.class);
        activity.startActivity(intent);
    }

    public void signIn() {
        mAuthManager = AccountAuthManager.getService(this, mAuthParam);
        startActivityForResult(mAuthManager.getSignInIntent(), mRequestCode);
    }

    public void independentSignIn(String accessToken){
        mAuthManager = AccountAuthManager.getService(this, mAuthParam);
        Intent intent=mAuthManager.getIndependentSignInIntent(accessToken);
        startActivityForResult(intent,mRequestCode);
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if(mCallback!=null){
            mCallback.onActivityResult(requestCode, resultCode,data);
        }
        mRequestCode=0;
        finish();
    }
}
