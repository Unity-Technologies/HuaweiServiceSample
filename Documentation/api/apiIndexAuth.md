# HuaweiService.authservice

#### Scenario: Authentication service account related``认证服务账号相关``
| <div style="width: 150pt">Description | <div style="width: 150pt">Api | Reference |
---|---|---
Signs in a user to AppGallery Connect through third-party authentication.<br>``登录``|AGConnectAuth.signIn(AGConnectAuthCredential credential)|[https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectauth-0000001054482530](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectauth-0000001054482530)
Signs in a user anonymously.<br>``匿名登录``|AGConnectAuth.signInAnonymously()|[https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectauth-0000001054482530](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectauth-0000001054482530)
Creates an account using an email address.<br>``邮箱认证注册``|AGConnectAuth.createUser(EmailUser emailUser)|[https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectauth-0000001054482530](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectauth-0000001054482530)
Creates a user using a mobile number.<br>``手机号码认证注册``|AGConnectAuth.createUser(PhoneUser phoneUser)|[https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectauth-0000001054482530](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectauth-0000001054482530)
Resets a user's password using the email address.<br>``邮箱重置密码``|AGConnectAuth.resetPassword(String email, String newPassword, String verifyCode)|[https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectauth-0000001054482530](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectauth-0000001054482530)
Resets a user's password using the mobile number.<br>``手机号码重置密码``|AGConnectAuth.resetPassword(String countryCode, String phoneNumber, String newPassword, String verifyCode);|[https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectauth-0000001054482530](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectauth-0000001054482530)
Signs out a user and deletes the user's cached data.<br>``登出``|AGConnectAuth.signOut()|[https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectauth-0000001054482530](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectauth-0000001054482530)
Deletes the current user information and cache information from the AppGallery Connect server.<br>``删除用户``|AGConnectAuth.deleteUser()|[https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectauth-0000001054482530](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectauth-0000001054482530)

#### Scenario: Link account``关联账号``
| <div style="width: 50pt">Description | <div style="width: 50pt">Api | Reference |
---|---|---
Links a new authentication mode for the current user.<br>``关联``|AGConnectUser.link(AGConnectAuthCredential credential)|https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectuser-0000001054522513
Unlinks the current user from the linked authentication mode.<br>``取消关联``|AGConnectUser.unlink(int provider)|https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectuser-0000001054522513

#### Scenario: Obtain authentication service user information``获取认证服务用户信息``
| <div style="width: 100pt">Description | <div style="width: 100pt">Api | <div style="width: 100pt">Reference |
---|---|---
Obtains information about the current signed-in user. If the user has not signed in, a null value is returned.<br>``获取User信息集合``|AGConnectAuth.getCurrentUser()|https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectauth-0000001054482530
User information<br>``User信息``|AGCConnectUser，Please refer to：https://developer.huawei.com/consumer/cn/doc/development/AppGallery-connect-References/agconnectuser-0000001054522513|https://developer.huawei.com/consumer/cn/doc/development/AppGallery-connect-References/agconnectuser-0000001054522513 <br>`getProviderInfo()`,refer How to use getProviderInfo() below!

How to use ``getProviderInfo()``
For example:
```
List temp=agConnectUser.getProviderInfo();
AndroidJavaObject[] mapList=temp.toArray();
for (int i = 0; i < mapList.Length; i++)
{
   Map temp=HmsUtil.GetHmsBase<Map>(mapList[i]);
   string[] keyArray=temp.keySet().toArray();
   for (int j = 0; j < keyArray.Length; j++)
   {
      //Value can use getOrDefault() function in Map
      //for example temp.getOrDefault(keyArray[i], "")
   }
  
}

```
#### Scenario: Credential generation of major login methods``各大登录方式的credential生成``
| Description | Api | Reference |
---|---|---
Obtains a credential using an email address and a password/verification code.<br>``邮箱认证credential``|EmailAuthProvider.credentialWithPassword(String email, String password)/EmailAuthProvider.credentialWithVerifyCode(String email, String password, String verifyCode)|[https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/emailauthprovider-0000001054322501](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/emailauthprovider-0000001054322501)
Obtains a credential using a mobile number and password/verification code.<br>``手机认证credential``|PhoneAuthProvider.credentialWithPassword(String countryCode,String phoneNumber, String password)/PhoneAuthProvider.credentialWithVerifyCode(String countryCode,String phoneNumber, String password, String verifyCode)|[https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/phoneauthprovider-0000001054083788](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/phoneauthprovider-0000001054083788)                             
Obtains a credential using a mobile number and password/verification code.<br>``第三方账号credential``|FacebookAuthProvider<br>GoogleAuthProvider<br>GoogleGameAuthProvider<br>HWGameAuthProvider.Builder<br>HwIdAuthProvider<br>QQAuthProvider<br>SelfBuildProvider<br>TwitterAuthProvider<br>WeixinAuthProvider<br>WeiboAuthProvider|[https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/facebookauthprovider-0000001054202529](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/facebookauthprovider-0000001054202529)<br>（Take Facebook for example, the rest of platforms please refer to the page）

#### Scenario: Email mobile phone authentication verification code``邮箱手机认证验证码``
| Description | Api | Reference |
---|---|---
Applies for a verification code using an email address.<br>``邮箱申请验证码``|EmailAuthProvider.requestVerifyCode(String email, VerifyCodeSettings settings)|https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/emailauthprovider-0000001054322501
Applies for a verification code using a mobile number.<br>``手机号码申请验证码``|PhoneAuthProvider.requestVerifyCode(String countryCode, String phoneNumber, VerifyCodeSettings settings)|https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/phoneauthprovider-0000001054083788




