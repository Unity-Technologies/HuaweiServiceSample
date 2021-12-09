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
        public List executeQuery(CloudDBZoneQuery arg0) {
            return Call<List>("executeQuery", arg0);
        }
        public Transaction executeUpsert(List arg0) {
            return Call<Transaction>("executeUpsert", arg0);
        }
        public Transaction executeDelete(List arg0) {
            return Call<Transaction>("executeDelete", arg0);
        }
    
        public class FunctionData : IHmsBaseListener
        {
            public string name => "com.huawei.agconnect.cloud.database.Transaction$Function";
            public string buildName => "";
        }
        public class Function : HmsListener<FunctionData>
        {
        
            public virtual bool apply(Transaction arg0) {
                return Call<bool>("apply", arg0);
            }
        
            public bool apply(AndroidJavaObject arg0){
                return apply(HmsUtil.GetHmsBase<Transaction>(arg0));
            }
        }
    }
}