using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.CloudDB
{
    public class AGConnectCloudDB_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.cloud.database.AGConnectCloudDB";
    }
    public class AGConnectCloudDB :HmsClass<AGConnectCloudDB_Data>
    {
        public AGConnectCloudDB (): base() { }
        public static void initialize(Context arg0) {
            CallStatic("initialize", arg0);
        }
        public static AGConnectCloudDB getInstance() {
            return CallStatic<AGConnectCloudDB>("getInstance");
        }
        public void createObjectType(ObjectTypeInfo arg0) {
            Call("createObjectType", arg0);
        }
        public List getCloudDBZoneConfigs() {
            return Call<List>("getCloudDBZoneConfigs");
        }
        public CloudDBZone openCloudDBZone(CloudDBZoneConfig arg0, bool arg1) {
            return Call<CloudDBZone>("openCloudDBZone", arg0, arg1);
        }
        public Task openCloudDBZone2(CloudDBZoneConfig arg0, bool arg1) {
            return Call<Task>("openCloudDBZone2", arg0, arg1);
        }
        public void closeCloudDBZone(CloudDBZone arg0) {
            Call("closeCloudDBZone", arg0);
        }
        public void deleteCloudDBZone(string arg0) {
            Call("deleteCloudDBZone", arg0);
        }
        public void enableNetwork(string arg0) {
            Call("enableNetwork", arg0);
        }
        public void disableNetwork(string arg0) {
            Call("disableNetwork", arg0);
        }
    }
}