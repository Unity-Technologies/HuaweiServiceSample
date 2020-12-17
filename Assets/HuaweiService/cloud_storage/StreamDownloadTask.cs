using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.CloudStorage
{
    public class StreamDownloadTask_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.cloud.storage.core.StreamDownloadTask";
    }
    public class StreamDownloadTask :HmsClass<StreamDownloadTask_Data>
    {
        public StreamDownloadTask (): base() { }
    
        public class StreamHandlerData : IHmsBaseListener
        {
            public string name => "com.huawei.agconnect.cloud.storage.core.StreamDownloadTask$StreamHandler";
            public string buildName => "";
        }
        public class StreamHandler : HmsListener<StreamHandlerData>
        {
        
            public virtual void readStream(StreamDownloadResult arg0, InputStream arg1) {
                Call("readStream", arg0, arg1);
            }
        
            public void readStream(AndroidJavaObject arg0, AndroidJavaObject arg1){
                readStream(HmsUtil.GetHmsBase<StreamDownloadResult>(arg0), HmsUtil.GetHmsBase<InputStream>(arg1));
            }
        }
    
        public class StreamDownloadResult_Data : IHmsBaseClass{
            public string name => "com.huawei.agconnect.cloud.storage.core.StreamDownloadTask$StreamDownloadResult";
        }
        public class StreamDownloadResult :HmsClass<StreamDownloadResult_Data>
        {
            public StreamDownloadResult (): base() { }
            public long getBytesTransferred() {
                return Call<long>("getBytesTransferred");
            }
            public long getTotalByteCount() {
                return Call<long>("getTotalByteCount");
            }
            public InputStream getStream() {
                return Call<InputStream>("getStream");
            }
        }
    }
}