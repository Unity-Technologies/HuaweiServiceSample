# HuaweiService.RemoteConfig

#### Scenario: Application configuration items``应用配置项``
| Description | Api | Reference |
---|---|---
Sets a default value for a parameter.<br>``设置默认参数(resId)``|applyDefault(int resId) |[https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectconfig](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectconfig)<br>``The resId cannot be obtained like Android. The specific usage is explained in manual "3).Optional: Using an XML resource file".`` <br><br> [Example](https://github.com/Unity-Technologies/HuaweiServiceSample/blob/8a72eb9b34a2d6f1cfe3a8d3340dbf2c6ae1eb4b/Assets/HuaweiServiceDemo/Scripts/test/RemoteConfigTest.cs#L25)
Sets a default value for a parameter.<br>``设置默认参数(Map)``|applyDefault(Map<String, Object> map)|[https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectconfig](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectconfig) <br><br> [Example](https://github.com/Unity-Technologies/HuaweiServiceSample/blob/8a72eb9b34a2d6f1cfe3a8d3340dbf2c6ae1eb4b/Assets/HuaweiServiceDemo/Scripts/test/RemoteConfigTest.cs#L33)
Applies parameter values. <br>``生效配置参数``|apply(ConfigValues values) |[https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectconfig](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectconfig) <br><br> [Example](https://github.com/Unity-Technologies/HuaweiServiceSample/blob/8a72eb9b34a2d6f1cfe3a8d3340dbf2c6ae1eb4b/Assets/HuaweiServiceDemo/Scripts/test/RemoteConfigTest.cs#L47)
Returns all values obtained after the combination of the default values and values in Remote Configuration.<br>``云端值与默认值合并``|getMergedAll()|[https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectconfig](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectconfig) <br><br> [Example](https://github.com/Unity-Technologies/HuaweiServiceSample/blob/8a72eb9b34a2d6f1cfe3a8d3340dbf2c6ae1eb4b/Assets/HuaweiServiceDemo/Scripts/test/RemoteConfigTest.cs#L115)

#### Scenario: Get the cloud parameters``获取云端参数``
| Description | Api | Reference |
---|---|---
Fetches latest parameter values from Remote Configuration at the default interval of 12 hours. If the method is called within an interval, cached data is returned.<br>``获取云端配置项，默认间隔``|fetch()|[https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectconfig](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectconfig) <br><br> [Example](https://github.com/Unity-Technologies/HuaweiServiceSample/blob/8a72eb9b34a2d6f1cfe3a8d3340dbf2c6ae1eb4b/Assets/HuaweiServiceDemo/Scripts/test/RemoteConfigTest.cs#L69)
Fetches latest parameter values from Remote Configuration at a customized interval. If the method is called within an interval, cached data is returned.<br>``获取云端配置项，自定义间隔``|fetch(long intervalSeconds)|[https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectconfig](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectconfig) <br><br> [Example](https://github.com/Unity-Technologies/HuaweiServiceSample/blob/8a72eb9b34a2d6f1cfe3a8d3340dbf2c6ae1eb4b/Assets/HuaweiServiceDemo/Scripts/test/RemoteConfigTest.cs#L85)
Returns the value of the boolean/double/long/string/byte type for a key.<br>``返回key对应的value值``|getValueAsBoolean(String key)/getValueAsDouble(String key)/getValueAsLong(String key)/getValueAsString(String key)/getValueAsByteArray(String key)|[https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectconfig](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectconfig) <br><br> [Example](https://github.com/Unity-Technologies/HuaweiServiceSample/blob/8a72eb9b34a2d6f1cfe3a8d3340dbf2c6ae1eb4b/Assets/HuaweiServiceDemo/Scripts/test/RemoteConfigTest.cs#L59)
Obtains the cached data that is successfully fetched last time.<br>``获取上一次缓存数据`` |loadLastFetched()|[https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectconfig](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectconfig) <br><br> [Example](https://github.com/Unity-Technologies/HuaweiServiceSample/blob/8a72eb9b34a2d6f1cfe3a8d3340dbf2c6ae1eb4b/Assets/HuaweiServiceDemo/Scripts/test/RemoteConfigTest.cs#L72)
Returns the source of a key. <br>``返回Key对应的来源``|getSource(String key)|[https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectconfig](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectconfig) <br><br> [Example](https://github.com/Unity-Technologies/HuaweiServiceSample/blob/8a72eb9b34a2d6f1cfe3a8d3340dbf2c6ae1eb4b/Assets/HuaweiServiceDemo/Scripts/test/RemoteConfigTest.cs#L135)

#### Scenario: Clear cached data``清除缓存数据``
| Description | Api | Reference |
---|---|---
Clears all cached data, including the data fetched from Remote Configuration and the default values passed.<br>``清除数据``|clearAll()|[agconnectconfig](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectconfig) <br><br> [Example](https://github.com/Unity-Technologies/HuaweiServiceSample/blob/8a72eb9b34a2d6f1cfe3a8d3340dbf2c6ae1eb4b/Assets/HuaweiServiceDemo/Scripts/test/RemoteConfigTest.cs#L108)

#### Scenario: Set up developer mode``设置开发者模式``
| Description | Api | Reference |
---|---|---
Enables the developer mode, in which the number of times that the client obtains data from Remote Configuration is not limited, and traffic control is still performed over the cloud.<br>``设置开发者模式``|setDeveloperMode(boolean isDeveloperMode)|[agconnectconfig](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectconfig) <br><br> [Example](https://github.com/Unity-Technologies/HuaweiServiceSample/blob/8a72eb9b34a2d6f1cfe3a8d3340dbf2c6ae1eb4b/Assets/HuaweiServiceDemo/Scripts/test/RemoteConfigTest.cs#L100)





