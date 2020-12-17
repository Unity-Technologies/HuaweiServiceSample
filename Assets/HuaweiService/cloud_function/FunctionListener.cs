using System;
using System.Collections.Generic;
using UnityEngine;

namespace HuaweiService.CloudFunction {
    public delegate void CompleteCallback<T> (T o);
    public delegate void CompleteCallback (String result);

    public class FunctionCompleteListener<T> : OnCompleteListener {
        public CompleteCallback<T> callback;
        public FunctionCompleteListener (CompleteCallback<T> cb) {
            callback = cb;
        }
        public override void onComplete (Task task) {
            if (task.isSuccessful ()) {
                FunctionResult result = new FunctionResult ();
                result.obj = task.getValue ();
                string str = result.getValue ();
                if (callback != null) {
                    Type type = typeof (T);
                    T val = JsonSerializer.FromJson<T> (str);
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
                FunctionResult result = new FunctionResult ();
                result.obj = task.getValue ();
                string str = result.getValue ();
                if (callback != null) {

                    callback.Invoke (str);
                }
            }
        }
    }
}