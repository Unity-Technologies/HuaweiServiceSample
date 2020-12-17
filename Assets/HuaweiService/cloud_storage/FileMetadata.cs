using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.CloudStorage
{
    public class FileMetadata_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.cloud.storage.core.FileMetadata";
    }
    public class FileMetadata :HmsClass<FileMetadata_Data>
    {
        public FileMetadata (): base() { }
        public void setSHA256Hash(string arg0) {
            Call("setSHA256Hash", arg0);
        }
        public void setContentType(string arg0) {
            Call("setContentType", arg0);
        }
        public void setCacheControl(string arg0) {
            Call("setCacheControl", arg0);
        }
        public void setContentDisposition(string arg0) {
            Call("setContentDisposition", arg0);
        }
        public void setContentEncoding(string arg0) {
            Call("setContentEncoding", arg0);
        }
        public void setContentLanguage(string arg0) {
            Call("setContentLanguage", arg0);
        }
        public void setCustomMetadata(Map arg0) {
            Call("setCustomMetadata", arg0);
        }
        public StorageReference getStorageReference() {
            return Call<StorageReference>("getStorageReference");
        }
        public string getBucket() {
            return Call<string>("getBucket");
        }
        public string getCTime() {
            return Call<string>("getCTime");
        }
        public string getMTime() {
            return Call<string>("getMTime");
        }
        public string getName() {
            return Call<string>("getName");
        }
        public string getPath() {
            return Call<string>("getPath");
        }
        public Long getSize() {
            return Call<Long>("getSize");
        }
        public string getSHA256Hash() {
            return Call<string>("getSHA256Hash");
        }
        public string getContentType() {
            return Call<string>("getContentType");
        }
        public string getCacheControl() {
            return Call<string>("getCacheControl");
        }
        public string getContentDisposition() {
            return Call<string>("getContentDisposition");
        }
        public string getContentEncoding() {
            return Call<string>("getContentEncoding");
        }
        public string getContentLanguage() {
            return Call<string>("getContentLanguage");
        }
        public Map getCustomMetadata() {
            return Call<Map>("getCustomMetadata");
        }
    }
}