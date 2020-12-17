using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.CloudStorage
{
    public class HttpURLConnectionFactoryData : IHmsBaseListener
    {
        public string name => "com.huawei.agconnect.cloud.storage.core.net.connection.HttpURLConnectionFactory";
        public string buildName => "";
    }
    public class HttpURLConnectionFactory : HmsListener<HttpURLConnectionFactoryData>
    {
    
        public virtual HttpURLConnection createConnection(URL arg0) {
            return Call<HttpURLConnection>("createConnection", arg0);
        }
    
        public HttpURLConnection createConnection(AndroidJavaObject arg0){
            return createConnection(HmsUtil.GetHmsBase<URL>(arg0));
        }
    }
}