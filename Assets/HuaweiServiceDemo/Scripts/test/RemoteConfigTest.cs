using System.Collections;
using HuaweiService;
using HuaweiService.RemoteConfig;
using UnityEngine;

namespace HuaweiServiceDemo
{
    public class RemoteConfigTest : Test<RemoteConfigTest>
    {
        private AGConnectConfig config;
        public static bool develporMode;

        public override void RegisterEvent(TestEvent registerEvent)
        {
            registerEvent("set xml Value", SetXmlValue);
            registerEvent("set map Value", SetMapValue);
            registerEvent("Get Cloud Settings", GetCloudSettings);
            registerEvent("Get Cloud Settings work next time", GetCloudSettingsWorkNextTime);
            registerEvent("Get Cloud Settings - 5 mins", GetCloudSettingsFiveMins);
            registerEvent("Switch Developer Mode", SetDeveloperMode);
            registerEvent("Clear Cache", ClearCache);
            registerEvent("Get Value Source", GetAllValueWithSource);
        }

        public void SetXmlValue()
        {
            // get instatance of AGConnectConfig
            config = AGConnectConfig.getInstance();
            // get config resId of xml file
            int configId = AndroidUtil.GetId(new Context(), "xml", "remote_config");
            // Sets a default value for a parameter.
            config.applyDefault(configId);
            showAllValues();
        }
        
        public void SetMapValue()
        {
            config = AGConnectConfig.getInstance();
            HashMap map = new HashMap();
            map.put("test2", "true");
            map.put("test3", 222);
            map.put("test4", 666.456);
            map.put("test5", "fromMap");
            // Sets a default value for a parameter.
            config.applyDefault(map.toType<Map>());
            showAllValues();
        }

        // fetch cloud setting, add success listener and failure listener
        public void GetCloudSettings()
        {
            config = AGConnectConfig.getInstance();
            config.fetch().addOnSuccessListener(new HmsSuccessListener<ConfigValues>((ConfigValues configValues) =>
                {
                    // Applies parameter values
                    config.apply(configValues);
                    TestTip.Inst.ShowText("activity success");
                    // Checks whether the ConfigValues object contains a requested key.
                    TestTip.Inst.ShowText($"configValues contains {configValues.containKey("CloudBool")}");
                    // Returns the value of type for a key.
                    TestTip.Inst.ShowText($"configValues as string {configValues.getValueAsString("CloudString")}");
                    TestTip.Inst.ShowText($"configValues as byte first byte {configValues.getValueAsByteArray("CloudByte")[0]}");
                    TestTip.Inst.ShowText($"configValues as long {configValues.getValueAsLong("CloudLong").longValue()}");
                    TestTip.Inst.ShowText($"configValues as double {configValues.getValueAsDouble("CloudDouble").doubleValue()}");
                    TestTip.Inst.ShowText($"configValues as bool {configValues.getValueAsBoolean("CloudBool").booleanValue()}");
                    
                    showAllValues();
                }))
                .addOnFailureListener(new HmsFailureListener((Exception e) =>
                {
                    TestTip.Inst.ShowText("activity failure " + e.toString());
                }));
        }

        // apply the config value laste fetched
        public void GetCloudSettingsWorkNextTime()
        {
            config = AGConnectConfig.getInstance();
            ConfigValues configValues = config.loadLastFetched();
            config.apply(configValues);
            config.fetch().addOnSuccessListener(new HmsSuccessListener<ConfigValues>((ConfigValues o) =>
                {
                    TestTip.Inst.ShowText("activity success");
                }))
                .addOnFailureListener(new HmsFailureListener((Exception e) =>
                {
                    TestTip.Inst.ShowText("activity failure " + e.toString());
                }));
            showAllValues();
        }

        // Fetches latest parameter values from the cloud at a custom interval. 
        // If the method is called within an interval, cached data is returned.
        public void GetCloudSettingsFiveMins()
        {
            config = AGConnectConfig.getInstance();
            config.fetch(300).addOnSuccessListener(new HmsSuccessListener<ConfigValues>((ConfigValues configValues) =>
                {
                    config.apply(configValues);
                    TestTip.Inst.ShowText("activity success");
                }))
                .addOnFailureListener(new HmsFailureListener((Exception e) =>
                {
                    TestTip.Inst.ShowText("activity failure " + e.toString());
                }));
            showAllValues();
        }
        
        // Enables the developer mode, 
        // in which the number of times that the app fetches data from Remote 
        // Configuration is not limited, and traffic control is still performed over the cloud.
        public void SetDeveloperMode()
        {
            config = AGConnectConfig.getInstance();
            develporMode = !develporMode;
            config.setDeveloperMode(develporMode);
            TestTip.Inst.ShowText($"set developer mode to {develporMode}");
        }

        // Clears all cached data, 
        // including the data fetched from Remote Configuration and the default values passed.
        public void ClearCache()
        {
            config = AGConnectConfig.getInstance();
            config.clearAll();
            TestTip.Inst.ShowText("Cache is cleared.");
        }

        // get all configs, print key and value pair
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
        
        // get all configs, print key and the source of a key.
        private void GetAllValueWithSource()
        {
            config = AGConnectConfig.getInstance();
            Map map = config.getMergedAll();
            var keySet = map.keySet();
            var keyArray = keySet.toArray();
            foreach (var key in keyArray)
            {
                TestTip.Inst.ShowText($"{key}: {config.getSource(key)}");
            }
        }
    }
}