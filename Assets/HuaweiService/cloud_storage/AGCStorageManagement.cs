using System;
using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.CloudStorage
{
    public class AGCStorageManagement_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.cloud.storage.core.AGCStorageManagement";
    }
    public class AGCStorageManagement :HmsClass<AGCStorageManagement_Data>
    {
        public AGCStorageManagement (): base() { }
        public static AGCStorageManagement getInstance(HttpURLConnectionFactory arg0) {
            return CallStatic<AGCStorageManagement>("getInstance", arg0);
        }
        public static AGCStorageManagement getInstance() {
            return CallStatic<AGCStorageManagement>("getInstance");
        }
        public static AGCStorageManagement getInstance(string arg0, HttpURLConnectionFactory arg1) {
            return CallStatic<AGCStorageManagement>("getInstance", arg0, arg1);
        }
        public static AGCStorageManagement getInstance(string arg0) {
            return CallStatic<AGCStorageManagement>("getInstance", arg0);
        }
        public StorageReference getStorageReference() {
            return Call<StorageReference>("getStorageReference");
        }
        public StorageReference getStorageReference(string arg0) {
            return Call<StorageReference>("getStorageReference", arg0);
        }
        [Obsolete("Method is obsolete.", false)]
        public StorageReference getReferenceFromUrl(string arg0) {
            return Call<StorageReference>("getReferenceFromUrl", arg0);
        }
        public long getMaxUploadTimeout() {
            return Call<long>("getMaxUploadTimeout");
        }
        public long getMaxDownloadTimeout() {
            return Call<long>("getMaxDownloadTimeout");
        }
        public long getMaxRequestTimeout() {
            return Call<long>("getMaxRequestTimeout");
        }
        public int getRetryTimes() {
            return Call<int>("getRetryTimes");
        }
        public void setMaxUploadTimeout(long arg0) {
            Call("setMaxUploadTimeout", arg0);
        }
        public void setMaxDownloadTimeout(long arg0) {
            Call("setMaxDownloadTimeout", arg0);
        }
        public void setMaxRequestTimeout(long arg0) {
            Call("setMaxRequestTimeout", arg0);
        }
        public void setRetryTimes(int arg0) {
            Call("setRetryTimes", arg0);
        }
    }
}