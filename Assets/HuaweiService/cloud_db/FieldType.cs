using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.CloudDB
{
    public class FieldType_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.cloud.database.FieldType";
    }
    public class FieldType :HmsClass<FieldType_Data>
    {
        public static FieldType a => HmsUtil.GetStaticValue<FieldType>("a");
    
        public static FieldType b => HmsUtil.GetStaticValue<FieldType>("b");
    
        public static FieldType c => HmsUtil.GetStaticValue<FieldType>("c");
    
        public static FieldType d => HmsUtil.GetStaticValue<FieldType>("d");
    
        public static FieldType e => HmsUtil.GetStaticValue<FieldType>("e");
    
        public static FieldType f => HmsUtil.GetStaticValue<FieldType>("f");
    
        public static FieldType g => HmsUtil.GetStaticValue<FieldType>("g");
    
        public static FieldType h => HmsUtil.GetStaticValue<FieldType>("h");
    
        public static FieldType i => HmsUtil.GetStaticValue<FieldType>("i");
    
        public static FieldType j => HmsUtil.GetStaticValue<FieldType>("j");
    
        public static FieldType k => HmsUtil.GetStaticValue<FieldType>("k");
    
        public static FieldType l => HmsUtil.GetStaticValue<FieldType>("l");
    
        public FieldType (): base() { }
    }
}