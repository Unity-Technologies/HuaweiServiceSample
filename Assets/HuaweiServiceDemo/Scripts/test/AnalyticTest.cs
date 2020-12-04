using HuaweiService;
using HuaweiService.analytic;
using UnityEngine;

namespace HuaweiServiceDemo
{
    public class AnalyticTest:Test<AnalyticTest>
    {
        private HiAnalyticsInstance instance;
        private bool enabled;
        private int level = 0;
        public AnalyticTest()
        {
            HiAnalyticsTools.enableLog();
            instance = HiAnalytics.getInstance(new Context());
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

