# HMS
## Introduction
This package enables parts of Hms Core service in Unity for Android Build, which is implemented by wrapping Hms SDK. Name and usage of corresponding classes and functions are the same. You can write code by referring [Hms SDK document](https://developer.huawei.com/consumer/en/doc/development/HMS-Guides/account-introduction-v4). But still there are some differences during development. We highly recommend downloading [example project](https://github.com/Unity-Technologies/HMSSDKSample) as a reference. 

There are 4 Kits included.
* Ads Kit: [reference](https://developer.huawei.com/consumer/en/doc/development/HMS-Guides/ads-sdk-development-process) and [param](https://developer.huawei.com/consumer/en/doc/development/HMS-Guides/ads-sdk-development-process)
    * Rewarded Ads 
    * Interstitial Ads 
* Push Kit: [reference](https://developer.huawei.com/consumer/en/doc/development/HMS-Guides/push-use-cases) and [param](
https://developer.huawei.com/consumer/en/doc/development/HMS-References/push-aaid-pkg) 
    * all
* Location Kit: [reference](https://developer.huawei.com/consumer/en/doc/development/HMS-Guides/location-description) and [param](
https://developer.huawei.com/consumer/en/doc/development/HMS-References/locationv4) 
    * all
* Analytics Kit: [reference](https://developer.huawei.com/consumer/en/doc/development/HMS-Guides/Development-Guide) and [param](
https://developer.huawei.com/consumer/en/doc/development/HMS-References/3021004)
    * all

## Preparation
Before doing this step, you need to create HMS Account and project according to [the HMS document](https://developer.huawei.com/consumer/en/doc/development/HMS-Guides/Preparations).

In this step, we will setup build environment for building Android apk with HMS SDK. After finish the following preparation.

### 1.  Enable AndroidManifest.xml
    Edit -> Project Settings -> Player -> Android(icon) -> Publishing Settings -> Build

    enable `Custom Main Manifest`
`We should enable AndroidManifest when we use push or location sdk.`

**If Unity Version is 2019.2 or before, there is not AndroidManifest checkbox, but you can put `AndroidManifest.xml` under `Assets/Plugins/Android`.**
### 2.  Enable project gradle
    Edit -> Project Settings -> Player -> Android(icon) -> Publishing Settings -> Build

    enable `Custom Base Gradle Template`
**If unity version is 2019.2 or before, you should add implement and other configuration on `MainGradleTemplate`.**
### 3.  Enable app gradle
    Edit -> Project Settings -> Player -> Android(icon) -> Publishing Settings -> Build

    enable `Custom Launcher Gradle Template`
**If unity version is 2019.2 or before, you should add implement and other configuration on `MainGradleTemplate`.**
### 4.  Enable unity library gradle
    Edit -> Project Settings -> Player -> Android(icon) -> Publishing Settings -> Build

    enable `Custom Main Gradle Template`
### 5.  Signature
    Edit -> Project Settings -> Player -> Android(icon) -> Publishing Settings -> Keystore Manager

    Keytore... -> create new

`We should enter password when you open unity, otherwise We cannot build.`
**We donnot need add signature on gradle**
### 6.  Package name
    Edit -> Project Settings -> Player

    package name is `com.${Company Name}.${Product Name}`
### 7.  Agconnect-services.json
    We should put json under `Assets/Plugins/Android`

`We must generate agconnect-services.json if we use analytic, push or location sdk.`
Reference [Link](https://developer.huawei.com/consumer/en/doc/development/HMSCore-Guides/android-config-agc-0000001050170137) to create agconnect-services.json
### 8.  Get activity
For getting the activity, you can use the following code.
    `Common.GetActivity()`

# SDK
There are corresponding example scene in [example project](https://github.com/Unity-Technologies/HMSSDKSample) for all 4 Kits. For test, you need to build it onto Android mobile build by HMS. Make sure you have created HMS account and project. Then, you can change the configuration and test different functions.
## Ads
In example project, corresponding scene is `Assets/HuaweiHmsDemo/Scenes/HmsAdsSampleScene.unity` and code is `Assets/HuaweiHmsDemo/demo/test/ads/AdsTest.cs`.

## Analytic
In example project, corresponding scene is `Assets/HuaweiHmsDemo/Scenes/HmsAnalyticSampleScene.unity` and code is `Assets/HuaweiHmsDemo/demo/test/AnalyticTest.cs`.

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
## Push
In example project, corresponding scene is `Assets/HuaweiHmsDemo/Scenes/HmsPushSampleScene.unity` and code is `Assets/HuaweiHmsDemo/demo/test/PushTest.cs`.

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
## Location
***We should add implentment `com.android.support:appcompat-v7:28.0.0` to launcherTemplate***
In example project, corresponding scene is `Assets/HuaweiHmsDemo/Scenes/HmsLocationSampleScene.unity` and code is `Assets/HuaweiHmsDemo/demo/test/location/LocationTest.cs`.

We must set receiver.
### LocationBroadcastReceiver
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
### GeoFenceReceiver
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