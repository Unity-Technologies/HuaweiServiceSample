# 性能管理（AGC）


## 业务介绍

华为AppGallery Connect（简称AGC）的[性能管理](https://developer.huawei.com/consumer/cn/doc/development/AppGallery-connect-Guides/agc-apms-introduction)（APM，App Performance Management）服务提供分钟级应用性能监控能力，您可以在AGC查看和分析APM收集到的应用性能数据，实时全面掌握应用在线的性能表现，帮助您快速修复应用的性能问题，持续提升应用的用户体验。

### 主要功能

| <div style="width:140px">主要功能</div> | 功能描述 |
| :-------------------------- | :-------------------------------- |
| 自动收集有关应用程序启动，应用程序屏幕渲染和HTTP/HTTPS网络请求的性能数据。| APM SDK自动收集有关应用程序启动，应用程序屏幕渲染和HTTP / HTTPS网络请求的关键性能数据。<br>1.应用启动：冷启动和暖启动模式下的应用启动时间。<br>2. 应用程序屏幕渲染：应用程序屏幕渲染期间慢帧和冻结帧的数量。<br>3. HTTP / HTTPS网络请求：诸如响应持续时间，成功率和响应大小之类的指标。|
| 支持查看和分析应用性能数据，快速发现应用性能瓶颈。 |APM通过多个维度（版本号、国家/地区、设备型号、一级区域、系统版本、运营商和网络等）向您展示应用的性能表现，帮助您快速了解应用在哪些方面可优化改进。|
| 支持创建自定义跟踪记录，监控应用在特定场景下的性能。 |借助APM SDK，您可以：<br/>1.创建自定义跟踪记录来监控应用在自定义场景（如用户登录和场景加载）下的性能。<br/>为自定义跟踪记录添加指标（如登录次数）和属性（如登录是否成功）。|


## Unity项目设置


### 1. 集成AGC SDK

集成APM SDK前，请确认您的应用已集成AGC SDK和AGC插件，详细步骤请参考[AppGallery Connect服务使用入门](https://developer.huawei.com/consumer/cn/doc/development/AppGallery-connect-Guides/agc-get-started)。

**注意**：

1. 拷贝`agconnect-services.json`文件到`Assets/Plugins/Android/ `目录中

2. 在`Assets/Plugins/Android/` 目录中打开`launcherTemplate.gradle `。

   在 `apply plugin: 'com.android.application'` 下面添加以下信息：

   ```
   apply plugin: 'com.android.application’
   apply plugin: 'com.huawei.agconnect'
   ```

   构建依赖关系：
   ```
   dependencies {      
        implementation 'com.huawei.agconnect:agconnect-core:1.4.2.302'    
       }
   ```


3. 在`Assets/Plugins/Android/` 目录中打开`baseProjectTemplate.gradle`文件

	添加以下配置：
   ```
   allprojects {  
              repositories {  
                  google()  
                  jcenter()  
                  maven {url 'https://developer.huawei.com/repo/'}  
              }  
          }

   buildscript {  
              repositories {  
                  google()  
                  jcenter()  
                  maven {url 'https://developer.huawei.com/repo/'}  
              }  
   }

   buildscript {  
              dependencies {  
               classpath 'com.huawei.agconnect:agcp:1.4.2.301'
              }  
   }
   ```


### 2. 集成APM SDK

步骤请参考 [集成APM SDK](https://developer.huawei.com/consumer/cn/doc/development/AppGallery-connect-Guides/agc-apms-apmssdk)

集成APM SDK后，APM SDK将自动采集应用的[启动性能数据](https://developer.huawei.com/consumer/cn/doc/development/AppGallery-connect-Guides/agc-apms-appstart)、[屏幕性能数据](https://developer.huawei.com/consumer/cn/doc/development/AppGallery-connect-Guides/agc-apms-appscreen)。

将APM SDK依赖项添加到`launcherTemplate.gradle`文件中（通常在app目录中）。

```
dependencies {
// ...
// Add APM SDK library dependency
implementation 'com.huawei.agconnect:agconnect-apms:1.5.2.300'
implementation 'com.huawei.agconnect:agconnect-apms-game:1.5.2.303'
}

```


### 3. 集成APM插件

步骤请参考 [集成APM插件](https://developer.huawei.com/consumer/cn/doc/development/AppGallery-connect-Guides/agc-apms-apmsplugin)

APM插件利用检测（instrumentation）技术，实现[HTTP/HTTPS网络请求性能数据](https://developer.huawei.com/consumer/cn/doc/development/AppGallery-connect-Guides/agc-apms-appnetwork)的无侵入采集。请按如下步骤将APM插件添加到您的应用：

1. 将APM插件添加到`launcherTemplate.gradle`文件中。

   ```
   apply plugin: 'com.android.application'
   // Apply the APM plugin
   apply plugin: 'com.huawei.agconnect.apms'
   // Apply the AGC plugin
   apply plugin: 'com.huawei.agconnect'

   dependencies {
    // ..
   }

   ```

2. 将APM插件添加到`baseProjectTemplate.gradle`文件中。

   ```
   buildscript {
      repositories {
        // Add the maven repository
        maven { url 'https://developer.huawei.com/repo/' }
      }
      dependencies {
        // ...
        // To benefit from the latest APM feaures, update your Android Gradle Plugin dependency to at least v3.3.2
        classpath 'com.android.tools.build:gradle:3.3.2'
        // Add the dependency for the APM plugin
        classpath 'com.huawei.agconnect:agconnect-apms-plugin:1.4.1.303'
      }
   }
   ```

### 4.集成APM Game SDK（可选）
将APM Game SDK依赖项添加到`launcherTemplate.gradle`文件中（通常在app目录中）。

```
dependencies {
// ...
// Add APM SDK library dependency
implementation 'com.huawei.agconnect:agconnect-apms:1.5.2.300'
implementation 'com.huawei.agconnect:agconnect-apms-game:1.5.2.303'
}
```

## SDK集成开发

### 查看性能监控数据

请参考[查看性能监控数据](https://developer.huawei.com/consumer/cn/doc/development/AppGallery-connect-Guides/agc-apms-viewdata)


### 可选：使用APM

1、[添加自定义跟踪记录](https://developer.huawei.com/consumer/cn/doc/development/AppGallery-connect-Guides/agc-apms-addtrace)

2、[使用@AddCustomTrace跟踪方法耗时](https://developer.huawei.com/consumer/cn/doc/development/AppGallery-connect-Guides/agc-apms-addcustomtrace)

（注意：目前此功能只能应用于主程序集，若用户代码在自定义程序集中则无法解析）

3、[添加针对特定网络请求的监控指标](https://developer.huawei.com/consumer/cn/doc/development/AppGallery-connect-Guides/agc-apms-addnetworkmeasure)

4、[查看调试日志](https://developer.huawei.com/consumer/cn/doc/development/AppGallery-connect-Guides/agc-apms-viewlog)

5、[配置AndroidManifest文件](https://developer.huawei.com/consumer/cn/doc/development/AppGallery-connect-Guides/agc-apms-configuremanifest)

### 可选：使用APM Game SDK
在游戏开始时的初始化方法中，调用APMS的startGamePlugin()方法来启用该SDK。
```
void Start()
{
    // In order to start APMS Game Plugin, you need to call this method
    GameAPM.getInstance().start();

    // Your own business code
    // ...
}
```
```
void OnDestroy() {
    // In order to start APMS Game Plugin, you need to call this method
    GameAPM.getInstance().stop();
    // Your own business code
    // ...
}
```

为了能够快速发现场景加载时间是否超过正常范围，可以调用APMS的 startLoadingScene(GameAttribue gameAttribute) 和 stopLoadingScene(String scene) 来记录场景加载时间。
```
public void scenceLoadToGame()
{
	// start record the loading scene time
	String scene = GameAPM.getInstance().startLoadingScene(new GameAttribute("Game", LoadingState.NOT_LOADING));
	SceneManager.LoadScene("Game");

	// Other code
	// ...

	// stop record the loading scene time
	GameAPM.getInstance().stopLoadingScene(scene);
}
```

前提条件
1. 您的应用已启用APM服务。
2. 您的应用已集成APM Game SDK，并在设备上运行。

查看游戏场景分析
1. 登录AppGallery Connect网站，点击“我的项目”。
2. 在项目列表中找到您的项目，在项目下的应用列表中选择需要查看的应用。
3. 选择“质量 > 性能管理”，进入“应用性能管理”页面。
4. 点击“体验分析->游戏场景分析"，进入游戏场景分析页面。

更多详细信息，请参阅本文档的附录。


### 设置场景

1. 新建一个场景

   ![Images/apm/apm_settingup1.png](Images/apm/apm_settingup1.png)

2. 右键单击并选择UI，然后选择button:

   ![Images/apm/apm_settingup2.png](Images/apm/apm_settingup2.png)

3. 将Component添加到button并开发脚本：

   ![Images/apm/apm_settingup3.png](Images/apm/apm_settingup3.png)

   ![Images/apm/apm_settingup4.png](Images/apm/apm_settingup4.png)

4. 编辑脚本:

   ![Images/apm/apm_settingup5.png](Images/apm/apm_settingup5.png)

    双击脚本文件，然后您将在VS code中打开它

   ![Images/apm/apm_settingup6.png](Images/apm/apm_settingup6.png)

5. 定义接口
   ```
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {

   }
    public void CustomTraceMeasureTest(CustomTrace customTrace) {
              UnityEngine.Debug.Log("CustomTraceMeasureTest start");

              customTrace.putMeasure("ProcessingTimes", 0);
              for (int i = 0; i < 100; i++) {
                  customTrace.incrementMeasure("ProcessingTimes", 1);
              }

              long value = customTrace.getMeasure("ProcessingTimes");
              Debug.Log("Measurename: ProcessingTimes, value: "+ value);

              UnityEngine.Debug.Log("CustomTraceMeasureTest success");
          }
   ```

   创建函数

6. 绑定脚本中的按钮和界面

   ![Images/apm/apm_settingup7.png](Images/apm/apm_settingup7.png)

   - 步骤1：点击“+”添加功能

   - 步骤2：选择具有您要使用的界面的对应场景

   - 步骤3：单击“No Function”以选择脚本，然后选择相应的函数

     ![Images/apm/apm_settingup8.png](Images/apm/apm_settingup8.png)

### 演示项目

如何使用演示项目？

- 步骤1：从以下位置创建repo：https://github.com/Unity-Technologies/unity-hms_sdk/tree/apm 并checkout到“apm”分支。

- 步骤2：从远程项目中替换`agconnect-services.json`文件并配置gradle文件，请参阅第2部分，步骤1至步骤3。

- 步骤3：打开Unity Hub，添加HuaweiServiceDemo项目（Unity版本2019.3）。

- 步骤4：将平台切换到Android并打开性能测试场景：`Assets / HuaweiHmsDemo / HmsPerformanceSampleTest`

  如果有以下的编译错误：

  > Microsoft (R) Visual C# Compiler version 2.9.1.65535 (9d34608e)
  >
  > Copyright (C) Microsoft Corporation. All rights reserved.
  >
  > error CS0009: Metadata file '/Users/yanmeng/Desktop/unity_agc_new/unity-hms_sdk/hmsDemo/Library/ScriptAssemblies/Unity.Timeline.Editor.dll' could not be opened -- Image is too small.
  >
  > Assets/HuaweiHms/src/hms/Wrapper/fundation/HmsClass.cs(72,25): warning CS0693: Type parameter 'T' has the same name as the type parameter from outer type 'HmsClass&lt;T>'

  尝试重新打开项目，总是能解决此问题。

- 步骤5：在 **Build Settings -> Android -> PlayerSettings-> Publish Settings** 中设置Android build keystore。如下所示。 hhmm的密码为123456。

  ![Images/apm/apm_10.png](Images/apm/apm_10.png)

- 步骤6：构建android apk并在Android设备上运行。使用logcat检查测试用例是否成功执行。

  ![Images/apm/apm_11.png](Images/apm/apm_11.png)


### 附录
#### APM Game Plugin 数据安全说明

工作方式

- APM Game Plugin随应用打包，在用户启动应用时开始工作，并自动采集应用性能数据。当用户关闭应用时，Plugin会停止采集应用性能数据。

权限说明

- 无

收集数据

1. 基础数据属性

  - 应用基础属性：应用名称、应用版本名称、应用版本号、应用包名（应用ID）。

  - 设备基础属性：设备厂商、设备架构、设备型号、屏幕大小、分辨率、屏幕类型（超大、大、中、小、未知）、屏幕刷新频率、CPU型号、CPU核数、内存大小、磁盘大小、用户CPU时长、系统CPU时长、最大堆内存、已用堆内存。

  - 平台基础属性：操作系统名称、操作系统版本、ROM名称、ROM版本、APM SDK版本、AAID、AGC cpID、AGC productID、AGC ClientID、AGC AppID。

  - 运行时基础属性：充电状态、电量大小、网络类型、屏幕方向、应用前后台状态、APM SDK会话ID、可用磁盘空间、应用内存使用量。

  - 用户设置属性：默认时区设置、默认语言设置、DNS设置。

  - 自定义跟踪记录属性：开发者设置的自定义属性。

2. 指标数据

  - 帧率数据：场景名称、加载状态、帧速率数量。

  - 加载数据：场景名称、加载状态、加载时长。

3. 数据安全保护

  - APM Game Plugin对采集数据进行本地加密，加密后的数据通过HTTPS安全协议传输至APM服务器。

  - 华为严格遵循《一般数据保护条例》(GDPR) ，华为也致力于帮助开发者在遵循GDPR规定的前提下取得成功。GDPR规定了数据控制者和数据处理者的义务，使用该服务时，开发者扮演着“数据控制者”的角色，而华为是“数据处理者”。数据处于开发者的控制之下，华为只在“数据处理者”义务和权利范围内处理数据，而开发者有责任遵循GDPR规定，承担“数据控制者“的义务。
