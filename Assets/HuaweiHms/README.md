# HuaweiHms
## Prepare information
### 1.  Enable AndroidManifest.xml
    Edit -> Project Settings -> Player -> Android(icon) -> Publishing Settings -> Build

    enable `Custom Main Manifest`
`We should enable AndroidManifest when we use push or location sdk.`

**If Unity Version is 2018, there is not AndroidManifest checkbox, but you can put `AndroidManifest.xml` under `Assets/Plugins/Android`.**
### 2.  Enable project gradle
    Edit -> Project Settings -> Player -> Android(icon) -> Publishing Settings -> Build

    enable `Custom Base Gradle Template`
**If unity version is 2018, you should add implentment and other configuartion on `MainGradleTemplate`.**
### 3.  Enable app gradle
    Edit -> Project Settings -> Player -> Android(icon) -> Publishing Settings -> Build

    enable `Custom Launcher Gradle Template`
**If unity version is 2018, you should add implentment and other configuartion on `MainGradleTemplate`.**
### 4.  Enable unity library gradle
    Edit -> Project Settings -> Player -> Android(icon) -> Publishing Settings -> Build

    enable `Custom Main Gradle Template`
### 5.  Signature
    Edit -> Project Settings -> Player -> Android(icon) -> Publishing Settings -> Keystore Manager

    Keytore... -> creat new

`We should enter password when you open unity, otherwise We cannot build.`
**We donnot need add singnature on gradle**
### 6.  Package name
    Edit -> Project Settings -> Player

    package name is `com.${Company Name}.${Product Name}`
### 7.  Agconnect-services.json
    We should put json under `Assets/Plugins/Android`

`We must generate agconnect-services.json if we use analytic, push or location sdk.`
### 8.  Get activity
    `Common.GetActivity()`
## SDK reference
### Ads
https://developer.huawei.com/consumer/cn/doc/development/HMS-Guides/ads-sdk-development-process

https://developer.huawei.com/consumer/cn/doc/development/HMS-References/3030501
#### Analytic
https://developer.huawei.com/consumer/cn/doc/development/HMS-Guides/Development-Guide

https://developer.huawei.com/consumer/cn/doc/development/HMS-References/3021004
### Push
https://developer.huawei.com/consumer/cn/doc/development/HMS-Guides/push-use-cases

https://developer.huawei.com/consumer/cn/doc/development/HMS-References/push-aaid-pkg
### Location
https://developer.huawei.com/consumer/cn/doc/development/HMS-Guides/location-description

https://developer.huawei.com/consumer/cn/doc/development/HMS-References/locationv4

## SDK
### Ads
### Analytic
***Analytic initialize must initialize on `onCreate` of the first activity .***
You can extend the UnityPlayerActivity file, and put java file on `Plugins/Android`.
```
public class HmsAnalyticActivity extends UnityPlayerActivity {
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        HiAnalyticsTools.enableLog();//analytic initialize
        HiAnalytics.getInstance(this);
    }
}
```
Then you should set activity of `AndroidManifest.xml`
```
 <application>
    <activity android:name="com.hms.hms_analytic_activity.HmsAnalyticActivity"
              android:theme="@style/UnityThemeSelector">
        <intent-filter>
            <action android:name="android.intent.action.MAIN" />
            <category android:name="android.intent.category.LAUNCHER" />
        </intent-filter>
        <meta-data android:name="unityplayer.UnityActivity" android:value="true" />
    </activity>
    ...
</application>
```
**if you initialize analytic, you should add analytic implentment on mainTemplate.gradle**
### Push
We must set service.
1.  Implement interface `IPushServiceListener`
2.  Get Receiver by method `PushListenerRegister.RegisterListener`
3.  add to AndroidManifest.xml
```
<application>
    ...
    <service
        android:name="com.unity.hms.push.MyPushService"
        android:exported="false">
        <intent-filter>
            <action android:name="com.huawei.push.action.MESSAGING_EVENT"/>
        </intent-filter>
    </service>
    ...
</application>
```
`android:name` is fixed.
### Location
***We should add implentment `com.android.support:appcompat-v7:28.0.0` to launcherTemplate***

We must set receiver.
#### LocationBroadcastReceiver
1.  Implement interface `IBroadcastReceiver`
2.  Get Receiver by method `BroadcastRegister.CreateLocationReceiver`
3.  add to AndroidManifest.xml
```
<application>
    ...
    <receiver
            android:name="com.unity.hms.location.LocationBroadcastReceiver"
            android:exported="true">
        <intent-filter>
            <action android:name=`${Your action name}` />
        </intent-filter>
    </receiver>
    ...
</application>
```
`android:name` is fixed.

You can set value of `action android:name`. But the value should be the same as the parameter of `intent.setAction`.
#### GeoFenceReceiver
1.  Implement interface `IBroadcastReceiver`
2.  Get Receiver by method `BroadcastRegister.CreateGeoFenceReceiver`
3.  add to AndroidManifest.xml
```
<application>
    ...
    <receiver
            android:name="com.unity.hms.location.GeoFenceBroadcastReceiver"
            android:exported="true">
        <intent-filter>
            <action android:name=`${Your action name}` />
        </intent-filter>
    </receiver>
    ...
</application>
```
`android:name` is fixed.

You can set value of `action android:name`. But the value should be the same as the parameter of `intent.setAction`.