using UnityEngine;
using System.Collections.Generic;
using HuaweiService;

namespace HuaweiService.CloudDB
{
    public class CloudDBZoneQuery_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.cloud.database.CloudDBZoneQuery";
    }
    public class CloudDBZoneQuery :HmsClass<CloudDBZoneQuery_Data>
    {
        public CloudDBZoneQuery (): base() { }
        public static CloudDBZoneQuery where(AndroidJavaClass arg0) {
            return CallStatic<CloudDBZoneQuery>("where", arg0);
        }
        public CloudDBZoneQuery equalTo(string arg0, long arg1) {
            return Call<CloudDBZoneQuery>("equalTo", arg0, arg1);
        }
        public CloudDBZoneQuery equalTo(string arg0, string arg1) {
            return Call<CloudDBZoneQuery>("equalTo", arg0, arg1);
        }
        public CloudDBZoneQuery equalTo(string arg0, int arg1) {
            return Call<CloudDBZoneQuery>("equalTo", arg0, arg1);
        }
        public CloudDBZoneQuery equalTo(string arg0, double arg1) {
            return Call<CloudDBZoneQuery>("equalTo", arg0, arg1);
        }
        public CloudDBZoneQuery equalTo(string arg0, float arg1) {
            return Call<CloudDBZoneQuery>("equalTo", arg0, arg1);
        }
        public CloudDBZoneQuery equalTo(string arg0, Text arg1) {
            return Call<CloudDBZoneQuery>("equalTo", arg0, arg1);
        }
        public CloudDBZoneQuery equalTo(string arg0, Date arg1) {
            return Call<CloudDBZoneQuery>("equalTo", arg0, arg1);
        }
        public CloudDBZoneQuery equalTo(string arg0, bool arg1) {
            return Call<CloudDBZoneQuery>("equalTo", arg0, arg1);
        }
        public CloudDBZoneQuery equalTo(string arg0, short arg1) {
            return Call<CloudDBZoneQuery>("equalTo", arg0, arg1);
        }
        public CloudDBZoneQuery equalTo(string arg0, byte arg1) {
            return Call<CloudDBZoneQuery>("equalTo", arg0, arg1);
        }
        public CloudDBZoneQuery notEqualTo(string arg0, long arg1) {
            return Call<CloudDBZoneQuery>("notEqualTo", arg0, arg1);
        }
        public CloudDBZoneQuery notEqualTo(string arg0, double arg1) {
            return Call<CloudDBZoneQuery>("notEqualTo", arg0, arg1);
        }
        public CloudDBZoneQuery notEqualTo(string arg0, float arg1) {
            return Call<CloudDBZoneQuery>("notEqualTo", arg0, arg1);
        }
        public CloudDBZoneQuery notEqualTo(string arg0, int arg1) {
            return Call<CloudDBZoneQuery>("notEqualTo", arg0, arg1);
        }
        public CloudDBZoneQuery notEqualTo(string arg0, short arg1) {
            return Call<CloudDBZoneQuery>("notEqualTo", arg0, arg1);
        }
        public CloudDBZoneQuery notEqualTo(string arg0, byte arg1) {
            return Call<CloudDBZoneQuery>("notEqualTo", arg0, arg1);
        }
        public CloudDBZoneQuery notEqualTo(string arg0, Text arg1) {
            return Call<CloudDBZoneQuery>("notEqualTo", arg0, arg1);
        }
        public CloudDBZoneQuery notEqualTo(string arg0, bool arg1) {
            return Call<CloudDBZoneQuery>("notEqualTo", arg0, arg1);
        }
        public CloudDBZoneQuery notEqualTo(string arg0, Date arg1) {
            return Call<CloudDBZoneQuery>("notEqualTo", arg0, arg1);
        }
        public CloudDBZoneQuery notEqualTo(string arg0, string arg1) {
            return Call<CloudDBZoneQuery>("notEqualTo", arg0, arg1);
        }
        public CloudDBZoneQuery greaterThan(string arg0, int arg1) {
            return Call<CloudDBZoneQuery>("greaterThan", arg0, arg1);
        }
        public CloudDBZoneQuery greaterThan(string arg0, short arg1) {
            return Call<CloudDBZoneQuery>("greaterThan", arg0, arg1);
        }
        public CloudDBZoneQuery greaterThan(string arg0, long arg1) {
            return Call<CloudDBZoneQuery>("greaterThan", arg0, arg1);
        }
        public CloudDBZoneQuery greaterThan(string arg0, byte arg1) {
            return Call<CloudDBZoneQuery>("greaterThan", arg0, arg1);
        }
        public CloudDBZoneQuery greaterThan(string arg0, Text arg1) {
            return Call<CloudDBZoneQuery>("greaterThan", arg0, arg1);
        }
        public CloudDBZoneQuery greaterThan(string arg0, Date arg1) {
            return Call<CloudDBZoneQuery>("greaterThan", arg0, arg1);
        }
        public CloudDBZoneQuery greaterThan(string arg0, string arg1) {
            return Call<CloudDBZoneQuery>("greaterThan", arg0, arg1);
        }
        public CloudDBZoneQuery greaterThan(string arg0, float arg1) {
            return Call<CloudDBZoneQuery>("greaterThan", arg0, arg1);
        }
        public CloudDBZoneQuery greaterThan(string arg0, double arg1) {
            return Call<CloudDBZoneQuery>("greaterThan", arg0, arg1);
        }
        public CloudDBZoneQuery greaterThanOrEqualTo(string arg0, int arg1) {
            return Call<CloudDBZoneQuery>("greaterThanOrEqualTo", arg0, arg1);
        }
        public CloudDBZoneQuery greaterThanOrEqualTo(string arg0, long arg1) {
            return Call<CloudDBZoneQuery>("greaterThanOrEqualTo", arg0, arg1);
        }
        public CloudDBZoneQuery greaterThanOrEqualTo(string arg0, double arg1) {
            return Call<CloudDBZoneQuery>("greaterThanOrEqualTo", arg0, arg1);
        }
        public CloudDBZoneQuery greaterThanOrEqualTo(string arg0, Text arg1) {
            return Call<CloudDBZoneQuery>("greaterThanOrEqualTo", arg0, arg1);
        }
        public CloudDBZoneQuery greaterThanOrEqualTo(string arg0, float arg1) {
            return Call<CloudDBZoneQuery>("greaterThanOrEqualTo", arg0, arg1);
        }
        public CloudDBZoneQuery greaterThanOrEqualTo(string arg0, string arg1) {
            return Call<CloudDBZoneQuery>("greaterThanOrEqualTo", arg0, arg1);
        }
        public CloudDBZoneQuery greaterThanOrEqualTo(string arg0, Date arg1) {
            return Call<CloudDBZoneQuery>("greaterThanOrEqualTo", arg0, arg1);
        }
        public CloudDBZoneQuery greaterThanOrEqualTo(string arg0, byte arg1) {
            return Call<CloudDBZoneQuery>("greaterThanOrEqualTo", arg0, arg1);
        }
        public CloudDBZoneQuery greaterThanOrEqualTo(string arg0, short arg1) {
            return Call<CloudDBZoneQuery>("greaterThanOrEqualTo", arg0, arg1);
        }
        public CloudDBZoneQuery lessThanOrEqualTo(string arg0, int arg1) {
            return Call<CloudDBZoneQuery>("lessThanOrEqualTo", arg0, arg1);
        }
        public CloudDBZoneQuery lessThanOrEqualTo(string arg0, long arg1) {
            return Call<CloudDBZoneQuery>("lessThanOrEqualTo", arg0, arg1);
        }
        public CloudDBZoneQuery lessThanOrEqualTo(string arg0, double arg1) {
            return Call<CloudDBZoneQuery>("lessThanOrEqualTo", arg0, arg1);
        }
        public CloudDBZoneQuery lessThanOrEqualTo(string arg0, Text arg1) {
            return Call<CloudDBZoneQuery>("lessThanOrEqualTo", arg0, arg1);
        }
        public CloudDBZoneQuery lessThanOrEqualTo(string arg0, float arg1) {
            return Call<CloudDBZoneQuery>("lessThanOrEqualTo", arg0, arg1);
        }
        public CloudDBZoneQuery lessThanOrEqualTo(string arg0, string arg1) {
            return Call<CloudDBZoneQuery>("lessThanOrEqualTo", arg0, arg1);
        }
        public CloudDBZoneQuery lessThanOrEqualTo(string arg0, Date arg1) {
            return Call<CloudDBZoneQuery>("lessThanOrEqualTo", arg0, arg1);
        }
        public CloudDBZoneQuery lessThanOrEqualTo(string arg0, byte arg1) {
            return Call<CloudDBZoneQuery>("lessThanOrEqualTo", arg0, arg1);
        }
        public CloudDBZoneQuery lessThanOrEqualTo(string arg0, short arg1) {
            return Call<CloudDBZoneQuery>("lessThanOrEqualTo", arg0, arg1);
        }
        public CloudDBZoneQuery lessThan(string arg0, short arg1) {
            return Call<CloudDBZoneQuery>("lessThan", arg0, arg1);
        }
        public CloudDBZoneQuery lessThan(string arg0, double arg1) {
            return Call<CloudDBZoneQuery>("lessThan", arg0, arg1);
        }
        public CloudDBZoneQuery lessThan(string arg0, float arg1) {
            return Call<CloudDBZoneQuery>("lessThan", arg0, arg1);
        }
        public CloudDBZoneQuery lessThan(string arg0, string arg1) {
            return Call<CloudDBZoneQuery>("lessThan", arg0, arg1);
        }
        public CloudDBZoneQuery lessThan(string arg0, Text arg1) {
            return Call<CloudDBZoneQuery>("lessThan", arg0, arg1);
        }
        public CloudDBZoneQuery lessThan(string arg0, Date arg1) {
            return Call<CloudDBZoneQuery>("lessThan", arg0, arg1);
        }
        public CloudDBZoneQuery lessThan(string arg0, byte arg1) {
            return Call<CloudDBZoneQuery>("lessThan", arg0, arg1);
        }
        public CloudDBZoneQuery lessThan(string arg0, int arg1) {
            return Call<CloudDBZoneQuery>("lessThan", arg0, arg1);
        }
        public CloudDBZoneQuery lessThan(string arg0, long arg1) {
            return Call<CloudDBZoneQuery>("lessThan", arg0, arg1);
        }
        public CloudDBZoneQuery @in(string arg0, int[] arg1) {
            return Call<CloudDBZoneQuery>("in", arg0, (object)arg1);
        }
        public CloudDBZoneQuery @in(string arg0, long[] arg1) {
            return Call<CloudDBZoneQuery>("in", arg0, (object)arg1);
        }
        public CloudDBZoneQuery @in(string arg0, double[] arg1) {
            return Call<CloudDBZoneQuery>("in", arg0, (object)arg1);
        }
        public CloudDBZoneQuery @in(string arg0, short[] arg1) {
            return Call<CloudDBZoneQuery>("in", arg0, (object)arg1);
        }
        public CloudDBZoneQuery @in(string arg0, byte[] arg1) {
            return Call<CloudDBZoneQuery>("in", arg0, (object)arg1);
        }
        public CloudDBZoneQuery @in(string arg0, Date[] arg1) {
            return Call<CloudDBZoneQuery>("in", arg0, (object)arg1);
        }
        public CloudDBZoneQuery @in(string arg0, Text[] arg1) {
            return Call<CloudDBZoneQuery>("in", arg0, (object)arg1);
        }
        public CloudDBZoneQuery @in(string arg0, string[] arg1) {
            return Call<CloudDBZoneQuery>("in", arg0, (object)arg1);

        }
        public CloudDBZoneQuery @in(string arg0, float[] arg1) {
            return Call<CloudDBZoneQuery>("in", arg0, (object)arg1);
        }
        public CloudDBZoneQuery beginsWith(string arg0, string arg1) {
            return Call<CloudDBZoneQuery>("beginsWith", arg0, arg1);
        }
        public CloudDBZoneQuery beginsWith(string arg0, Text arg1) {
            return Call<CloudDBZoneQuery>("beginsWith", arg0, arg1);
        }
        public CloudDBZoneQuery endsWith(string arg0, Text arg1) {
            return Call<CloudDBZoneQuery>("endsWith", arg0, arg1);
        }
        public CloudDBZoneQuery endsWith(string arg0, string arg1) {
            return Call<CloudDBZoneQuery>("endsWith", arg0, arg1);
        }
        public CloudDBZoneQuery contains(string arg0, string arg1) {
            return Call<CloudDBZoneQuery>("contains", arg0, arg1);
        }
        public CloudDBZoneQuery contains(string arg0, Text arg1) {
            return Call<CloudDBZoneQuery>("contains", arg0, arg1);
        }
        public CloudDBZoneQuery isNull(string arg0) {
            return Call<CloudDBZoneQuery>("isNull", arg0);
        }
        public CloudDBZoneQuery isNotNull(string arg0) {
            return Call<CloudDBZoneQuery>("isNotNull", arg0);
        }
        public CloudDBZoneQuery orderByAsc(string arg0) {
            return Call<CloudDBZoneQuery>("orderByAsc", arg0);
        }
        public CloudDBZoneQuery orderByDesc(string arg0) {
            return Call<CloudDBZoneQuery>("orderByDesc", arg0);
        }
        public CloudDBZoneQuery limit(int arg0, int arg1) {
            return Call<CloudDBZoneQuery>("limit", arg0, arg1);
        }
        public CloudDBZoneQuery limit(int arg0) {
            return Call<CloudDBZoneQuery>("limit", arg0);
        }
    
       public class CloudDBZoneQueryPolicy_Data : IHmsBaseClass{
            public string name => "com.huawei.agconnect.cloud.database.CloudDBZoneQuery$CloudDBZoneQueryPolicy";
        }
        public class CloudDBZoneQueryPolicy :HmsClass<CloudDBZoneQueryPolicy_Data>
        {
            public static CloudDBZoneQueryPolicy POLICY_QUERY_FROM_LOCAL_ONLY => HmsUtil.GetStaticValue<CloudDBZoneQueryPolicy>("POLICY_QUERY_FROM_LOCAL_ONLY", name);
        
            public static CloudDBZoneQueryPolicy POLICY_QUERY_FROM_CLOUD_ONLY => HmsUtil.GetStaticValue<CloudDBZoneQueryPolicy>("POLICY_QUERY_FROM_CLOUD_ONLY", name);
        
            public CloudDBZoneQueryPolicy (): base() { }
        }
    }
}