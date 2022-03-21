using HuaweiService;
using HuaweiService.analytic;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Profiling.Memory.Experimental;

namespace HuaweiServiceDemo
{
    public class AnalyticTest:Test<AnalyticTest>
    {
        private HiAnalyticsInstance instance;
        private bool enabled;
        private int level = 0;
        private bool restrictionSharedEnabled;
        
        public AnalyticTest()
        {
            HiAnalyticsTools.enableLog();
            instance = HiAnalytics.getInstance(new Context(),"CN");
        }
        public override void RegisterEvent(TestEvent registerEvent){
            registerEvent("set userId",SetUserId);
            registerEvent("SendProductId",SendProductId);
            registerEvent("SendAnalyticEnable",SendAnalyticEnable);
            registerEvent("CreateClearCache",CreateClearCache);
            registerEvent("Set Favorite Sport",SetFavoriteSport);
            registerEvent("get user profile",getUserProfiles);
            registerEvent("Set push token",SetPushToken);
            registerEvent("set Min Activity Sessions",setMinActivitySessions);
            registerEvent("set Session Duration",setSessionDuration);
            registerEvent("get AAID",getAAID);
            registerEvent("enable log",enableLog);
            registerEvent("page start",pageStart);
            registerEvent("page end",pageEnd);
            registerEvent("set reportPolicies",SetReportPolicies);
            registerEvent("set restriction enabled",SetRestrictionEnabled);
            registerEvent("is restriction enabled",IsRestrictionEnabled);
            registerEvent("set CollectAdsId enabled",SetCollectAdsIdEnabled);
            registerEvent("set restriction shared",SetRestrictionShared);
            registerEvent("is restriction shared",IsRestrictionShared);
            registerEvent("add default event params",AddDefaultEventParams);
            registerEvent("set WXOpenId",SetWXOpenId);
            registerEvent("set WXUnionId",SetWXUnionId);
            registerEvent("set WXAppId",SetWXAppId);
        }
        
        public void SetWXOpenId()
        {
            instance.setWXOpenId("OpenId");
            TestTip.Inst.ShowText("Set WXOpenId is OpenId");
        }
        
        public void SetWXUnionId()
        {
            instance.setWXUnionId("UnionId");
            TestTip.Inst.ShowText("Set WXUnionId is UnionId");
        }
        
        public void SetWXAppId()
        {
            instance.setWXAppId("AppId");
            TestTip.Inst.ShowText("Set WXAppId is AppId");
        }
        
        public void SetRestrictionEnabled()
        {
            enabled = !enabled;
            instance.setRestrictionEnabled(enabled);
            TestTip.Inst.ShowText(enabled?"ENABLED":"DISABLED");
        }

        public void IsRestrictionEnabled()
        {
            enabled = instance.isRestrictionEnabled();
            TestTip.Inst.ShowText("The return value obtained from the isRestrictionEnabled method is " + enabled + ".");
        }

        public void SetCollectAdsIdEnabled()
        {
            instance.setCollectAdsIdEnabled(true);
            TestTip.Inst.ShowText("To allow collection of ad identifiers.");
            instance.setCollectAdsIdEnabled(false);
            TestTip.Inst.ShowText("Set the collection of ad identifiers is not allowed.");
        }
        
        public void SetRestrictionShared()
        {
            restrictionSharedEnabled = !restrictionSharedEnabled;
            instance.setRestrictionShared(restrictionSharedEnabled);
            TestTip.Inst.ShowText(restrictionSharedEnabled?"ENABLED":"DISABLED");
        }

        public void IsRestrictionShared()
        {
            restrictionSharedEnabled = instance.isRestrictionShared();
            TestTip.Inst.ShowText("The return value obtained from the isRestrictionShared method is " + restrictionSharedEnabled + ".");
        }
        
        public void AddDefaultEventParams()
        {
            Bundle bundle_pre1 = new Bundle();
            bundle_pre1.putString(HAParamType.PRODUCTID,"item_id");
            instance.addDefaultEventParams(bundle_pre1);
            TestTip.Inst.ShowText("Add Default Event Params is " + HAParamType.PRODUCTID);
        }
        
