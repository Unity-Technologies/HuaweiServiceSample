using System;
using System.Collections.Generic;
using UnityEngine;

namespace HuaweiService.CloudFunction{
    public delegate void CompleteCallback<T> (T o);
    public delegate void CompleteCallback (String result);

    public class FunctionCompleteListener<T> : OnCompleteListener {
        public CompleteCallback<T> callback;
        public FunctionCompleteListener (CompleteCallback<T> cb) {
            callback = cb;
        }
        public override void onComplete (Task task) {
            if (task.isSuccessful ()) {
                string result = task.getValue ();
                if (callback != null) {
                    Type type = typeof (T);
                    T val = JsonSerializer.FromJson<T> (result);
                    callback.Invoke (val);
                }
            } 
        }
    }

    public class FunctionCompleteListener : OnCompleteListener {
        public CompleteCallback callback;
        public FunctionCompleteListener (CompleteCallback cb) {
            callback = cb;
        }
        public override void onComplete (Task task) {
            if (task.isSuccessful ()) {
                string result = task.getValue ();
                if (callback != null) {

                    callback.Invoke (result);
                }
            } 
        }
    }
}