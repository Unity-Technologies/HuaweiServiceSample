using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.CloudDB {
    public class DBListener_Data : IHmsBaseClass {
        public string name => "com.huawei.unity.cloud.database.DBListener";
    }
    public class DBListener : HmsClass<DBListener_Data> {
        public DBListener (OnSnapshotListener arg0) : base (arg0) { }
    }
}