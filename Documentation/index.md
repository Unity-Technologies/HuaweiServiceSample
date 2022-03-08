# Ads Kit (HMS)

## Service Introduction

HUAWEI Ads Kit leverages Huawei devices and Huawei's extensive data capabilities to provide you with the Publisher Service, helping you monetize traffic. Meanwhile, it provides the advertising service for advertisers to deliver personalized campaigns or commercial ads to Huawei device users.The video on this page introduces traffic monetization through HUAWEI Ads Kit and the process for advertisers to display ads.You can click [here](https://developer.huawei.com/consumer/en/training/detail/101582707399567035) to watch the MOOC video about Ads Kit.

### HUAWEI Ads Publisher Service

HUAWEI Ads Publisher Service is a monetization service that leverages Huawei's extensive data capabilities to display high quality ad content in your apps to the vast user base of Huawei devices.

We offer a range of ad formats including [Banner Ads](https://developer.huawei.com/consumer/en/doc/development/HMSCore-Guides-V5/publisher-service-banner-0000001050066915-V5), [Native Ads](https://developer.huawei.com/consumer/en/doc/development/HMSCore-Guides-V5/publisher-service-native-0000001050064968-V5), [Rewarded Ads](https://developer.huawei.com/consumer/en/doc/development/HMSCore-Guides-V5/publisher-service-reward-0000001050066917-V5), [Interstitial Ads](https://developer.huawei.com/consumer/en/doc/development/HMSCore-Guides-V5/publisher-service-interstitial-0000001050064970-V5), [Splash Ads](https://developer.huawei.com/consumer/en/doc/development/HMSCore-Guides-V5/publisher-service-splash-0000001050066919-V5), and [Roll Ads](https://developer.huawei.com/consumer/en/doc/development/HMSCore-Guides-V5/publisher-service-instream-0000001058253743-V5) so you can choose whichever that suits your app best. You can use the HUAWEI Ads SDK to integrate HUAWEI Ads into your app. Once you have chosen an ad format, you are ready to start bringing in revenue using our high-quality advertising services.

We also offer the [Publisher Service Reporting API](https://developer.huawei.com/consumer/en/doc/development/HMSCore-Guides-V5/reporting-api-dev-process-0000001051294727-V5) for you to obtain traffic monetization report data, including the number of ad requests, number of returned ads, click-through rate, and impression rate.

### Identifier Service

Ads Kit provides the open advertising identifier (OAID) and install referrer capabilities for advertisers to deliver personalized ads and attribute conversions.

- An OAID is a non-permanent device identifier. You can use OAIDs to provide personalized ads for users while protecting their privacy. In addition, third-party tracking platforms can provide conversion attributions for advertisers based on OAIDs.

- You and advertisers can obtain app install referrers through APIs provided by Huawei. Advertisers can use install referrers to attribute conversions to different promotion channels.

### Use Cases

- HUAWEI Ads Publisher Service

  HUAWEI Ads offers a range of ad formats, as listed in the following table, to best suit your app's requirements in various scenarios. 

  | <div style="width:100px">Ad Format</div>                     | Ad Type                           | Description                                                  |
  | ------------------------------------------------------------ | --------------------------------- | ------------------------------------------------------------ |
  | [Banner Ads](https://developer.huawei.com/consumer/en/doc/development/HMSCore-Guides-V5/publisher-service-banner-0000001050066915-V5) | Image                             | A banner ad is presented as a bar or block at the top, middle, or bottom of the screen within an app with high visibility for users who use the app regularly or for a long time. |
  | [Native Ads](https://developer.huawei.com/consumer/en/doc/development/HMSCore-Guides-V5/publisher-service-native-0000001050064968-V5) | Image or video                    | A native ad fits seamlessly into the surrounding content to match your app design. |
  | [Rewarded Ads](https://developer.huawei.com/consumer/en/doc/development/HMSCore-Guides-V5/publisher-service-reward-0000001050066917-V5) | Video                             | A rewarded ad is displayed when a user achieves a level, gets respawned, obtains items, bonus points, or opportunities to continue, or upgrades skills in a game. |
  | [Interstitial Ads](https://developer.huawei.com/consumer/en/doc/development/HMSCore-Guides-V5/publisher-service-interstitial-0000001050064970-V5) | Image or video                    | An interstitial ad is displayed when a user starts, pauses, loads, or exits a game or streaming media, achieves a game level, or is redirected in a game or streaming media. |
  | [Splash Ads](https://developer.huawei.com/consumer/en/doc/development/HMSCore-Guides-V5/publisher-service-splash-0000001050066919-V5) | Static image, GIF image, or video | A splash ad is displayed in full screen for 3s immediately when an app is launched. Then the ad will be automatically closed and the app home screen will be displayed. |
  | [Roll Ads](https://developer.huawei.com/consumer/en/doc/development/HMSCore-Guides-V5/publisher-service-instream-0000001058253743-V5) | Image or video                    | Pre-roll: displayed before the video content.Mid-roll: displayed in the middle of the video content.Post-roll: displayed after the video content or several seconds before the video content ends. |

- Identifier service

  The identifier service can be used by the advertising platforms, developers, third-party tracking platforms, and advertisers in different scenarios. For details, please refer to [Use Cases](https://developer.huawei.com/consumer/en/doc/development/HMSCore-Guides-V5/identifier-service-use-cases-0000001050064978-V5).

## Integrating into Your Unity Project

### Register and get verified

Before doing this step, you need to create an HMS Account, project and App according to [the HMS document](https://developer.huawei.com/consumer/en/doc/development/HMS-Guides/Preparations).

![Images/hms/Step1.png](Images/hms/Step1.png)

![Images/hms/Preparation.png](Images/hms/Preparation.png)

Now you have your Huawei HMS Project and App information.

### Create an app

Create Unity project, and you will also need to set up the build environment for building Android apk with HMS SDK. Then, finish the following preparation.

![Images/hms/Step2.png](Images/hms/Step2.png)

In **Editor -> Build Settings**, Switch platform to Andriod and Connect your Android device

![Images/hms/BuildSettings](Images/hms/BuildSettings.png)

In **Player Settings -> Publishing Settings**, enable the following environment checkboxes

![Images/hms/BuildEnvironment](Images/hms/BuildEnvironment.png)

### Prepare for development

According to [HMS integration process introduction](https://developer.huawei.com/consumer/en/codelab/HMSPreparation/index.html#6), we still need to add some configurations to the gradle files for development preparations.

![Images/hms/Step3.png](Images/hms/Step3.png)

You can follow [Huawei documentation guidance](https://developer.huawei.com/consumer/en/codelab/HMSPreparation/index.html#6) to do the configuration, you can also refer and compare with the files in our [Unity example project](https://github.com/Unity-Technologies/HMSSDKSample/tree/master/Assets/Plugins/Android).

1. Enable and add configurations to `AndroidManifest.xml`

   Go to **Edit -> Project Settings -> Player -> Android(icon) -> Publishing Settings -> Build**

   Enable **Custom Main Manifest**

   If Unity Version is **2019.2 or before**, there is no **AndroidManifest** checkbox, but you can put `AndroidManifest.xml` under `Assets/Plugins/Android`.

   ```
       <?xml version="1.0" encoding="utf-8"?>
       <!-- GENERATED BY UNITY. REMOVE THIS COMMENT TO PREVENT OVERWRITING WHEN EXPORTING AGAIN-->
       <manifest
           xmlns:android="http://schemas.android.com/apk/res/android"
           package="com.unity3d.player"
           xmlns:tools="http://schemas.android.com/tools">
           <uses-permission android:name="android.permission.ACCESS_COARSE_LOCATION"/>
           <uses-permission android:name="android.permission.ACCESS_FINE_LOCATION"/>
           <uses-permission android:name="android.permission.ACCESS_BACKGROUND_LOCATION" />
           <uses-permission android:name="com.huawei.hms.permission.ACTIVITY_RECOGNITION" />
           <uses-permission android:name="android.permission.ACTIVITY_RECOGNITION" />
           <uses-permission android:name="android.permission.ACCESS_MOCK_LOCATION" />
           <application>
               <activity android:name="com.hms.hms_analytic_activity.HmsAnalyticActivity"
                       android:theme="@style/UnityThemeSelector">
                   <intent-filter>
                       <action android:name="android.intent.action.MAIN" />
                       <category android:name="android.intent.category.LAUNCHER" />
                   </intent-filter>
                   <meta-data android:name="unityplayer.UnityActivity" android:value="true" />
               </activity>
               <service
                   android:name="com.unity.hms.push.MyPushService"
                   android:exported="false">
                   <intent-filter>
                       <action android:name="com.huawei.push.action.MESSAGING_EVENT"/>
                   </intent-filter>
               </service>
               <receiver
                       android:name="com.unity.hms.location.LocationBroadcastReceiver"
                       android:exported="true">
                   <intent-filter>
                       <action android:name="com.huawei.hmssample.location.LocationBroadcastReceiver.ACTION_PROCESS_LOCATION" />
                   </intent-filter>
               </receiver>
               <receiver
                       android:name="com.unity.hms.location.GeoFenceBroadcastReceiver"
                       android:exported="true">
                   <intent-filter>
                       <action android:name="com.huawei.hmssample.geofence.GeoFenceBroadcastReceiver.ACTION_PROCESS_LOCATION" />
                   </intent-filter>
               </receiver>
           </application>
       </manifest>
   ```

2. Enable and add configurations to project gradle

   Go to **Edit -> Project Settings -> Player -> Android(icon) -> Publishing Settings -> Build**

   Enable **Custom Base Gradle Template** and add the AppGallery Connect plugin and the Maven repository. The path is `Assets/Plugins/Android/baseProjectTemplate.gradle`.

   If your unity version is **2019.2 or before**, you should add implement and other configuration on `MainGradleTemplate.gradle`.

   ```
       // GENERATED BY UNITY. REMOVE THIS COMMENT TO PREVENT OVERWRITING WHEN EXPORTING AGAIN
   
       allprojects {
           buildscript {
               repositories {**ARTIFACTORYREPOSITORY**
                   google()
                   jcenter()
                   maven { url 'https://developer.huawei.com/repo/' }
               }
   
               dependencies {
                   // If you are changing the Android Gradle Plugin version, make sure it is compatible with the Gradle version preinstalled with Unity
                   // See which Gradle version is preinstalled with Unity here https://docs.unity3d.com/Manual/android-gradle-overview.html
                   // See official Gradle and Android Gradle Plugin compatibility table here https://developer.android.com/studio/releases/gradle-plugin#updating-gradle
                   // To specify a custom Gradle version in Unity, go do "Preferences > External Tools", uncheck "Gradle Installed with Unity (recommended)" and specify a path to a custom Gradle version
                   classpath 'com.android.tools.build:gradle:3.6.4'
                   classpath 'com.huawei.agconnect:agcp:1.6.1.300'
                   **BUILD_SCRIPT_DEPS**
               }
           }
   
           repositories {**ARTIFACTORYREPOSITORY**
               google()
               jcenter()
               flatDir {
                   dirs "${project(':unityLibrary').projectDir}/libs"
               }
               maven { url 'https://developer.huawei.com/repo/' }
           }
       }
   
       task clean(type: Delete) {
           delete rootProject.buildDir
       }
   ```

3. Enable and add configurations to app gradle

   Go to **Edit -> Project Settings -> Player -> Android(icon) -> Publishing Settings -> Build**

   Enable **Custom Launcher Gradle Template** and add build dependencies in `launcherTemplate.gradle`. The path is `Assets/Plugins/Android/launcherTmeplate.gradle`.

   If unity version is **2019.2 or before**, you should add implement and other configuration on `MainGradleTemplate`.

   ```
       dependencies {
           implementation project(':unityLibrary')
           implementation 'com.huawei.hms:ads-lite:13.4.49.301'
           implementation 'com.huawei.hms:ads-consent:3.4.49.301'
           implementation 'com.huawei.hms:push:6.1.0.300'
           implementation 'com.huawei.hms:hianalytics:6.3.2.300'
           implementation 'com.huawei.hms:location:6.2.0.300'
           implementation 'com.android.support:appcompat-v7:28.0.0'
           implementation 'com.huawei.agconnect:agconnect-core:1.6.1.300'
           implementation 'com.huawei.hms:hwid:6.1.0.303'
           implementation 'com.huawei.hms:game:6.1.0.301'
           }
   ```
   
4. Enable and add configurations to unity library gradle

   Go to **Edit -> Project Settings -> Player -> Android(icon) -> Publishing Settings -> Build**

   Enable **Custom Main Gradle Template** and add build dependencies. The path is `Assets/Plugins/Android/mainTemplate.gradle`.

   If unity version is **2019.2 or before**, you should add implement and other configuration on `MainGradleTemplate.gradle`.

   ```
   dependencies {
       implementation fileTree(dir: 'libs', include: ['*.jar'])
       implementation 'com.huawei.hms:hianalytics:6.3.2.300'
       implementation 'com.huawei.agconnect:agconnect-core:1.6.1.300'
       implementation 'com.huawei.hms:hwid:6.1.0.303'
       implementation 'com.huawei.hms:game:6.1.0.301'
   **DEPS**}
   ```

5. Signature

   Go to **Edit -> Project Settings -> Player -> Android(icon) -> Publishing Settings -> Keystore Manager**

   Click **Keytore... -> create new**

   ![Images/hms/Keystore.png](Images/hms/Keystore.png)

   You need to enter the password when you open unity, otherwise you cannot build. There's no need to add a signature on gradle.

6. Signing Certificate Fingerprint

   Please refer to Huawei [preparation documentation step 4](https://developer.huawei.com/consumer/en/codelab/HMSPreparation/index.html#3) for generating a SHA256 Certificate Fingerprint.

   ![Images/hms/Fingerprint.png](Images/hms/Fingerprint.png)

   And refer to Huawei [preparation documentation step 5](https://developer.huawei.com/consumer/en/codelab/HMSPreparation/index.html#4) to add Fingerprint to AppGallery Connect.

   ![Images/hms/FingerprintAppGallery.png](Images/hms/FingerprintAppGallery.png)

7. Package name

   Set the package name in **Edit -> Project Settings -> Player**

   The package name is `com.${Company Name}.${Product Name}`.

   You can also complete the rest of the settings here, such as version number, icons, resolution, etc. 

   ![Images/hms/PackageName.png](Images/hms/PackageName.png)

8. `agconnect-services.json`

   We should put the json file under `Assets/Plugins/Android`.

   Add this following message into the json file downloaded from your Huawei developer dashboard. Also, you can [refer to that file](https://github.com/Unity-Technologies/HMSSDKSample/blob/master/Assets/Plugins/Android/agconnect-services.json) in our Unity example project.

   ```
   "agcgw":{
   "backurl":"connect-drcn.dbankcloud.cn",
   "url":"connect-drcn.hispace.hicloud.com"
   },
   ```

   You can refer to [this link](https://developer.huawei.com/consumer/en/doc/development/HMSCore-Guides/android-config-agc-0000001050170137) to create `agconnect-services.json`.

   ![Images/hms/AgcConnectServicesJson.png](Images/hms/AgcConnectServicesJson.png)

9. Configuring Obfuscation Scripts

    Before building the APK, configure the obfuscation configuration file to prevent the HMS Core SDK from being obfuscated.（[Reference](https://developer.huawei.com/consumer/en/doc/development/HMSCore-Guides/config-obfuscation-scripts-0000001188775555)）
    - Open the proguard file in your Unity project and add configurations to exclude the HMS Core SDK from obfuscation.

    ```
    -ignorewarnings
    -keepattributes *Annotation*
    -keepattributes Exceptions
    -keepattributes InnerClasses
    -keepattributes Signature
    -keepattributes SourceFile,LineNumberTable
    -keep class com.huawei.hianalytics.**{*;}
    -keep class com.huawei.updatesdk.**{*;}
    -keep class com.huawei.hms.**{*;}
    -keep class * extends com.huawei.location.router.LocationApiRequest{ *; }
    -keep class * extends com.huawei.hms.core.aidl.IMessageEntity{ *; }
    -keep public class com.huawei.location.nlp.network.** {*; }
    -keep class com.huawei.wisesecurity.ucs.**{*;}
    ```

    - (Optional) Configure the keep.xml file as follows to keep layout resources if you have enabled R8 resource shrinking (with shrinkResources being set to true in the project-level build.gradle file) and strict reference checks (with shrinkMode being set to strict in the res/raw/keep.xml file). Not keeping layout resources will lead to app rejection during release to HUAWEI AppGallery.
    
    ```
    <?xml version="1.0" encoding="utf-8"?>
    <resources xmlns:tools="http://schemas.android.com/tools"
        tools:keep="@layout/hms_download_progress,@drawable/screen_off"
        tools:shrinkMode="strict" />
    ```

10. Get activity

   For getting the activity, you can use the  `Common.GetActivity()` function.

## Developing with the SDK
### Developing

There are corresponding example scenes in the [example project](https://github.com/Unity-Technologies/HMSSDKSample) for all 4 Kit. For testing, you will need to build it onto Android mobile build by HMS. Make sure you have already created your HMS account and project. Then, you can change the configuration and test different functions.

![Images/hms/Step4.png](Images/hms/Step4.png)

In the example project, the corresponding scene for Ads Kit is `Assets/HuaweiServiceDemo/Scenes/HmsAdsSampleScene.unity` and the code is `Assets/HuaweiServiceDemo/Scripts/test/ads.cs`.


### Test & Release

Please refer to Huawei [integration procedure](https://developer.huawei.com/consumer/en/doc/start/htiHMSCore) for testing and releasing.

![Images/hms/TestAndRelease.png](Images/hms/TestAndRelease.png)

![Images/hms/TestingReleasing.png](Images/hms/TestingReleasing.png)




