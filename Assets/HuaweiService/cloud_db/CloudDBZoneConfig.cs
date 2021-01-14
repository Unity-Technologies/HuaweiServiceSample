using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.CloudDB
{
    public class CloudDBZoneConfig_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.cloud.database.CloudDBZoneConfig";
    }
    public class CloudDBZoneConfig :HmsClass<CloudDBZoneConfig_Data>
    {
        public CloudDBZoneConfig (string arg0, CloudDBZoneSyncProperty arg1, CloudDBZoneAccessProperty arg2): base(arg0, arg1, arg2) { }
        public CloudDBZoneConfig (): base() { }
        public string getCloudDBZoneName() {
            return Call<string>("getCloudDBZoneName");
        }
        public CloudDBZoneSyncProperty getSyncProperty() {
            return Call<CloudDBZoneSyncProperty>("getSyncProperty");
        }
        public CloudDBZoneAccessProperty getAccessProperty() {
            return Call<CloudDBZoneAccessProperty>("getAccessProperty");
        }
        public bool isEncrypted() {
            return Call<bool>("isEncrypted");
        }
        public void setEncryptedKey(string arg0, string arg1) {
            Call("setEncryptedKey", arg0, arg1);
        }
        public void setPersistenceEnabled(bool arg0) {
            Call("setPersistenceEnabled", arg0);
        }
        public bool getPersistenceEnabled() {
            return Call<bool>("getPersistenceEnabled");
        }
        public void setCapacity(long arg0) {
            Call("setCapacity", arg0);
        }
        public long getCapacity() {
            return Call<long>("getCapacity");
        }
    
        public class CloudDBZoneAccessProperty_Data : IHmsBaseClass{
            public string name => "com.huawei.agconnect.cloud.database.CloudDBZoneConfig$CloudDBZoneAccessProperty";
        }
        public class CloudDBZoneAccessProperty :HmsClass<CloudDBZoneAccessProperty_Data>
        {
            public static CloudDBZoneAccessProperty CLOUDDBZONE_PUBLIC => HmsUtil.GetStaticValue<CloudDBZoneAccessProperty>("CLOUDDBZONE_PUBLIC", name);
        
            public CloudDBZoneAccessProperty (): base() { }
        }
    
        public class CloudDBZoneSyncProperty_Data : IHmsBaseClass{
            public string name => "com.huawei.agconnect.cloud.database.CloudDBZoneConfig$CloudDBZoneSyncProperty";
        }
        public class CloudDBZoneSyncProperty :HmsClass<CloudDBZoneSyncProperty_Data>
        {
            public static CloudDBZoneSyncProperty CLOUDDBZONE_LOCAL_ONLY => HmsUtil.GetStaticValue<CloudDBZoneSyncProperty>("CLOUDDBZONE_LOCAL_ONLY", name);
        
            public static CloudDBZoneSyncProperty CLOUDDBZONE_CLOUD_CACHE => HmsUtil.GetStaticValue<CloudDBZoneSyncProperty>("CLOUDDBZONE_CLOUD_CACHE", name);
        
            public CloudDBZoneSyncProperty (): base() { }
        }
    }
}