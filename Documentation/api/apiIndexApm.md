# HuaweiService.apm

#### Scenario: Monitoring application performance data``监控应用性能数据``
| Description | Api | Reference |
---|---|---
Android: ANR data, startup data, screen data, HTTP/HTTPS network performance data, foreground and background activity data<br>``Android：ANR数据、启动数据、屏幕数据、HTTP/HTTPS网络性能数据、前台和后台活动数据``|Basic functions, no interface involved<br>``基础功能，不涉及接口``|
iOS: Application startup performance data, application screen performance data, HTTP/HTTPS network performance data.<br>``iOS：应用启动性能数据、应用屏幕性能数据、HTTP/HTTPS网络性能数据。``|Basic functions, no interface involved<br>``基础功能，不涉及接口``|
Web: page and network performance data.<br>``Web：页面和网络性能数据。``|Basic functions, no interface involved<br>``基础功能，不涉及接口``|

#### Scenario: Adding custom tracking records``添加自定义跟踪记录``
| Description | Api | Reference |
---|---|---
Creates a custom trace. traceName indicates the trace name.<br>``创建自定义跟踪记录；启动自定义跟踪；停止自定义跟踪记录,添加自定义属性,添加自定义指标``|createCustomTrace(String traceName)                    |[apms](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/apms)              
Starts a custom trace. <br>``启动、停止自定义跟踪记录``|start()、stop() |[customtrace](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/customtrace)
Sets the attribute names and values of a custom trace.<br>``设置自定义跟踪记录属性名称和属性值。``|putProperty(String propertyName, String propertyValue) |[customtrace](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/customtrace)
Removes an existing attribute from a CustomTrace instance.<br>``从CustomTrace实例中移除已存在属性。`` |removeProperty(String propertyName) |[customtrace](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/customtrace)
Obtains a custom attribute value.<br>``获取自定义属性值。``|getProperty(String propertyName)|[customtrace](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/customtrace)
Adds an indicator value for a custom trace.<br>``增加自定义跟踪记录指标的指标值。`` |incrementMeasure(String measureName, long measureValue)|[customtrace](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/customtrace)
Obtains an indicator value for a custom trace. <br>``获取自定义跟踪记录指标值。`` |getMeasure(String measureName)|[customtrace](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/customtrace)
Adds an indicator for a custom trace. <br>``添加自定义跟踪记录指标。``|putMeasure(String measureName, long measureValue) |[customtrace](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/customtrace)
Obtains all attributes of a custom trace. <br>``获取自定义跟踪记录的所有属性。`` |getTraceProperties() |[customtrace](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/customtrace)

#### Scenario: Time-consuming tracking method``跟踪方法耗时``
| Description | Api | Reference |
---|---|---
Creates a custom trace. traceName indicates the trace name.<br>``跟踪方法耗时``|@AddCustomTrace(name = "onCreateCustomTrace", enabled = true)|[apms](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/apms)<br>C# properties\[AddCustomTrace("onCreateCustomTrace", true)\]

#### Scenario: Adding monitoring indicators for specific network requests``添加针对特定网络请求的监控指标``
| Description | Api | Reference |
---|---|---
Creates a network request indicator instance to collect network performance data. <br>``创建网络请求指标实例，用于采集网络性能数据。``|createNetworkMeasure(String url, String httpMethod) |[apms](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/apms)
Sets the request start time/end time and reports network request indicators and custom attribute dat<br>``启动，停止网络请求指标``|start()、stop() |[networkmeasure](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/networkmeasure)
Sets the response code of a request. <br>``设置请求的响应码。``|setStatusCode(int statusCode)|[networkmeasure](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/networkmeasure)
Sets the request body size.<br>``设置请求体大小。``|setBytesSent(long btyesSent)|[networkmeasure](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/networkmeasure)
Sets the response body size.<br>``设置响应体大小。``|setBytesReceived(long bytesReceived) |[networkmeasure](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/networkmeasure)
Sets the response body type specified by contentType. <br>``设置响应体contentType类型。``|setContentType(String contentType)|[networkmeasure](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/networkmeasure)
Sets the custom attribute name and value of a network request.<br>``设置网络请求的自定义属性名称和属性值。`` |putProperty(String propertyName, String propertyValue)|[networkmeasure](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/networkmeasure)
Removes an existing attribute from a NetworkMeasure instance. <br>``从NetworkMeasure实例中移除已存在属性。`` |removeProperty(String propertyName)|[networkmeasure](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/networkmeasure)
Obtains all attributes from a NetworkMeasure instance.<br>``从NetworkMeasure实例中获取所有属性。``|getProperties()|[networkmeasure](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/networkmeasure)
Obtains a custom attribute value. <br>``获取自定义属性值。``|getProperty(String propertyName)|[networkmeasure](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/networkmeasure)

#### Scenario: View debug log``查看调试日志``
| Description | Api | Reference |
---|---|---
View APM SDK logs<br>``查看APM SDK日志``|android:name="apms\_debug\_log\_enabled"<br>android:value="false" />|
View APM plugin log<br>``查看APM插件日志``|gradlew app:assembleDebug --debug --stacktrace |

#### Scenario: Disable ANR monitoring``停用ANR监控``
| Description | Api | Reference |
---|---|---
Sets whether to enable APM to collect performance monitoring data. If this parameter is set to false, APM stops collecting app performance data. The default value is true.<br>``启用ARM监控、停用ANR监控``|enableAnrMonitor(boolean enable)|[apms](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/apms)

#### Scenario: Disable APM performance monitoring``停用APM性能监控``
| Description | Api | Reference |
---|---|---
Sets whether to enable APM to collect performance monitoring data. If this parameter is set to false, APM stops collecting app performance data. The default value is true.<br>``启用APM监控、停用APM监控``|enableCollection(boolean enable)|[apms](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/apms)