        public void SetReportPolicies()
        {
            ReportPolicy appLaunchPolicy = ReportPolicy.ON_APP_LAUNCH_POLICY;
            ReportPolicy scheduledTimePolicy = ReportPolicy.ON_SCHEDULED_TIME_POLICY;
            scheduledTimePolicy.setThreshold(600);
            TestTip.Inst.ShowText("Set the interval for the scheduled reporting policy to 600 seconds." );
            long threshold = scheduledTimePolicy.getThreshold();
            bool isEqual = threshold.Equals((long)600);
            if (isEqual == true)
            {
                TestTip.Inst.ShowText("ScheduledTimePolicy set successfully.");
            }
            else
            {
                TestTip.Inst.ShowText("ScheduledTimePolicy set failed.");
            }
            HuaweiService.HashSet<ReportPolicy> reportPolicies  = new HuaweiService.HashSet<ReportPolicy>();
            reportPolicies.add(scheduledTimePolicy);
            reportPolicies.add(appLaunchPolicy);
            instance.setReportPolicies(reportPolicies);
            TestTip.Inst.ShowText("Set Reporting policies ScheduledTimePolicy and AppLaunchPolicy.");
        }

        public void SetUserId()
        {
            instance.setUserId("unity test Id");
            Util.showToast("userId set");
        }
        
        public void SendProductId()
        {
            Bundle b1 = new Bundle();
            b1.putString(HAParamType.PRODUCTID, "123456");
            instance.onEvent(HAEventType.ADDPRODUCT2CART, b1);
            Util.showToast("product id set");

        }
        
        public void SendAnalyticEnable()
        {
            enabled = !enabled;
            instance.setAnalyticsEnabled(enabled);
            TestTip.Inst.ShowText(enabled?"ENABLED":"DISABLED");
        }
        
        public void CreateClearCache()
        {
            instance.clearCachedData();
            Util.showToast("Clear Cache");
        }

        public void SetFavoriteSport()
        {
            instance.setUserProfile("favor_sport", "running");
            Util.showToast("set favorite");
        }
        
        public void SetPushToken()
        {
            instance.setPushToken("fffff");
            Util.showToast("set push token as ffff");
        }
        
        public void setMinActivitySessions()
        {
            instance.setMinActivitySessions(10000);
            Util.showToast("setMinActivitySessions 10000");
        }
        
        public void setSessionDuration()
        {
            instance.setSessionDuration(900000);
            Util.showToast("setMinActivitySessions 900000");
        }
        
        public void getAAID()
        {

            try
            {
                instance.getAAID().addOnSuccessListener(new HmsSuccessListener<string>((aaidResult) =>
                {
                    TestTip.Inst.ShowText("getAAID success:" + aaidResult);
                })).addOnFailureListener(new HmsFailureListener((e) =>
                {
                    TestTip.Inst.ShowText($"getAAID failed: {e.toString()}");
                }));
            }
            catch (System.Exception exception)
            {
                TestTip.Inst.ShowText(exception.ToString());
            }
        }

        public void getUserProfiles()
        {
            getUserProfiles(false);
            getUserProfiles(true);
        }
        
        public void getUserProfiles(bool preDefined)
        {
            var profiles = instance.getUserProfiles(preDefined);
            var keySet = profiles.keySet();
            var keyArray = keySet.toArray();
            foreach (var key in keyArray)
            {
                TestTip.Inst.ShowText($"{key}: {profiles.getOrDefault(key, "default")}");
            }
        }
        
        public void pageStart()
        {
            instance.pageStart("page test", "page test");
            TestTip.Inst.ShowText("set page start: page test, page test");
        }

        public void pageEnd()
        {
            instance.pageEnd("page test");
            TestTip.Inst.ShowText("set page end: page test");
        }

        public void enableLog()
        {
            HiAnalyticsTools.enableLog(level + 3);
            TestTip.Inst.ShowText($"current level {level + 3}");
            level = (level + 1) % 4;
        }
    }
}

