using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.CloudDB
{
    public class CloudDBZoneSnapshot_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.cloud.database.CloudDBZoneSnapshot";
    }
    public class CloudDBZoneSnapshot :HmsClass<CloudDBZoneSnapshot_Data>
    {
        public CloudDBZoneSnapshot (): base() { }
        public bool hasPendingWrites() {
            return Call<bool>("hasPendingWrites");
        }
        public bool isFromCloud() {
            return Call<bool>("isFromCloud");
        }
        public CloudDBZoneObjectList getSnapshotObjects() {
            return Call<CloudDBZoneObjectList>("getSnapshotObjects");
        }
        public CloudDBZoneObjectList getUpsertedObjects() {
            return Call<CloudDBZoneObjectList>("getUpsertedObjects");
        }
        public CloudDBZoneObjectList getDeletedObjects() {
            return Call<CloudDBZoneObjectList>("getDeletedObjects");
        }
        public void release() {
            Call("release");
        }
    }

    public class CloudDBZoneSnapshot<T> :CloudDBZoneSnapshot where T : IDatabaseModel, new() {
        public CloudDBZoneObjectList<T> getSnapshotObjects() {
            return Call<CloudDBZoneObjectList<T>>("getSnapshotObjects");
        }
        public CloudDBZoneObjectList<T> getUpsertedObjects() {
            return Call<CloudDBZoneObjectList<T>>("getUpsertedObjects");
        }
        public CloudDBZoneObjectList<T> getDeletedObjects() {
            return Call<CloudDBZoneObjectList<T>>("getDeletedObjects");
        }
    }
}