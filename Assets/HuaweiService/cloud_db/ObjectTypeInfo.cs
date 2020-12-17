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

     public class ObjectTypeInfoHelper_Data : IHmsBaseClass{
        public string name => "com.huawei.agc.clouddb.quickstart.model.ObjectTypeInfoHelper";
    }
    public class ObjectTypeInfoHelper :HmsClass<ObjectTypeInfoHelper_Data>
    {
        public ObjectTypeInfoHelper (): base() { }

        public static ObjectTypeInfo getObjectTypeInfo() {
            return CallStatic<ObjectTypeInfo>("getObjectTypeInfo");
        } 
    }
}