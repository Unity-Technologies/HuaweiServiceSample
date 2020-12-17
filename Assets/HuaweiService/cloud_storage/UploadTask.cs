using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.CloudStorage
{
    public class UploadTask_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.cloud.storage.core.UploadTask";
    }
    public class UploadTask :HmsClass<UploadTask_Data>
    {
        public UploadTask (): base() { }
        public bool resume() {
            return Call<bool>("resume");
        }
        public void onPaused() {
            Call("onPaused");
        }
        public StorageTask addOnCanceledListener(Activity arg0, OnCanceledListener arg1) {
            return Call<StorageTask>("addOnCanceledListener", arg0, arg1);
        }
        public StorageTask addOnCanceledListener(Executor arg0, OnCanceledListener arg1) {
            return Call<StorageTask>("addOnCanceledListener", arg0, arg1);
        }
        public StorageTask addOnCanceledListener(OnCanceledListener arg0) {
            return Call<StorageTask>("addOnCanceledListener", arg0);
        }
        public StorageTask addOnCompleteListener(OnCompleteListener arg0) {
            return Call<StorageTask>("addOnCompleteListener", arg0);
        }
        public StorageTask addOnCompleteListener(Activity arg0, OnCompleteListener arg1) {
            return Call<StorageTask>("addOnCompleteListener", arg0, arg1);
        }
        public StorageTask addOnCompleteListener(Executor arg0, OnCompleteListener arg1) {
            return Call<StorageTask>("addOnCompleteListener", arg0, arg1);
        }
        public StorageTask addOnFailureListener(Executor arg0, OnFailureListener arg1) {
            return Call<StorageTask>("addOnFailureListener", arg0, arg1);
        }
        public StorageTask addOnFailureListener(Activity arg0, OnFailureListener arg1) {
            return Call<StorageTask>("addOnFailureListener", arg0, arg1);
        }
        public StorageTask addOnFailureListener(OnFailureListener arg0) {
            return Call<StorageTask>("addOnFailureListener", arg0);
        }
        public StorageTask addOnSuccessListener(Activity arg0, OnSuccessListener arg1) {
            return Call<StorageTask>("addOnSuccessListener", arg0, arg1);
        }
        public StorageTask addOnSuccessListener(OnSuccessListener arg0) {
            return Call<StorageTask>("addOnSuccessListener", arg0);
        }
        public StorageTask addOnSuccessListener(Executor arg0, OnSuccessListener arg1) {
            return Call<StorageTask>("addOnSuccessListener", arg0, arg1);
        }
        public StorageTask addOnPausedListener(Executor arg0, OnPausedListener arg1) {
            return Call<StorageTask>("addOnPausedListener", arg0, arg1);
        }
        public StorageTask addOnPausedListener(Activity arg0, OnPausedListener arg1) {
            return Call<StorageTask>("addOnPausedListener", arg0, arg1);
        }
        public StorageTask addOnPausedListener(OnPausedListener arg0) {
            return Call<StorageTask>("addOnPausedListener", arg0);
        }
        public StorageTask addOnProgressListener(Executor arg0, OnProgressListener arg1) {
            return Call<StorageTask>("addOnProgressListener", arg0, arg1);
        }
        public StorageTask addOnProgressListener(OnProgressListener arg0) {
            return Call<StorageTask>("addOnProgressListener", arg0);
        }
        public StorageTask addOnProgressListener(Activity arg0, OnProgressListener arg1) {
            return Call<StorageTask>("addOnProgressListener", arg0, arg1);
        }
        public Task continueWithTask(Continuation arg0) {
            return Call<Task>("continueWithTask", arg0);
        }
        public Task continueWithTask(Executor arg0, Continuation arg1) {
            return Call<Task>("continueWithTask", arg0, arg1);
        }
        public Task continueWithTask(ExecuteResult arg0) {
            return Call<Task>("continueWithTask", arg0);
        }
        public Task continueWith(Executor arg0, Continuation arg1) {
            return Call<Task>("continueWith", arg0, arg1);
        }
        public Task continueWith(Continuation arg0) {
            return Call<Task>("continueWith", arg0);
        }
        public Task onSuccessTask(Executor arg0, SuccessContinuation arg1) {
            return Call<Task>("onSuccessTask", arg0, arg1);
        }
        public Task onSuccessTask(SuccessContinuation arg0) {
            return Call<Task>("onSuccessTask", arg0);
        }
        public bool cancel() {
            return Call<bool>("cancel");
        }
        public bool pause() {
            return Call<bool>("pause");
        }
        public bool isCanceled() {
            return Call<bool>("isCanceled");
        }
        public bool isComplete() {
            return Call<bool>("isComplete");
        }
        public bool isSuccessful() {
            return Call<bool>("isSuccessful");
        }
        public bool isInProgress() {
            return Call<bool>("isInProgress");
        }
        public bool isPaused() {
            return Call<bool>("isPaused");
        }
        public StorageTask.ErrorResult getResult() {
            return Call<StorageTask.ErrorResult>("getResult");
        }
        public void setResult(AndroidJavaObject arg0) {
            Call("setResult", arg0);
        }
        public StorageTask.ErrorResult getTimePointState() {
            return Call<StorageTask.ErrorResult>("getTimePointState");
        }
        public void setException(Exception arg0) {
            Call("setException", arg0);
        }
        public Exception getException() {
            return Call<Exception>("getException");
        }
        public AndroidJavaObject getResultThrowException(AndroidJavaClass arg0) {
            return Call<AndroidJavaObject>("getResultThrowException", arg0);
        }
        public StorageTask removeOnCanceledListener(OnCanceledListener arg0) {
            return Call<StorageTask>("removeOnCanceledListener", arg0);
        }
        public StorageTask removeOnCompleteListener(OnCompleteListener arg0) {
            return Call<StorageTask>("removeOnCompleteListener", arg0);
        }
        public StorageTask removeOnFailureListener(OnFailureListener arg0) {
            return Call<StorageTask>("removeOnFailureListener", arg0);
        }
        public StorageTask removeOnSuccessListener(OnSuccessListener arg0) {
            return Call<StorageTask>("removeOnSuccessListener", arg0);
        }
        public StorageTask removeOnPausedListener(OnPausedListener arg0) {
            return Call<StorageTask>("removeOnPausedListener", arg0);
        }
        public StorageTask removeOnProgressListener(OnProgressListener arg0) {
            return Call<StorageTask>("removeOnProgressListener", arg0);
        }

        public class UploadResult_Data : IHmsBaseClass{
            public string name => "com.huawei.agconnect.cloud.storage.core.UploadTask$UploadResult";
        }
        public class UploadResult :HmsClass<UploadResult_Data>
        {
            public UploadResult (): base() { }
            public long getBytesTransferred() {
                return Call<long>("getBytesTransferred");
            }
            public long getTotalByteCount() {
                return Call<long>("getTotalByteCount");
            }
            public FileMetadata getMetadata() {
                return Call<FileMetadata>("getMetadata");
            }
        }
    }
}