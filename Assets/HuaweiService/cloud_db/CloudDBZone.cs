using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.CloudDB
{
    public class CloudDBZone_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.cloud.database.CloudDBZone";
    }
    public class CloudDBZone :HmsClass<CloudDBZone_Data>
    {
        public const int MAX_OBJECT_LIST_SIZE = 1000;
        public const int MAX_OBJECT_LIST_CAPACITY = 2097152;
        public CloudDBZone (): base() { }
        public CloudDBZoneConfig getCloudDBZoneConfig() {
            return Call<CloudDBZoneConfig>("getCloudDBZoneConfig");
        }
        public Task executeUpsert(List arg0) {
            return Call<Task>("executeUpsert", arg0);
        }
        public Task executeUpsert(IDatabaseModel arg0) {
            return Call<Task>("executeUpsert", arg0);
        }
        public Task executeDelete(List arg0) {
            return Call<Task>("executeDelete", arg0);
        } 
        public Task executeDelete(IDatabaseModel arg0) {
            return Call<Task>("executeDelete", arg0);
        }
        public Task executeQuery(CloudDBZoneQuery arg0, CloudDBZoneQuery.CloudDBZoneQueryPolicy arg1) {
            return Call<Task>("executeQuery", arg0, arg1);
        }
        public Task executeAverageQuery(CloudDBZoneQuery arg0, string arg1, CloudDBZoneQuery.CloudDBZoneQueryPolicy arg2) {
            return Call<Task>("executeAverageQuery", arg0, arg1, arg2);
        }
        public Task executeQueryUnsynced(CloudDBZoneQuery arg0) {
            return Call<Task>("executeQueryUnsynced", arg0);
        }
        public Task runTransaction(Transaction.Function arg0) {
            return Call<Task>("runTransaction", arg0);
        }
        public ListenerHandler subscribeSnapshot(CloudDBZoneQuery arg0, CloudDBZoneQuery.CloudDBZoneQueryPolicy arg1, OnSnapshotListener arg2) {
            return Call<ListenerHandler>("subscribeSnapshot", arg0, arg1, new DBListener(arg2));
        }
    }
}