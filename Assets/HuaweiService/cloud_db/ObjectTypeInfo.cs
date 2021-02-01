using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.CloudDB
{
    public class ObjectTypeInfo_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.cloud.database.ObjectTypeInfo";
    }
    public class ObjectTypeInfo :HmsClass<ObjectTypeInfo_Data>
    {
        public ObjectTypeInfo (): base() { }
    }
}