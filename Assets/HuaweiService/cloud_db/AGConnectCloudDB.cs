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
        public Task setUserKey(string arg0, string arg1) {
            return Call<Task>("setUserKey", arg0, arg1);
        }
        public Task updateDataEncryptionKey() {
            return Call<Task>("updateDataEncryptionKey");
        }
        public void addDataEncryptionKeyListener(OnDataEncryptionKeyChangeListener arg0) {
            Call("addDataEncryptionKeyListener", arg0);
        }
        public void addEventListener(EventListener arg0) {
            Call("addEventListener", arg0);
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
    
        public class EventListener_Data : IHmsBaseClass{
            public string name => "com.huawei.agconnect.cloud.database.AGConnectCloudDB$EventListener";
        }
        public class EventListener :HmsClass<EventListener_Data>
        {
            public EventListener (): base() { }
        }
    
        public class OnDataEncryptionKeyChangeListener_Data : IHmsBaseClass{
            public string name => "com.huawei.agconnect.cloud.database.AGConnectCloudDB$OnDataEncryptionKeyChangeListener";
        }
        public class OnDataEncryptionKeyChangeListener :HmsClass<OnDataEncryptionKeyChangeListener_Data>
        {
            public OnDataEncryptionKeyChangeListener (): base() { }
        }
    
        public class EventType_Data : IHmsBaseClass{
            public string name => "com.huawei.agconnect.cloud.database.AGConnectCloudDB$EventType";
        }
        public class EventType :HmsClass<EventType_Data>
        {
            public static EventType USER_KEY_CHANGED => HmsUtil.GetStaticValue<EventType>("USER_KEY_CHANGED");
        
            public EventType (): base() { }
        }
    }
}