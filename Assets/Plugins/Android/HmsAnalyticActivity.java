package com.hms.hms_analytic_activity;

import android.os.Bundle;

import com.huawei.hms.analytics.HiAnalytics;
import com.huawei.hms.analytics.HiAnalyticsTools;
import com.unity3d.player.UnityPlayerActivity;

import com.huawei.agconnect.appmessaging.AGConnectAppMessaging;
import com.huawei.hms.aaid.HmsInstanceId;
import com.hw.unity.Agc.Auth.ThirdPartyLogin.LoginManager;
import android.content.Intent;
import java.lang.Boolean;
import com.unity3d.player.UnityPlayer;

import androidx.core.app.ActivityCompat;

public class HmsAnalyticActivity extends UnityPlayerActivity {
    private AGConnectAppMessaging appMessaging;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        HiAnalyticsTools.enableLog();
        HiAnalytics.getInstance(this);
        appMessaging = AGConnectAppMessaging.getInstance();
        if(appMessaging != null){
            appMessaging.setFetchMessageEnable(true);
            appMessaging.setDisplayEnable(true);
            appMessaging.setForceFetch();
        }
        LoginManager.getInstance().initialize(this);

        boolean pretendCallMain = false;
        if(pretendCallMain == true){
            main();
        }
    }

    private static void callCrash() {
            throwCrash();
        }
        private static void throwCrash() {
            throw new NullPointerException();
        }
        public static void main(){
            JavaCrash();
        }
        private static void JavaCrash(){
            new Thread(new Runnable() {
                            @Override
                            public void run() { // 子线程
                                UnityPlayer.currentActivity.runOnUiThread(new Runnable() {
                                    @Override
                                    public void run() {
                                        callCrash();
                                    }
                                });
                            }
             }).start();
        }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data)
    {
        LoginManager.getInstance().onActivityResult(requestCode, resultCode, data);
    }

}
