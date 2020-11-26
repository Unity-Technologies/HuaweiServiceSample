package com.hms.hms_activity;

import android.os.Bundle;

import com.huawei.hms.analytics.HiAnalytics;
import com.huawei.hms.analytics.HiAnalyticsTools;
import com.unity3d.player.UnityPlayerActivity;

import com.huawei.agconnect.appmessaging.AGConnectAppMessaging;
import com.huawei.hms.aaid.HmsInstanceId;

public class HmsActivity extends UnityPlayerActivity {
   private AGConnectAppMessaging appMessaging;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        HiAnalyticsTools.enableLog();
        HiAnalytics.getInstance(this);
        appMessaging = AGConnectAppMessaging.getInstance();
    }
}
