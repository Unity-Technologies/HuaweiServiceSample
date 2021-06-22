# HuaweiService.applinking

#### Scenario: initialization``初始化``
| Description | Api | Reference |
---|---|---
Initializes the AGConnectAppLinking instance.<br>``初始化AGConnectAppLinking实例`` | AGConnectAppLinking getInstance() | [AGConnectAppLinking](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectapplinking) 

#### Scenario: Create a Build object and set AppLinking parameters``创建Build对象，设置AppLinking参数``
| Description | Api | Reference |
---|---|---
Generates a long link.<br>``生成长链接`` | builder.buildAppLinking() | [AppLinking.Builder](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/applinking-builder)
Asynchronously generates a short link.<br>``异步生成短链接`` | builder.buildShortAppLinking() | [AppLinking.Builder](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/applinking-builder) 
Asynchronously generates a short link with a string-type suffix. <br>``异步生成指定长短的短链接`` | builder.buildShortAppLinking(ShortAppLinking.LENGTH length) |[AppLinking.Builder](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/applinking-builder)
Sets information about the Android app where a link of App Linking is to be opened.<br>``设置打开App Linking的安卓应用信息`` |Builder setAndroidLinkInfo(AppLinking.AndroidLinkInfo androidLinkInfo) | [AppLinking.Builder](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/applinking-builder)
Sets the deep link to be contained in a link of App Linking.<br>``设置要App Linking中打开的DeepLink地址`` | Builder setDeepLink(Uri deepLink) | [AppLinking.Builder](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/applinking-builder)
Sets a long link.<br>``设置长链接地址`` | Builder setLongLink(Uri longLink) |  [AppLinking.Builder](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/applinking-builder) 
Sets social sharing identifier information.<br>``设置社交分享标识信息`` | Builder setSocialCardInfo(AppLinking.SocialCardInfo socialCardInfo)  |  [AppLinking.Builder](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/applinking-builder) 
Sets activity information.<br>``设置活动所需要的数据`` | Builder setCampaignInfo(AppLinking.CampaignInfo campaignInfo)  |  [AppLinking.Builder](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/applinking-builder) 
Sets a URL prefix for a link of App Linking.<br>``设置App Linking链接地址的网址前缀`` | Builder setUriPrefix(String uriPrefix)  | [AppLinking.Builder](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/applinking-builder) 
Sets the link expiration time.<br>``设置链接失效时间`` | Builder setExpireMinute(long expireMinute)  | [AppLinking.Builder](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/applinking-builder) 
Sets the preview page style.<br>``设置预览页样式：``<br>``APP信息展示``<br>``社交卡片展示`` | Builder setPreviewType(LinkingPreviewType previewType)<br>public static final AppLinking.LinkingPreviewType AppInfo<br>public static final AppLinking.LinkingPreviewType SocialInfo |  [AppLinking.Builder](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/applinking-builder) 

#### Scenario: Configure Android application information``配置Android应用信息``
| Description | Api | Reference |
---|---|---
Sets the deep link to an Android app.<br>``设置Android应用的DeepLink`` | setAndroidDeepLink(String androidDeepLink)  |  [AppLinking.AndroidLinkInfo.Builder](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/applinking-androidlinkinfo-builder)   
Sets the action triggered when the link of an Android app is tapped but the app is not installed.<br>``设置Android应用未安装时的打开方式：``<br>``华为应用市场打开详情页``<br>``用本地应用市场打开详情页``<br>``使用fallbackUrl字段打开`` | setOpenType(AndroidOpenType openType)<br>public static final AppLinking.AndroidLinkInfo.AndroidOpenType AppGallery<br>public static final AppLinking.AndroidLinkInfo.AndroidOpenType LocalMarket<br>public static final AppLinking.AndroidLinkInfo.AndroidOpenType CustomUrl | [AppLinking.AndroidLinkInfo.Builder](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/applinking-androidlinkinfo-builder) 
Sets a custom URL to be accessed when the app is not installed.<br>``设置自定义跟踪记录属性名称和属性值`` | setFallbackUrl(String fallbackUrl)  | [AppLinking.AndroidLinkInfo.Builder](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/applinking-androidlinkinfo-builder)
Generates Android app information.<br>``生成安卓应用信息`` | AndroidLinkInfo build()  | [AppLinking.AndroidLinkInfo.Builder](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/applinking-androidlinkinfo-builder) 

