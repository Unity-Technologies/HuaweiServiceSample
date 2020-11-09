using System.Collections;
using HuaweiHms;
using UnityEngine;

namespace HuaweiHmsDemo
{
    public class RemoteConfigTest : Test<RemoteConfigTest>
    {
        private AGConnectConfig config;
        public static bool develporMode;

        public override void RegisterEvent(TestEvent registerEvent)
        {
            registerEvent("Setting Default In-app Parameter Values", SetDefualtParame);
            registerEvent("Get Cloud Settings", GetCloudSettings);
            registerEvent("Get Cloud Settings work next time", GetCloudSettingsWorkNextTime);
            registerEvent("Switch Developer Mode", SetDeveloperMode);
            registerEvent("Clear Cache", ClearCache);
        }

        public void SetDefualtParame()
        {
            config = AGConnectConfig.getInstance();
            int configId = AndroidUtil.GetId(new Context(), "xml", "remote_config");
            config.applyDefault(configId);

            HashMap map = new HashMap();
            map.put("test2", "true");
            map.put("test3", 123);
            map.put("test4", 123.456);
            map.put("test5", "test-test");

            config.applyDefault(map.toType<Map>());
            showAllValues();
        }

        public void GetCloudSettings()
        {
            config = AGConnectConfig.getInstance();
            config.fetch().addOnSuccessListener(new LocationSuccessListener((AndroidJavaObject o) =>
                {
                    TestTip.Inst.ShowText("activity success");
                    showAllValues();
                }))
                .addOnFailureListener(new HmsFailureListener((Exception e) =>
                {
                    TestTip.Inst.ShowText("activity failure " + e.toString());
                }));
        }

        public void GetCloudSettingsWorkNextTime()
        {
            config = AGConnectConfig.getInstance();
            ConfigValues configValues = config.loadLastFetched();
            config.apply(configValues);
            config.fetch().addOnSuccessListener(new LocationSuccessListener((AndroidJavaObject o) =>
                {
                    TestTip.Inst.ShowText("activity success");
                }))
                .addOnFailureListener(new HmsFailureListener((Exception e) =>
                {
                    TestTip.Inst.ShowText("activity failure " + e.toString());
                }));
            showAllValues();
        }

        public void SetDeveloperMode()
        {
            config = AGConnectConfig.getInstance();
            develporMode = !develporMode;
            config.setDeveloperMode(develporMode);
            TestTip.Inst.ShowText($"set developer mode to {develporMode}");
        }

        public void ClearCache()
        {
            config = AGConnectConfig.getInstance();
            config.clearAll();
            TestTip.Inst.ShowText("Cache is cleared.");
        }

        private void showAllValues()
        {
            config = AGConnectConfig.getInstance();
            Map map = config.getMergedAll();
            var keySet = map.keySet();
            var keyArray = keySet.toArray();
            foreach (var key in keyArray)
            {
                TestTip.Inst.ShowText($"{key}: {map.getOrDefault(key, "default")}");
            }
        }
    }
}