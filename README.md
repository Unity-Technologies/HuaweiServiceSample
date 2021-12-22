# HuaweiService Demo

This demo project enables parts of Huawei HMS and AGC services in Unity for Android Build, which is implemented by wrapping HMS and AGC SDK. Name and usage of corresponding classes and functions are the same with Huawei.

The following Kits included.
- HMS
    - Game Service
    - Ads
    - Push
    - Location
    - Analytics
- AGC
    - App Linking
    - App Messaging
    - Remote Configuration
    - APM
    - Crash
    - Auth Service
    - Cloud Functions
    - Cloud Storage
    - Cloud DB

***Unity 2020 or higher***

***Before build, add your keystore, create huawei agc project and put `agconnect-services.json` under `Assets/Plugins/Android/`***

key store path `Edit -> Project Settings -> Player -> Android(icon) -> Publishing Settings`

In location test, before you click `CreateGeo` button, you should click `update with callback-102` to get your position.

***Please check the documentation folder or visite the [documentation webpages](https://docs.unity.cn/cn/Packages-cn/com.unity.huaweiservice@2.1/manual/)***

Updates:
Huawei updates the SDK version, which needs a higher gradle version. Gradle of Unity 2019 does not support it. We upgrade the version to Unity2020. The old version is in branch `unity2019`. Please open this project using Unity 2020 or higher. If you have to use unity 2019, please download a new gradle and update the unity 2019 configuration.