#### Scenario: Configure social sharing identification information``配置社交分享标识信息``
| Description | Api | Reference |
---|---|---
Sets the preview description displayed during social sharing.<br>``设置社交分享标识信息中的预览说明信息`` | setDescription(String description) |  [AppLinking.SocialCardInfo.Builder](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/applinking-socialcardinfo-builder) 
Sets the address of the preview image displayed during social sharing.<br>``设置社交分享标识信息中的预览图片地址`` | setImageUrl(String imageUrl)  | [AppLinking.SocialCardInfo.Builder](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/applinking-socialcardinfo-builder) 
Sets the preview title for social sharing.<br>``设置社交分享标识信息中的预览标题``| setTitle(String title)  | [AppLinking.SocialCardInfo.Builder](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/applinking-socialcardinfo-builder) 
Generates social sharing identifier information.<br>``生成App Linking中的社交分享标识信息`` | SocialCardInfo build()   | [AppLinking.SocialCardInfo.Builder](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/applinking-socialcardinfo-builder) 
Generate social sharing identification information<br>``生成社交分享标识信息`` |        | |

#### Scenario: Configure activity information in AppLinking``配置AppLinking中的活动信息``
| Description | Api | Reference |
---|---|---
|Sets the activity name.<br>``设置活动名称`` | setName(String name)     | [AppLinking.CampaignInfo.Builder](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/applinking-campaigninfo-builder) |
| Sets the activity source.<br>``设置活动来源`` | setSource(String source) | [AppLinking.CampaignInfo.Builder](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/applinking-campaigninfo-builder) |
| Sets the activity medium.<br>``设置活动媒介`` | setMedium(String medium)  | [AppLinking.CampaignInfo.Builder](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/applinking-campaigninfo-builder) |
| Generates activity information.<br>``生成活动信息`` | CampaignInfo build()     | [AppLinking.CampaignInfo.Builder](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/applinking-campaigninfo-builder) |

#### Scenario: Get the short link``获取短链接``
| Description | Api | Reference |
---|---|---
| Obtains a short link.<br>``获取短链接地址`` | Uri getShortUrl()      |  [ShortAppLinking](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/shortapplinking) |
| Obtains the URL for previewing the flowchart of a link of App Linking.<br>``获取预览链接流程的地址``  | Uri getTestUrl()       |  [ShortAppLinking](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/shortapplinking) |
| Specifies whether the string-type suffix of a short link is long or short. This class is used to create a short link.<br>``短链接字符串后缀的长度的常量`` | ShortAppLinking.LENGTH |  [ShortAppLinking](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/shortapplinking) |

#### Scenario: Receive AppLinking``接收AppLinking``
| Description | Api | Reference |
---|---|---
| Checks whether there are links of App Linking with data to be received in a specified intent.<br>``查看指定的链接地址是否有待接收的数据`` | Task<ResolvedLinkData> getAppLinking(Activity activity) <br>Task不带泛型，但对使用并无影响 | [AGConnectAppLinking](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectapplinking#getAppLinking3) |
| Obtains the time when a link of App Linking is tapped.<br>``App Linking被点击的时间``  | getClickTimestamp()                                      | [ResolvedLinkData](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/resolvedlinkdata)                                     |
| Obtains the deep link contained in a link of App Linking.<br>``App Linking链接地址中的DeepLink地址`` | getDeepLink()                                | [ResolvedLinkData](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/resolvedlinkdata)                                     |
| Obtains the preview title displayed during social sharing.<br>``获取链接社交标题``  | getSocialTitle()      | [ResolvedLinkData](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/resolvedlinkdata)                                     |
| Obtains the preview description displayed during social sharing.<br>``获取链接社交描述``  | getSocialDescription()    | [ResolvedLinkData](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/resolvedlinkdata)                                     |
| Obtains the preview image displayed during social sharing.<br>``获取链接社交图片`` | getSocialImageUrl()       | [ResolvedLinkData](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/resolvedlinkdata)                                     |
| Obtains the campaign name displayed during social sharing.<br>``获取链接活动名称`` | getCampaignName()      | [ResolvedLinkData](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/resolvedlinkdata)                                     |
| Obtains the campaign medium.<br>``获取链接活动媒介``  | getCampaignMedium()                    | [ResolvedLinkData](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/resolvedlinkdata)                                     |
| Obtains the campaign source.<br>``获取链接活动来源`` | getCampaignSource()                  | [ResolvedLinkData](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/resolvedlinkdata)                                     |


