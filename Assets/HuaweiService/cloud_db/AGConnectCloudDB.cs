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
        public static void initialize(Context context) {
            CallStatic("initialize", context);
        }
        public static AGConnectCloudDB getInstance() {
            return CallStatic<AGConnectCloudDB>("getInstance");
        }
        public static AGConnectCloudDB getInstance(AGConnectInstance connectInstance, Auth.AGConnectAuth auth) {
            return CallStatic<AGConnectCloudDB>("getInstance", connectInstance, auth);
        }
        public Task setUserKey(string userKey, string userReKey) {
            return Call<Task>("setUserKey", userKey, userReKey);
        }
        public Task setUserKey(string userKey, string userReKey, bool needStrongCheck) {
            return Call<Task>("setUserKey", userKey, userReKey, needStrongCheck);
        }
        public Task updateDataEncryptionKey() {
            return Call<Task>("updateDataEncryptionKey");
        }
        public void addDataEncryptionKeyListener(OnDataEncryptionKeyChangeListener dataEncryptionKeyListener) {
            Call("addDataEncryptionKeyListener", dataEncryptionKeyListener);
        }
        public void addEventListener(EventListener eventListener) {
            Call("addEventListener", eventListener);
        }
        public void createObjectType(ObjectTypeInfo objectTypeInfo) {
            Call("createObjectType", objectTypeInfo);
        }
        public List getCloudDBZoneConfigs() {
            return Call<List>("getCloudDBZoneConfigs");
        }
        public CloudDBZone openCloudDBZone(CloudDBZoneConfig config, bool isAllowToCreate) {
            return Call<CloudDBZone>("openCloudDBZone", config, isAllowToCreate);
        }
        public Task openCloudDBZone2(CloudDBZoneConfig config, bool isAllowToCreate) {
            return Call<Task>("openCloudDBZone2", config, isAllowToCreate);
        }
        public void closeCloudDBZone(CloudDBZone zone) {
            Call("closeCloudDBZone", zone);
        }
        public void deleteCloudDBZone(string zoneName) {
            Call("deleteCloudDBZone", zoneName);
        }
        public void enableNetwork(string zoneName) {
            Call("enableNetwork", zoneName);
        }
        public void disableNetwork(string zoneName) {
            Call("disableNetwork", zoneName);
        }
    
        public class EventListenerData : IHmsBaseListener
        {
            public string name => "com.huawei.agconnect.cloud.database.AGConnectCloudDB$EventListener";
            public string buildName => "";
        }
        public class EventListener : HmsListener<EventListenerData>
        {
        
            public virtual void onEvent(EventType eventType) {
                Call("onEvent", eventType);
            }
        
            public void onEvent(AndroidJavaObject eventType){
                onEvent(HmsUtil.GetHmsBase<EventType>(eventType));
            }
        }
    
        public class OnDataEncryptionKeyChangeListenerData : IHmsBaseListener
        {
            public string name => "com.huawei.agconnect.cloud.database.AGConnectCloudDB$OnDataEncryptionKeyChangeListener";
            public string buildName => "";
        }
        public class OnDataEncryptionKeyChangeListener : HmsListener<OnDataEncryptionKeyChangeListenerData>
        {
        
            public virtual bool needFetchDataEncryptionKey() {
                return Call<bool>("needFetchDataEncryptionKey");
            }
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