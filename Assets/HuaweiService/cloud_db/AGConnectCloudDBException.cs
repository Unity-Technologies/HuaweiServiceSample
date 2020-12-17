using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.CloudDB
{
    public class AGConnectCloudDBException_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.cloud.database.exceptions.AGConnectCloudDBException";
    }
    public class AGConnectCloudDBException :HmsClass<AGConnectCloudDBException_Data>
    {
        public const int OK = 0;
        public const int RESOURCE_EXHAUSTED = 1;
        public const int TIMEOUT = 2;
        public const int FAILED_PRECONDITION = 3;
        public const int PERMISSION_DENIED = 4;
        public const int UNKNOWN = 5;
        public const int DATA_SIZE_OVERFLOW = 6;
        public AGConnectCloudDBException (string arg0, int arg1): base(arg0, arg1) { }
        public AGConnectCloudDBException (): base() { }
        public int getCode() {
            return Call<int>("getCode");
        }
        public string getErrMsg() {
            return Call<string>("getErrMsg");
        }
        public string getMessage() {
            return Call<string>("getMessage");
        }
    }
}