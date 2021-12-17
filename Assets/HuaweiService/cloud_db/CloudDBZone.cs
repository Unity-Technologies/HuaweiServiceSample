using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.CloudDB
{
    public class CloudDBZone_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.cloud.database.CloudDBZone";
    }
    public class CloudDBZone :HmsClass<CloudDBZone_Data>
    {
        public CloudDBZone (): base() { }
        public CloudDBZoneConfig getCloudDBZoneConfig() {
            return Call<CloudDBZoneConfig>("getCloudDBZoneConfig");
        }
        public Task executeUpsert(CloudDBZoneObject cloudDBZoneObject) {
            return Call<Task>("executeUpsert", cloudDBZoneObject);
        }
        public Task executeUpsert(List objectList) {
            return Call<Task>("executeUpsert", objectList);
        }
        public Task executeDelete(CloudDBZoneObject cloudDBZoneObject) {
            return Call<Task>("executeDelete", cloudDBZoneObject);
        }
        public Task executeDelete(List objectList) {
            return Call<Task>("executeDelete", objectList);
        }
        public Task executeQuery(CloudDBZoneQuery cloudDBZoneQuery, CloudDBZoneQuery.CloudDBZoneQueryPolicy queryPolicy) {
            return Call<Task>("executeQuery", cloudDBZoneQuery, queryPolicy);
        }
        public Task executeAverageQuery(CloudDBZoneQuery cloudDBZoneQuery, string fieldName, CloudDBZoneQuery.CloudDBZoneQueryPolicy queryPolicy) {
            return Call<Task>("executeAverageQuery", cloudDBZoneQuery, fieldName, queryPolicy);
        }
        public Task executeQueryUnsynced(CloudDBZoneQuery cloudDBZoneQuery) {
            return Call<Task>("executeQueryUnsynced", cloudDBZoneQuery);
        }
        public Task runTransaction(Transaction.Function function) {
            return Call<Task>("runTransaction", function);
        }
        public ListenerHandler subscribeSnapshot(CloudDBZoneQuery cloudDBZoneQuery, CloudDBZoneQuery.CloudDBZoneQueryPolicy queryPolicy, OnSnapshotListener listener) {
            return Call<ListenerHandler>("subscribeSnapshot", cloudDBZoneQuery, queryPolicy, listener);
        }
    }
}