using System.Collections.Generic;
using UnityEngine;

namespace HuaweiService {
    public class Task_Data : IHmsBaseClass {
        public string name => "com.huawei.hmf.tasks.Task";
    }
    public class Task : HmsClass<Task_Data> {
        public Task () : base () { }
        public Task addOnCompleteListener (Activity arg0, OnCompleteListener arg1) {
            return Call<Task> ("addOnCompleteListener", arg0, arg1);
        }
        public Task addOnCompleteListener (Executor arg0, OnCompleteListener arg1) {
            return Call<Task> ("addOnCompleteListener", arg0, arg1);
        }
        public Task addOnCompleteListener (OnCompleteListener arg0) {
            return Call<Task> ("addOnCompleteListener", arg0);
        }
        public bool isSuccessful () {
            return Call<bool> ("isSuccessful");
        }
        public AndroidJavaObject getValue () {
            return Call<AndroidJavaObject> ("getResult");
        }
        public AndroidJavaObject getResult () {
            return Call<AndroidJavaObject> ("getResult");
        }
        public Task addOnSuccessListener (Activity arg0, OnSuccessListener arg1) {
            return Call<Task> ("addOnSuccessListener", arg0, arg1);
        }
        public Task addOnSuccessListener (OnSuccessListener arg0) {
            return Call<Task> ("addOnSuccessListener", arg0);
        }
        public Task addOnSuccessListener (Executor arg0, OnSuccessListener arg1) {
            return Call<Task> ("addOnSuccessListener", arg0, arg1);
        }
        public Task addOnFailureListener (OnFailureListener arg0) {
            return Call<Task> ("addOnFailureListener", arg0);
        }
        public Task addOnFailureListener (Activity arg0, OnFailureListener arg1) {
            return Call<Task> ("addOnFailureListener", arg0, arg1);
        }
        public Task addOnFailureListener (Executor arg0, OnFailureListener arg1) {
            return Call<Task> ("addOnFailureListener", arg0, arg1);
        }
    }
}