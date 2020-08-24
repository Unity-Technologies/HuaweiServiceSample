package com.hms.hms_analytic_activity;

import android.os.Bundle;

import com.huawei.hms.analytics.HiAnalytics;
import com.huawei.hms.analytics.HiAnalyticsTools;
import com.unity3d.player.UnityPlayerActivity;

public class HmsAnalyticActivity extends UnityPlayerActivity {
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        HiAnalyticsTools.enableLog();
        HiAnalytics.getInstance(this);
    }
}
