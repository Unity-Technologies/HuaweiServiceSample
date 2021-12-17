using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.CloudDB
{
    public class CloudDBZoneQuery_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.cloud.database.CloudDBZoneQuery";
    }
    public class CloudDBZoneQuery :HmsClass<CloudDBZoneQuery_Data>
    {
        public CloudDBZoneQuery (): base() { }
        public static CloudDBZoneQuery where(AndroidJavaClass entityClass) {
            return CallStatic<CloudDBZoneQuery>("where", entityClass);
        }
        public CloudDBZoneQuery equalTo(string fieldName, double value) {
            return Call<CloudDBZoneQuery>("equalTo", fieldName, value);
        }
        public CloudDBZoneQuery equalTo(string fieldName, Text value) {
            return Call<CloudDBZoneQuery>("equalTo", fieldName, value);
        }
        public CloudDBZoneQuery equalTo(string fieldName, long value) {
            return Call<CloudDBZoneQuery>("equalTo", fieldName, value);
        }
        public CloudDBZoneQuery equalTo(string fieldName, Date value) {
            return Call<CloudDBZoneQuery>("equalTo", fieldName, value);
        }
        public CloudDBZoneQuery equalTo(string fieldName, float value) {
            return Call<CloudDBZoneQuery>("equalTo", fieldName, value);
        }
        public CloudDBZoneQuery equalTo(string fieldName, string value) {
            return Call<CloudDBZoneQuery>("equalTo", fieldName, value);
        }
        public CloudDBZoneQuery equalTo(string fieldName, int value) {
            return Call<CloudDBZoneQuery>("equalTo", fieldName, value);
        }
        public CloudDBZoneQuery equalTo(string fieldName, bool value) {
            return Call<CloudDBZoneQuery>("equalTo", fieldName, value);
        }
        public CloudDBZoneQuery equalTo(string fieldName, byte value) {
            return Call<CloudDBZoneQuery>("equalTo", fieldName, value);
        }
        public CloudDBZoneQuery equalTo(string fieldName, short value) {
            return Call<CloudDBZoneQuery>("equalTo", fieldName, value);
        }
        public CloudDBZoneQuery notEqualTo(string fieldName, float value) {
            return Call<CloudDBZoneQuery>("notEqualTo", fieldName, value);
        }
        public CloudDBZoneQuery notEqualTo(string fieldName, string value) {
            return Call<CloudDBZoneQuery>("notEqualTo", fieldName, value);
        }
        public CloudDBZoneQuery notEqualTo(string fieldName, Date value) {
            return Call<CloudDBZoneQuery>("notEqualTo", fieldName, value);
        }
        public CloudDBZoneQuery notEqualTo(string fieldName, Text value) {
            return Call<CloudDBZoneQuery>("notEqualTo", fieldName, value);
        }
        public CloudDBZoneQuery notEqualTo(string fieldName, bool value) {
            return Call<CloudDBZoneQuery>("notEqualTo", fieldName, value);
        }
        public CloudDBZoneQuery notEqualTo(string fieldName, byte value) {
            return Call<CloudDBZoneQuery>("notEqualTo", fieldName, value);
        }
        public CloudDBZoneQuery notEqualTo(string fieldName, short value) {
            return Call<CloudDBZoneQuery>("notEqualTo", fieldName, value);
        }
        public CloudDBZoneQuery notEqualTo(string fieldName, int value) {
            return Call<CloudDBZoneQuery>("notEqualTo", fieldName, value);
        }
        public CloudDBZoneQuery notEqualTo(string fieldName, long value) {
            return Call<CloudDBZoneQuery>("notEqualTo", fieldName, value);
        }
        public CloudDBZoneQuery notEqualTo(string fieldName, double value) {
            return Call<CloudDBZoneQuery>("notEqualTo", fieldName, value);
        }
        public CloudDBZoneQuery greaterThan(string fieldName, Date value) {
            return Call<CloudDBZoneQuery>("greaterThan", fieldName, value);
        }
        public CloudDBZoneQuery greaterThan(string fieldName, Text value) {
            return Call<CloudDBZoneQuery>("greaterThan", fieldName, value);
        }
        public CloudDBZoneQuery greaterThan(string fieldName, short value) {
            return Call<CloudDBZoneQuery>("greaterThan", fieldName, value);
        }
        public CloudDBZoneQuery greaterThan(string fieldName, float value) {
            return Call<CloudDBZoneQuery>("greaterThan", fieldName, value);
        }
        public CloudDBZoneQuery greaterThan(string fieldName, byte value) {
            return Call<CloudDBZoneQuery>("greaterThan", fieldName, value);
        }
        public CloudDBZoneQuery greaterThan(string fieldName, int value) {
            return Call<CloudDBZoneQuery>("greaterThan", fieldName, value);
        }
        public CloudDBZoneQuery greaterThan(string fieldName, long value) {
            return Call<CloudDBZoneQuery>("greaterThan", fieldName, value);
        }
        public CloudDBZoneQuery greaterThan(string fieldName, double value) {
            return Call<CloudDBZoneQuery>("greaterThan", fieldName, value);
        }
        public CloudDBZoneQuery greaterThan(string fieldName, string value) {
            return Call<CloudDBZoneQuery>("greaterThan", fieldName, value);
        }
        public CloudDBZoneQuery greaterThanOrEqualTo(string fieldName, long value) {
            return Call<CloudDBZoneQuery>("greaterThanOrEqualTo", fieldName, value);
        }
        public CloudDBZoneQuery greaterThanOrEqualTo(string fieldName, float value) {
            return Call<CloudDBZoneQuery>("greaterThanOrEqualTo", fieldName, value);
        }
        public CloudDBZoneQuery greaterThanOrEqualTo(string fieldName, double value) {
            return Call<CloudDBZoneQuery>("greaterThanOrEqualTo", fieldName, value);
        }
        public CloudDBZoneQuery greaterThanOrEqualTo(string fieldName, byte value) {
            return Call<CloudDBZoneQuery>("greaterThanOrEqualTo", fieldName, value);
        }
        public CloudDBZoneQuery greaterThanOrEqualTo(string fieldName, int value) {
            return Call<CloudDBZoneQuery>("greaterThanOrEqualTo", fieldName, value);
        }
        public CloudDBZoneQuery greaterThanOrEqualTo(string fieldName, short value) {
            return Call<CloudDBZoneQuery>("greaterThanOrEqualTo", fieldName, value);
        }
        public CloudDBZoneQuery greaterThanOrEqualTo(string fieldName, string value) {
            return Call<CloudDBZoneQuery>("greaterThanOrEqualTo", fieldName, value);
        }
        public CloudDBZoneQuery greaterThanOrEqualTo(string fieldName, Text value) {
            return Call<CloudDBZoneQuery>("greaterThanOrEqualTo", fieldName, value);
        }
        public CloudDBZoneQuery greaterThanOrEqualTo(string fieldName, Date value) {
            return Call<CloudDBZoneQuery>("greaterThanOrEqualTo", fieldName, value);
        }
        public CloudDBZoneQuery lessThan(string fieldName, string value) {
            return Call<CloudDBZoneQuery>("lessThan", fieldName, value);
        }
        public CloudDBZoneQuery lessThan(string fieldName, Date value) {
            return Call<CloudDBZoneQuery>("lessThan", fieldName, value);
        }
        public CloudDBZoneQuery lessThan(string fieldName, Text value) {
            return Call<CloudDBZoneQuery>("lessThan", fieldName, value);
        }
        public CloudDBZoneQuery lessThan(string fieldName, byte value) {
            return Call<CloudDBZoneQuery>("lessThan", fieldName, value);
        }
        public CloudDBZoneQuery lessThan(string fieldName, double value) {
            return Call<CloudDBZoneQuery>("lessThan", fieldName, value);
        }
        public CloudDBZoneQuery lessThan(string fieldName, int value) {
            return Call<CloudDBZoneQuery>("lessThan", fieldName, value);
        }
        public CloudDBZoneQuery lessThan(string fieldName, long value) {
            return Call<CloudDBZoneQuery>("lessThan", fieldName, value);
        }
        public CloudDBZoneQuery lessThan(string fieldName, short value) {
            return Call<CloudDBZoneQuery>("lessThan", fieldName, value);
        }
        public CloudDBZoneQuery lessThan(string fieldName, float value) {
            return Call<CloudDBZoneQuery>("lessThan", fieldName, value);
        }
        public CloudDBZoneQuery lessThanOrEqualTo(string fieldName, float value) {
            return Call<CloudDBZoneQuery>("lessThanOrEqualTo", fieldName, value);
        }
        public CloudDBZoneQuery lessThanOrEqualTo(string fieldName, string value) {
            return Call<CloudDBZoneQuery>("lessThanOrEqualTo", fieldName, value);
        }
        public CloudDBZoneQuery lessThanOrEqualTo(string fieldName, Date value) {
            return Call<CloudDBZoneQuery>("lessThanOrEqualTo", fieldName, value);
        }
        public CloudDBZoneQuery lessThanOrEqualTo(string fieldName, Text value) {
            return Call<CloudDBZoneQuery>("lessThanOrEqualTo", fieldName, value);
        }
        public CloudDBZoneQuery lessThanOrEqualTo(string fieldName, byte value) {
            return Call<CloudDBZoneQuery>("lessThanOrEqualTo", fieldName, value);
        }
        public CloudDBZoneQuery lessThanOrEqualTo(string fieldName, short value) {
            return Call<CloudDBZoneQuery>("lessThanOrEqualTo", fieldName, value);
        }
        public CloudDBZoneQuery lessThanOrEqualTo(string fieldName, int value) {
            return Call<CloudDBZoneQuery>("lessThanOrEqualTo", fieldName, value);
        }
        public CloudDBZoneQuery lessThanOrEqualTo(string fieldName, long value) {
            return Call<CloudDBZoneQuery>("lessThanOrEqualTo", fieldName, value);
        }
        public CloudDBZoneQuery lessThanOrEqualTo(string fieldName, double value) {
            return Call<CloudDBZoneQuery>("lessThanOrEqualTo", fieldName, value);
        }
        public CloudDBZoneQuery @in(string fieldName, Float[] values) {
            return Call<CloudDBZoneQuery>("in", fieldName, values);
        }
        public CloudDBZoneQuery @in(string fieldName, Double[] values) {
            return Call<CloudDBZoneQuery>("in", fieldName, values);
        }
        public CloudDBZoneQuery @in(string fieldName, string[] values) {
            return Call<CloudDBZoneQuery>("in", fieldName, values);
        }
        public CloudDBZoneQuery @in(string fieldName, Byte[] values) {
            return Call<CloudDBZoneQuery>("in", fieldName, values);
        }
        public CloudDBZoneQuery @in(string fieldName, Short[] values) {
            return Call<CloudDBZoneQuery>("in", fieldName, values);
        }
        public CloudDBZoneQuery @in(string fieldName, Integer[] values) {
            return Call<CloudDBZoneQuery>("in", fieldName, values);
        }
        public CloudDBZoneQuery @in(string fieldName, Long[] values) {
            return Call<CloudDBZoneQuery>("in", fieldName, values);
        }
        public CloudDBZoneQuery @in(string fieldName, Text[] values) {
            return Call<CloudDBZoneQuery>("in", fieldName, values);
        }
        public CloudDBZoneQuery @in(string fieldName, Date[] values) {
            return Call<CloudDBZoneQuery>("in", fieldName, values);
        }
        public CloudDBZoneQuery beginsWith(string fieldName, string value) {
            return Call<CloudDBZoneQuery>("beginsWith", fieldName, value);
        }
        public CloudDBZoneQuery beginsWith(string fieldName, Text value) {
            return Call<CloudDBZoneQuery>("beginsWith", fieldName, value);
        }
        public CloudDBZoneQuery endsWith(string fieldName, Text value) {
            return Call<CloudDBZoneQuery>("endsWith", fieldName, value);
        }
        public CloudDBZoneQuery endsWith(string fieldName, string value) {
            return Call<CloudDBZoneQuery>("endsWith", fieldName, value);
        }
        public CloudDBZoneQuery contains(string fieldName, Text value) {
            return Call<CloudDBZoneQuery>("contains", fieldName, value);
        }
        public CloudDBZoneQuery contains(string fieldName, string value) {
            return Call<CloudDBZoneQuery>("contains", fieldName, value);
        }
        public CloudDBZoneQuery isNull(string fieldName) {
            return Call<CloudDBZoneQuery>("isNull", fieldName);
        }
        public CloudDBZoneQuery isNotNull(string fieldName) {
            return Call<CloudDBZoneQuery>("isNotNull", fieldName);
        }
        public CloudDBZoneQuery orderByAsc(string fieldName) {
            return Call<CloudDBZoneQuery>("orderByAsc", fieldName);
        }
        public CloudDBZoneQuery orderByDesc(string fieldName) {
            return Call<CloudDBZoneQuery>("orderByDesc", fieldName);
        }
        public CloudDBZoneQuery limit(int count, int offset) {
            return Call<CloudDBZoneQuery>("limit", count, offset);
        }
        public CloudDBZoneQuery limit(int count) {
            return Call<CloudDBZoneQuery>("limit", count);
        }
        public CloudDBZoneQuery startAt(CloudDBZoneObject queryObject) {
            return Call<CloudDBZoneQuery>("startAt", queryObject);
        }
        public CloudDBZoneQuery startAfter(CloudDBZoneObject queryObject) {
            return Call<CloudDBZoneQuery>("startAfter", queryObject);
        }
        public CloudDBZoneQuery endAt(CloudDBZoneObject queryObject) {
            return Call<CloudDBZoneQuery>("endAt", queryObject);
        }
        public CloudDBZoneQuery endBefore(CloudDBZoneObject queryObject) {
            return Call<CloudDBZoneQuery>("endBefore", queryObject);
        }
    
        public class CloudDBZoneQueryPolicy_Data : IHmsBaseClass{
            public string name => "com.huawei.agconnect.cloud.database.CloudDBZoneQuery$CloudDBZoneQueryPolicy";
        }
        public class CloudDBZoneQueryPolicy :HmsClass<CloudDBZoneQueryPolicy_Data>
        {
            public static CloudDBZoneQueryPolicy POLICY_QUERY_FROM_LOCAL_ONLY => HmsUtil.GetStaticValue<CloudDBZoneQueryPolicy>("POLICY_QUERY_FROM_LOCAL_ONLY");
        
            public static CloudDBZoneQueryPolicy POLICY_QUERY_FROM_CLOUD_ONLY => HmsUtil.GetStaticValue<CloudDBZoneQueryPolicy>("POLICY_QUERY_FROM_CLOUD_ONLY");
        
            public static CloudDBZoneQueryPolicy POLICY_QUERY_DEFAULT => HmsUtil.GetStaticValue<CloudDBZoneQueryPolicy>("POLICY_QUERY_DEFAULT");
        
            public CloudDBZoneQueryPolicy (): base() { }
        }
    }
}