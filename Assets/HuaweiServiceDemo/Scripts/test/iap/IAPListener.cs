using System;
using UnityEngine;
using HuaweiService;
using HuaweiService.IAP;
using Exception = HuaweiService.Exception;

namespace HuaweiServiceDemo{
    public delegate void IAPCallBack<T>(T o);
    public class HmsIapListener<T>:OnSuccessListener{
        public IAPCallBack<T> CallBack;
        public HmsIapListener(IAPCallBack<T> c){
            CallBack = c;
        }
        public void onSuccess(T arg0)
        {
            TestTip.Inst.ShowText("OnSuccessListener onSuccess");
            if(CallBack != null)
            {
                CallBack.Invoke(arg0);
            }
        }
        
        public override void onSuccess(AndroidJavaObject arg0){
            TestTip.Inst.ShowText("OnSuccessListener onSuccess");
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