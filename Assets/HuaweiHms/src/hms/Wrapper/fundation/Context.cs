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

        public Intent getIntent()
        {
            return Call<Intent>("getIntent");
        }

        public void startActivity(Intent arg0)
        {
            Call("startActivity", arg0);
        }
    }
    public class Context : Activity
    {   
        public Context():base(){

        }
    }
}
