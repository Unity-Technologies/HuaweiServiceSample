using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.CloudDB
{
    public class CloudDBZoneObject_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.cloud.database.CloudDBZoneObject";
    }
    public class CloudDBZoneObject :HmsClass<CloudDBZoneObject_Data>
    {
        public CloudDBZoneObject (): base() { }
        public string getObjectTypeName() {
            return Call<string>("getObjectTypeName");
        }
        public string getPackageName() {
            return Call<string>("getPackageName");
        }
    }
}