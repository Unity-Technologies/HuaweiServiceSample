using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.push
{
    public class AAIDResult_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.aaid.entity.AAIDResult";
    }
    public class AAIDResult :HmsClass<AAIDResult_Data>
    {
        public AAIDResult (): base() { }
        public string getId() {
            return Call<string>("getId");
        }
    }
}