# HuaweiService.cloudfunctions

#### Scenario: Get cloud parameters``获取云端参数``
| Description | Api | Reference |
---|---|---
Sets the cloud function to be called using the NOPATHHTTP trigger identifier of the function.<br>``通过函数的NOPATHHTTP触发器的URL设置调用哪个云函数``|AGConnectFunction.wrap(String httpTriggerURI)|[agconnectfunction](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/agconnectfunction)

#### Scenario: Call functions``调用函数``
| Description | Api | Reference |
---|---|---
Calls a function without input parameters. <br>``调用没有入参的函数``|FunctionCallable.call()                     |[functioncallable](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/functioncallable)
Calls a function with input parameters.<br>``调用有入参的函数``|FunctionCallable.call(T object)             |[functioncallable](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/functioncallable)
Obtains the return value after a function is executed. The return value is of the string type.<br>``获取函数执行后的返回值``|FunctionResult.getValue()|[functionresult](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/functionresult)    
Obtains the object returned after a function is executed.<br>``获取函数执行后返回的对象``|FunctionResult.getValue(Class<T> valueClass)|[functionresult](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/functionresult)    

#### Scenario: Function timeout``函数超时时间``
| Description | Api | Reference |
---|---|---
Obtains the timeout interval of a function.<br>``获取函数的超时时间``|getTimeout()|[functioncallable](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/functioncallable)
Sets the timeout interval of a function.<br>``设置函数的超时时间``|setTimeout(long timeout, TimeUnit units)|[functioncallable](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/functioncallable)
Creates a FunctionCallable instance and with a specified timeout interval.创建FunctionCallable实例，使用指定的超时时间|clone(long timeout, TimeUnit units)|[functioncallable](https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/functioncallable)

