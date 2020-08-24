using System;
using UnityEngine;

namespace HuaweiHms
{
    public class ActivityData : IHmsBaseClass
    {
        public string name => "";
    }
    public class Activity: HmsClass<ActivityData>
    {
        public Activity() : base()
        {
            obj = Common.GetActivity();
        }
    }
    public class Context : Activity
    {   
        public Context():base(){

        }
    }
}
