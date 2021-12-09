using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.CloudDB
{
    public class EntireEncryptedData : IHmsBaseListener
    {
        public string name => "com.huawei.agconnect.cloud.database.annotations.EntireEncrypted";
        public string buildName => "";
    }
    public class EntireEncrypted : HmsListener<EntireEncryptedData>
    {
    
        public virtual bool isEncrypted() {
            return Call<bool>("isEncrypted");
        }
    }
}