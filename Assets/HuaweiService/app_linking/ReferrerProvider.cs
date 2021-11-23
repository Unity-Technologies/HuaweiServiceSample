using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.AppLinking
{
    public class ReferrerProvider_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.applinking.ReferrerProvider";
    }
    public class ReferrerProvider :HmsClass<ReferrerProvider_Data>
    {
        public ReferrerProvider (): base() { }
        public Task getCustomReferrer() {
            return Call<Task>("getCustomReferrer");
        }
    }
}