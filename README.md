# Hms Demo
***Unity 2019 or higher***
***Before build, enter keystore password `123456`, and project key password `123456`***

key store path `Edit -> Project Settings -> Player -> Android(icon) -> Publishing Settings`

If you add analytic test, you should set activity of `AndroidManifest.xml`
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
Otherwise, just set activity `com.unity3d.player.UnityPlayerActivity`

Before you click `CreateGeo` button, you should click `update with callback-102` to get your position.