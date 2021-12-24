# Game Services(HMS)

## Service Introduction

With [HUAWEI Game Service](https://developer.huawei.com/consumer/en/doc/development/HMSCore-Guides-V5/introduction-0000001050121216-V5), you will have access to a range of development capabilities. You can promote your game quickly and efficiently to Huawei's vast user base by having users sign in using their HUAWEI IDs. You can also use the service to quickly implement achievements, game events, and game addiction prevention functions, build basic game capabilities at a low cost, and perform in-depth game operations based on user and content localization.

### Supported Countries/Regions

The countries and regions supported by Game Service are the same as those of HUAWEI Account Kit. For details, please refer to [Countries/Regions Supported by HUAWEI Account Kit](https://developer.huawei.com/consumer/en/doc/development/HMSCore-Guides-V5/supported-regions-0000001050048968-V5).

### Game Joint Operations

HUAWEI AppGallery works with you to distribute your games worldwide. We can provide you with a wide range of development services and operations resources, and market your games internationally to help bring you users and revenue. To get involved, take a look at [Joint Operations Development Guide](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-Guides/appgallerykit-introduction-0000001055521414).

## Integrate Game Services into Your Unity Project

### 1. Import 

Import this Huawei HMS AGC Services from Unity Asset Store.

### 2. Add configurations

Add the following configuration files into `Assets/Plugins/Android`.

1. `agconnect-services.json`

   Refer to "*Adding the AppGallery Connect Configuration File of Your App*" in [Huawei AppGallery](https://developer.huawei.com/consumer/en/doc/development/HMSCore-Guides/integrate-as-sdk-0000001050435953 ) to find the file and download it.

   ![Images/gameservice/AgcConnectServicesJson.png](Images/gameservice/AgcConnectServicesJson.png)

2. `baseProjectTemplate.gradle`

   Add the AppGallery Connect plugin and the Maven repository

   ```
    allprojects {
        buildscript {
            repositories {**ARTIFACTORYREPOSITORY**
                google()
                mavenCentral()
                jcenter()
                maven { url 'https://developer.huawei.com/repo/' }
            }
    
            dependencies {
                // If you are changing the Android Gradle Plugin version, make sure it is compatible with the Gradle version preinstalled with Unity
                // See which Gradle version is preinstalled with Unity here https://docs.unity3d.com/Manual/android-gradle-overview.html
                // See official Gradle and Android Gradle Plugin compatibility table here https://developer.android.com/studio/releases/gradle-plugin#updating-gradle
                // To specify a custom Gradle version in Unity, go do "Preferences > External Tools", uncheck "Gradle Installed with Unity (recommended)" and specify a path to a custom Gradle version
                classpath 'com.android.tools.build:gradle:3.6.4'
                classpath 'com.huawei.agconnect:agcp:1.6.2.300'
                **BUILD_SCRIPT_DEPS**
            }
        }
    
        repositories {**ARTIFACTORYREPOSITORY**
            google()
            mavenCentral()
            jcenter()
            flatDir {
                dirs "${project(':unityLibrary').projectDir}/libs"
            }
            maven { url 'https://developer.huawei.com/repo/' }
        }
    }
   ```

3. `launcherTemplate.gradle`

   Add build dependencies

   ```
    dependencies {
        ...
        implementation 'com.huawei.agconnect:agconnect-core:1.6.2.300'
        implementation 'com.huawei.hms:base:6.2.0.300'
        implementation 'com.huawei.hms:hwid:6.1.0.303'
        implementation 'com.huawei.hms:game:6.1.0.301'
        ...
        }
   ```

4. `mainTemplate.gradle`

   Add build dependencies

   ```
    dependencies {
        ...
        implementation 'com.huawei.agconnect:agconnect-core:1.6.2.300'
        implementation 'com.huawei.hms:base:6.2.0.300'
        implementation 'com.huawei.hms:hwid:6.1.0.303'
        implementation 'com.huawei.hms:game:6.1.0.301'
        ...
    **DEPS**}
   ```

5. Configuring Obfuscation Scripts
 Before building the APK, configure the obfuscation configuration file to prevent the HMS Core SDK from being obfuscated.
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
        -keep interface com.huawei.hms.analytics.type.HAEventType{*;}
        -keep interface com.huawei.hms.analytics.type.HAParamType{*;}
        -keep class com.huawei.hms.analytics.HiAnalyticsInstance{*;}
        -keep class com.huawei.hms.analytics.HiAnalytics{*;}
        ```
    - (Optional) Configure the keep.xml file as follows to keep layout resources if you have enabled R8 resource shrinking (with shrinkResources being set to true in the project-level build.gradle file) and strict reference checks (with shrinkMode being set to strict in the res/raw/keep.xml file). Not keeping layout resources will lead to app rejection during release to HUAWEI AppGallery.

        ```
        <?xml version="1.0" encoding="utf-8"?>
        <resources xmlns:tools="http://schemas.android.com/tools"
            tools:keep="@layout/hms_download_progress,@drawable/screen_off,@layout/upsdk*,@drawable/c_buoycircle*,@drawable/hms_game*,@layout/c_buoycircle*,@layout/hms_game*,@strings/hms_game*,@strings/c_buoycircle*"
            tools:shrinkMode="strict" />
        ```
        
### 3. Huawei API reference link & integration guide

#### 3.1 Huawei API reference 

> https://developer.huawei.com/consumer/en/doc/development/HMSCore-References/jos-games-0000001050121646

#### 3.2 Huawei API integration guide

> https://developer.huawei.com/consumer/en/doc/development/HMSCore-Guides/introduction-0000001050121216

### 4. These following APIs connection should be well configurated first in Huawei before you use them

> https://developer.huawei.com/consumer/en/doc/development/HMSCore-Guides/config-agc-0000001050166285

4.1 Achievement成就

> https://developer.huawei.com/consumer/en/doc/distribution/app/agc-add_achievement

4.2 Event事件

> https://developer.huawei.com/consumer/en/doc/distribution/app/agc-add_event

4.3 Leaderboard排行榜 

>https://developer.huawei.com/consumer/en/doc/distribution/app/agc-add_leaderboard

## Developing with the SDK

### Demo

There are corresponding example scene in [example project](https://github.com/Unity-Technologies/HuaweiServiceSample) for GameServices Kit. 

For test, you need to build it onto Android mobile build by HMS. Make sure you have created HMS account and project. Then, you can change the configuration and test different functions.

#### Tips: how to use the demo

Before using the sample code, read the integration part of the document carefully. Run the sample code only after you complete the following operations:

1. Please use your own `agconnect-services.json` file, you can refer to **section 2.1** in the document.

2. Configure your Keystore in **Keystore Manager File > Build Settings > Player Settings > Publishing Settings > Project Keystore**.

3. You can use your own **Company Name**, **Product Name**, **Version number**, and the rest of settings in **Player setting**.

4. Please avoid including Chinese characters in your project path to prevent unnecessary errors.

5. Please refer to this [link](https://developer.huawei.com/consumer/en/doc/development/HMS-Guides/game-preparation#h2-1576044358822) to configure the **Signing Certificate Fingerprint**.

6. If you need to test achievements, events, and leaderboard functions, you need to refer to the fourth part of the document for configuration.

## Change Log For Reference

#### 2021-12-13

- New: Add `Init(IAntiAddictionListener listener, IInitListener initListener)` to initialize the APP.
**NOTICE**
In GameService 6.1.0.301 and later versions, the [appParams](https://developer.huawei.com/consumer/en/doc/development/HMSCore-References/appparams-0000001189294793`) parameter is required, please use `AccountAuthParamsHelper` to create an instance, otherwise, the default `AccountAuthParams.DEFAULT_AUTH_REQUEST_PARAM_GAME` will be used.

- New: **remove** `Init()`, please use `Init(IAntiAddictionListener listener, IInitListener initListener)`.
### 2020-12-24

- New: Add `GetGamePlayer`,`GetGamePlayer(bool isRequirePlayerId)` to obtain the object of the current player.

- New: Add `SetGameTrialProcess` to listen to trial duration expiration.

- New: Add `AccountAuthParamsHelper` to request an ID user to authorize an app to obtain the specified information.

- New: Added `OpenId`, `UnionId`, `AccessToken` and `OpenIdSign` fields to the `Player` object.

- New: Added `OpenId` field to the `PlayerExtraInfo` object.

- New: Added `Scope` to describe the authorization request for OAuth 2.0.

- New: Added `AppPlayerInfo` to save the in-game information for the current player.

- Fix: No callback is received when the return result is null.

### 2020-09-29

- New: Add `CheckUpdate` , `ShowUpdateDialog`, `ReleaseCallBack` to check if there is a later version.

- New: Add `CancelAuthorization` to revoke authorization on your app.

- New: Add `StartReadSms`, `RegisterSMSBroadcastReceiver`, `UnregisterSMSBroadcastReceiver` to automatically read an SMS verification code.

- New: Add `GetCachePlayerId`, `SubmitPlayerEvent`, `GetPlayerExtraInfo`,`SavePlayerInfo`.

- New: Add `GetThumbnail` to obtain the data of an archive cover.

- Fix: interfaces that are not working properly.


