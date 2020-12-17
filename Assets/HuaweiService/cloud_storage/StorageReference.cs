using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.CloudStorage
{
    public class StorageReference_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.cloud.storage.core.StorageReference";
    }
    public class StorageReference :HmsClass<StorageReference_Data>
    {
        public StorageReference (): base() { }
        public AGCStorageManagement getStorage() {
            return Call<AGCStorageManagement>("getStorage");
        }
        public StorageReference child(string arg0) {
            return Call<StorageReference>("child", arg0);
        }
        public StorageReference getParent() {
            return Call<StorageReference>("getParent");
        }
        public StorageReference getRoot() {
            return Call<StorageReference>("getRoot");
        }
        public string getBucket() {
            return Call<string>("getBucket");
        }
        public string getName() {
            return Call<string>("getName");
        }
        public string getPath() {
            return Call<string>("getPath");
        }
        public Task getFileMetadata() {
            return Call<Task>("getFileMetadata");
        }
        public Task updateFileMetadata(FileMetadata arg0) {
            return Call<Task>("updateFileMetadata", arg0);
        }
        public Task delete() {
            return Call<Task>("delete");
        }
        public Task list(int arg0) {
            return Call<Task>("list", arg0);
        }
        public Task list(int arg0, string arg1) {
            return Call<Task>("list", arg0, arg1);
        }
        public Task listAll() {
            return Call<Task>("listAll");
        }
        public UploadTask putFile(File arg0, FileMetadata arg1, Long arg2) {
            return Call<UploadTask>("putFile", arg0, arg1, arg2);
        }
        public UploadTask putFile(File arg0) {
            return Call<UploadTask>("putFile", arg0);
        }
        public UploadTask putFile(File arg0, FileMetadata arg1) {
            return Call<UploadTask>("putFile", arg0, arg1);
        }
        public UploadTask putBytes(byte[] arg0, FileMetadata arg1, Long arg2) {
            return Call<UploadTask>("putBytes", arg0, arg1, arg2);
        }
        public UploadTask putBytes(byte[] arg0, FileMetadata arg1) {
            return Call<UploadTask>("putBytes", arg0, arg1);
        }
        public DownloadTask getFile(Uri arg0) {
            return Call<DownloadTask>("getFile", arg0);
        }
        public DownloadTask getFile(File arg0) {
            return Call<DownloadTask>("getFile", arg0);
        }
        public StreamDownloadTask getStream(StreamDownloadTask.StreamHandler arg0) {
            return Call<StreamDownloadTask>("getStream", arg0);
        }
        public StreamDownloadTask getStream() {
            return Call<StreamDownloadTask>("getStream");
        }
        public Task getBytes(long arg0) {
            return Call<Task>("getBytes", arg0);
        }
        public Task getDownloadUrl() {
            return Call<Task>("getDownloadUrl");
        }
        public List getActiveUploadTasks() {
            return Call<List>("getActiveUploadTasks");
        }
        public List getActiveDownloadTasks() {
            return Call<List>("getActiveDownloadTasks");
        }
        public int compareTo(AndroidJavaObject arg0) {
            return Call<int>("compareTo", arg0);
        }
        public int compareTo(StorageReference arg0) {
            return Call<int>("compareTo", arg0);
        }
        public string toString() {
            return Call<string>("toString");
        }
        public bool equals(AndroidJavaObject arg0) {
            return Call<bool>("equals", arg0);
        }
        public int hashCode() {
            return Call<int>("hashCode");
        }
    }
}