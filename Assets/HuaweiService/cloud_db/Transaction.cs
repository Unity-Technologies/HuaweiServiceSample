using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.CloudDB
{
    public class Transaction_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.cloud.database.Transaction";
    }
    public class Transaction :HmsClass<Transaction_Data>
    {
        public Transaction (): base() { }
        public List executeQuery(CloudDBZoneQuery cloudDBZoneQuery) {
            return Call<List>("executeQuery", cloudDBZoneQuery);
        }
        public Transaction executeUpsert(List objectList) {
            return Call<Transaction>("executeUpsert", objectList);
        }
        public Transaction executeDelete(List objectList) {
            return Call<Transaction>("executeDelete", objectList);
        }
    
        public class FunctionData : IHmsBaseListener
        {
            public string name => "com.huawei.agconnect.cloud.database.Transaction$Function";
            public string buildName => "";
        }
        public class Function : HmsListener<FunctionData>
        {
        
            public virtual bool apply(Transaction transaction) {
                return Call<bool>("apply", transaction);
            }
        
            public bool apply(AndroidJavaObject transaction){
                return apply(HmsUtil.GetHmsBase<Transaction>(transaction));
            }
        }
    }
}