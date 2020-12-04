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
    }
}
