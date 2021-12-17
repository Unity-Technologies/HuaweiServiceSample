using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.CloudDB
{
    public class CloudDBZoneConfig_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.cloud.database.CloudDBZoneConfig";
    }
    public class CloudDBZoneConfig :HmsClass<CloudDBZoneConfig_Data>
    {
        public CloudDBZoneConfig (string cloudDBZoneNameSource, CloudDBZoneSyncProperty syncPropertySource, CloudDBZoneAccessProperty accessPropertySource): base(cloudDBZoneNameSource, syncPropertySource, accessPropertySource) { }
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
        public void setEncryptedKey(string key, string rekey) {
            Call("setEncryptedKey", key, rekey);
        }
        public void setPersistenceEnabled(bool isPerEnable) {
            Call("setPersistenceEnabled", isPerEnable);
        }
        public bool getPersistenceEnabled() {
            return Call<bool>("getPersistenceEnabled");
        }
        public void setCapacity(long capacity) {
            Call("setCapacity", capacity);
        }
        public long getCapacity() {
            return Call<long>("getCapacity");
        }
    
        public class CloudDBZoneAccessProperty_Data : IHmsBaseClass{
            public string name => "com.huawei.agconnect.cloud.database.CloudDBZoneConfig$CloudDBZoneAccessProperty";
        }
        public class CloudDBZoneAccessProperty :HmsClass<CloudDBZoneAccessProperty_Data>
        {
            public static CloudDBZoneAccessProperty CLOUDDBZONE_PUBLIC => HmsUtil.GetStaticValue<CloudDBZoneAccessProperty>("CLOUDDBZONE_PUBLIC");
        
            public CloudDBZoneAccessProperty (): base() { }
        }
    
        public class CloudDBZoneSyncProperty_Data : IHmsBaseClass{
            public string name => "com.huawei.agconnect.cloud.database.CloudDBZoneConfig$CloudDBZoneSyncProperty";
        }
        public class CloudDBZoneSyncProperty :HmsClass<CloudDBZoneSyncProperty_Data>
        {
            public static CloudDBZoneSyncProperty CLOUDDBZONE_LOCAL_ONLY => HmsUtil.GetStaticValue<CloudDBZoneSyncProperty>("CLOUDDBZONE_LOCAL_ONLY");
        
            public static CloudDBZoneSyncProperty CLOUDDBZONE_CLOUD_CACHE => HmsUtil.GetStaticValue<CloudDBZoneSyncProperty>("CLOUDDBZONE_CLOUD_CACHE");
        
            public CloudDBZoneSyncProperty (): base() { }
        }
    }
}