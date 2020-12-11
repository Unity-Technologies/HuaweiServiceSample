package com.hms.hms_analytic_activity;

import android.os.Bundle;

import com.huawei.hms.analytics.HiAnalytics;
import com.huawei.hms.analytics.HiAnalyticsTools;
import com.unity3d.player.UnityPlayerActivity;

import com.huawei.agconnect.appmessaging.AGConnectAppMessaging;
import com.huawei.hms.aaid.HmsInstanceId;
import com.hw.unity.Agc.Auth.ThirdPartyLogin.LoginManager;
import android.content.Intent;

public class HmsAnalyticActivity extends UnityPlayerActivity {
   private AGConnectAppMessaging appMessaging;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        HiAnalyticsTools.enableLog();
        HiAnalytics.getInstance(this);
        appMessaging = AGConnectAppMessaging.getInstance();
        appMessaging.setFetchMessageEnable(true);
        appMessaging.setDisplayEnable(true);
        appMessaging.setForceFetch();
        LoginManager.getInstance().initialize(this);

    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data)
    {
        LoginManager.getInstance().onActivityResult(requestCode, resultCode, data);
    }

}
