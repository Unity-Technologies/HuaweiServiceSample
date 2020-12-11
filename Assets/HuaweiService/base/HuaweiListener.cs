using System;
using UnityEngine;
using HuaweiService;

namespace HuaweiService
{
    public delegate void SuccessCallBack<T>(T o);
    public class HuaweiOnsuccessListener<T>:OnSuccessListener
    {
        public SuccessCallBack<T> CallBack;
        public HuaweiOnsuccessListener(SuccessCallBack<T> c){
            CallBack = c;
        }
        
        public void onSuccess(T arg0)
        {
            if(CallBack != null)
            {
                CallBack.Invoke(arg0);
            }
        }
        
        public override void onSuccess(AndroidJavaObject arg0){
            if(CallBack !=null)
            {
                if(CallBack !=null)
                {
                    Type type = typeof(T);
                    IHmsBase ret = (IHmsBase)Activator.CreateInstance(type);
                    ret.obj = arg0;
                    CallBack.Invoke((T)ret);
                }
            }
        }
        
    }
    
    public delegate void FailureCallBack(HuaweiService.Exception e);
    
    public class HuaweiOnFailureListener:OnFailureListener{
        public FailureCallBack CallBack;
        public HuaweiOnFailureListener(FailureCallBack c){
            CallBack = c;
        }
        public override void onFailure(HuaweiService.Exception arg0){
            if(CallBack !=null){
                CallBack.Invoke(arg0);
            }
        }
    }
}