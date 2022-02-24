using System;
using UnityEngine;

namespace HuaweiService
{
    public class ActivityData : IHmsBaseClass
    {
        public string name => "";
    }
    public class UnityPlayerActivity: Activity
    {
        public UnityPlayerActivity() : base()
        {
            obj = Common.GetActivity();
        }
    }
    
    public class Context : UnityPlayerActivity
    {   
        public Context():base(){

        }
        public Context getApplicationContext() {
            return Call<Context>("getApplicationContext");
        }
        public AndroidJavaObject getSystemService(AndroidJavaClass arg0) {
            return Call<AndroidJavaObject>("getSystemService", arg0);
        }
        public AndroidJavaObject getSystemService(string arg0) {
            return Call<AndroidJavaObject>("getSystemService", arg0);
        }
        public string getPackageName() {
            return Call<string>("getPackageName");
        }
        public File getFilesDir() {
            return Call<File>("getFilesDir");
        }
    }
}
