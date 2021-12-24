# 游戏服务(HMS)

## 简介
[游戏服务](https://developer.huawei.com/consumer/zh/doc/development/HMSCore-Guides-V5/introduction-0000001050121216-V5)是华为向您提供的能够快速开发游戏应用的服务。您可以允许用户使用华为帐号登录游戏，从而迅速推广游戏，共享华为庞大的用户价值。你还可以通过游戏服务快速实现成就、游戏事件、防沉迷等功能，快速低成本的构建游戏基本能力，并基于用户和内容的本地化进行深度的游戏运营。

### 支持的国家/地区

游戏服务支持的国家和地区与华为帐号服务一致，请参见[华为帐号支持的国家/地区](https://developer.huawei.com/consumer/cn/doc/development/HMSCore-Guides-V5/supported-regions-0000001050048968-V5)。

### 游戏联运

游戏联运是指华为应用市场与开发者联合运营游戏，提供面向全球的分发能力、便捷的开发服务、优质的运营资源、多样营销活动，促进业务用户和流水持续增长。如您需参与游戏联运，详细介绍可参见[联运服务开发指南](https://developer.huawei.com/consumer/cn/doc/development/AppGallery-connect-Guides/appgallerykit-introduction-0000001055521414)。

## Unity项目集成设置

### 1. 导入

从Unity Asset Store导入此华为HMS Core App Services SDK

### 2. 添加配置

将以下配置文件添加到 `Assets/Plugins/Android` 中

1. `agconnect-services.json `

    请参阅 [华为AppGallery文档](https://developer.huawei.com/consumer/en/doc/development/HMSCore-Guides/integrate-as-sdk-0000001050435953) 的"*将此配置文件下载并放到您的应用中* "部分，找到文件并下载。

   ![Images/gameservice/AgcConnectServicesJson.png](Images/gameservice/AgcConnectServicesJson.png)

2. `baseProjectTemplate.gradle`

   添加AppGallery Connect plugin 以及 Maven repository

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
                //如果您要更改Android Gradle插件版本，请确保它与Unity预装的Gradle版本兼容
                //您可以在此处查看Unity预装了哪个Gradle版本 https://docs.unity.cn/cn/2019.4/Manual/android-gradle-overview.html
                //请在此处查看官方的Gradle和Android Gradle插件兼容性列表 https://developer.android.com/studio/releases/gradle-plugin#updating-gradle
                //要在Unity中指定自定义Gradle版本，请到"Preferences > External Tools"，取消选中"Gradle Installed with Unity (recommended)" ，然后指定自定义Gradle版本的路径
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

   添加构建依赖

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

   添加构建依赖

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

5. 配置混淆脚本
您编译APK前需要配置混淆配置文件，避免混淆HMS Core SDK导致功能异常。
   - 在您的Unity项目里打开混淆配置文件，加入排除HMS Core SDK的混淆配置。

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
    - （可选）当您启用R8资源缩减（项目级“build.gradle”文件中“shrinkResources”属性为“true”）和严格引用检查（“res/raw/keep.xml”文件中的“shrinkMode”为“strict”）时，请您配置“keep.xml”文件手动保留layout资源，确保应用正常通过华为应用市场上架审核。
        ```
        <?xml version="1.0" encoding="utf-8"?>
        <resources xmlns:tools="http://schemas.android.com/tools"
            tools:keep="@layout/hms_download_progress,@drawable/screen_off,@layout/upsdk*,@drawable/c_buoycircle*,@drawable/hms_game*,@layout/c_buoycircle*,@layout/hms_game*,@strings/hms_game*,@strings/c_buoycircle*"
            tools:shrinkMode="strict" />
        ```
        
### 3. Huawei API 参考链接 与 集成开发流程

#### 3.1 Huawei API reference 

> https://developer.huawei.com/consumer/cn/doc/development/HMSCore-References/jos-games-0000001050121646

#### 3.2 Huawei API integration guide 

> https://developer.huawei.com/consumer/cn/doc/development/HMSCore-Guides/introduction-0000001050121216

### 4. 在您使用以下API 之前，请首先在您的华为开发者账号中对其进行正确配置

> https://developer.huawei.com/consumer/cn/doc/development/HMSCore-Guides/config-agc-0000001050166285

#### 4.1 Achievement成就 
> https://developer.huawei.com/consumer/en/doc/distribution/app/agc-add_achievement

#### 4.2 Event事件 

> https://developer.huawei.com/consumer/en/doc/distribution/app/agc-add_event

#### 4.3 Leaderboard排行榜

>https://developer.huawei.com/consumer/en/doc/distribution/app/agc-add_leaderboard

## SDK集成开发

### 示例项目

您可以在此下载[示例项目](https://github.com/Unity-Technologies/HMSSDKSample)，其中您可以找到Game Services对应的示例场景。

首先确保您已经在华为平台上创建了HMS帐户和项目，在Unity将本示例项目构建到Android移动版上，您即可对配置进行对照参考、进行更改、或对不同的功能进行调试。

#### 如何使用示例

在使用示例代码之前，请仔细阅读文档的集成部分，建议在完成以下操作后才运行示例代码：

1. 请使用您自己的 **agconnect-services.json** 文件，您可以参考本文档中的第2.1节

2. 需要在Keystore Manager变更您的签名文件 
    `Build Settings > Player Settings > Publishing Settings > Project Keystore.`

3. 您可以继续在Player Setting里修改您自己的Company Name, Product Name, Version number, 等等内容。

4. 请注意避免您的工程路径中包含中文路径，以防止不必要的报错。

5. 请参考[华为应用功能开发准备](https://developer.huawei.com/consumer/cn/doc/development/HMS-Guides/game-preparation#h2-1576044358822)配置签名证书指纹。

6. 如果需要测试成就，事件和排行榜功能，则需要参考本文档的第4部分进行配置。


### 主要更新日志

#### 2021-12-13

- New: Add `Init(IAntiAddictionListener listener, IInitListener initListener)` to initialize the APP.
**NOTICE**
In GameService 6.1.0.301 and later versions, the [appParams](https://developer.huawei.com/consumer/en/doc/development/HMSCore-References/appparams-0000001189294793`) parameter is required, please use `AccountAuthParamsHelper` to create an instance, otherwise, the default `AccountAuthParams.DEFAULT_AUTH_REQUEST_PARAM_GAME` will be used.

- New: **remove** `Init()`, please use `Init(IAntiAddictionListener listener, IInitListener initListener)`.
#### 2020-12-24

- New: Add `GetGamePlayer`,`GetGamePlayer(bool isRequirePlayerId)` to obtain the object of the current player.
- New: Add `SetGameTrialProcess` to listen to trial duration expiration.
- New: Add `AccountAuthParamsHelper` to request an ID user to authorize an app to obtain the specified information.
- New: Added `OpenId`, `UnionId`, `AccessToken` and `OpenIdSign` fields to the `Player` object.
- New: Added `OpenId` field to the `PlayerExtraInfo` object.
- New: Added `Scope` to describe the authorization request for OAuth 2.0.
- New: Added `AppPlayerInfo` to save the in-game information for the current player.
- Fix: No callback is received when the return result is null.

#### 2020-09-29
- New: Add `CheckUpdate` , `ShowUpdateDialog`, `ReleaseCallBack` to check if there is a later version.
- New: Add `CancelAuthorization` to revoke authorization on your app.
- New: Add `StartReadSms`, `RegisterSMSBroadcastReceiver`, `UnregisterSMSBroadcastReceiver` to automatically read an SMS verification code.
- New: Add `GetCachePlayerId`, `SubmitPlayerEvent`, `GetPlayerExtraInfo`,`SavePlayerInfo`.
- New: Add `GetThumbnail` to obtain the data of an archive cover.
- Fix: interfaces that are not working properly.


