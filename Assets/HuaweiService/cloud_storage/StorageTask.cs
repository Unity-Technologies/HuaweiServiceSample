using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.CloudStorage
{
    public class StorageTask_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.cloud.storage.core.StorageTask";
    }
    public class StorageTask :HmsClass<StorageTask_Data>
    {
        public StorageTask (): base() { }
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
        public bool resume() {
            return Call<bool>("resume");
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
        public ErrorResult getResult() {
            return Call<ErrorResult>("getResult");
        }
        public void setResult(AndroidJavaObject arg0) {
            Call("setResult", arg0);
        }
        public ErrorResult getTimePointState() {
            return Call<ErrorResult>("getTimePointState");
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
    
        public class TimePointStateBase_Data : IHmsBaseClass{
            public string name => "com.huawei.agconnect.cloud.storage.core.StorageTask$TimePointStateBase";
        }
        public class TimePointStateBase :HmsClass<TimePointStateBase_Data>
        {
            public TimePointStateBase (StorageTask arg0, Exception arg1): base(arg0, arg1) { }
            public TimePointStateBase (): base() { }
            public StorageTask getTask() {
                return Call<StorageTask>("getTask");
            }
            public StorageReference getStorage() {
                return Call<StorageReference>("getStorage");
            }
            public Exception getError() {
                return Call<Exception>("getError");
            }
        }
    
        public class ErrorResultData : IHmsBaseListener
        {
            public string name => "com.huawei.agconnect.cloud.storage.core.StorageTask$ErrorResult";
            public string buildName => "";
        }
        public class ErrorResult : HmsListener<ErrorResultData>
        {
        
            public virtual Exception getError() {
                return Call<Exception>("getError");
            }
        }
    }
}