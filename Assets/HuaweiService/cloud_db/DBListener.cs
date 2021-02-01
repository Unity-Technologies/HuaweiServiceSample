using System.Collections.Generic;
using HuaweiServiceDemo;
using UnityEngine;

namespace HuaweiService.CloudDB {
    public class DBListener_Data : IHmsBaseClass {
        public string name => "com.huawei.unity.cloud.database.DBListener";
    }
    public class DBListener : HmsClass<DBListener_Data> {
        public DBListener (OnSnapshotListener arg0) : base (arg0) { }
    }

    public class DBListener<T> : DBListener where T : IDatabaseModel, new () {
        public DBListener (DBSnapshotListener<T> arg0) : base (arg0) { }
    }
}