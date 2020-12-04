using System;
using System.Collections.Generic;
using UnityEngine;

namespace HuaweiService
{
    public class Common
    {
        public const string UNITY_PLAYER = "com.unity3d.player.UnityPlayer";
        public static AndroidJavaObject GetActivity()
        {
            AndroidJavaClass player = new AndroidJavaClass(UNITY_PLAYER);
            AndroidJavaObject activity = player.GetStatic<AndroidJavaObject>("currentActivity");
            return activity;
        }
        public static void RunOnUiThread(AndroidJavaRunnable a){
            GetActivity().Call("runOnUiThread", new AndroidJavaRunnable(a));
        }
    }
}