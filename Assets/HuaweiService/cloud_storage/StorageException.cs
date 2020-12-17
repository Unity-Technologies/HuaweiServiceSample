using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.CloudStorage
{
    public class StorageException_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.cloud.storage.core.StorageException";
    }
    public class StorageException :HmsClass<StorageException_Data>
    {
        public const int ERROR_UNKNOWN = 11001;
        public const int ERROR_PROJECT_NOT_FOUND = 11002;
        public const int ERROR_BUCKET_NOT_FOUND = 11003;
        public const int ERROR_OBJECT_NOT_FOUND = 11004;
        public const int ERROR_QUOTA_EXCEEDED = 11005;
        public const int ERROR_NOT_AUTHENTICATED = 11006;
        public const int ERROR_NOT_PERMISSION = 11007;
        public const int ERROR_OPERATION_FREQUENT = 11008;
        public const int ERROR_INVALID_HASH_VERIFY = 11009;
        public const int ERROR_CANCELED = 11010;
        public const int ERROR_REQUEST_TIMEOUT = 11011;
        public const int ERROR_FILE_ACCESS = 11012;
        public const int ERROR_SERVER_RSP_INVALID = 11013;
        public const int ERROR_META_SHA_EMPTY = 11014;
        public const int ERROR_NETWORK_UNAVAILABLE = 11015;
        public const int ERROR_RANGE_UNSATISFIABLE = 11016;
        public StorageException (): base() { }
        public static StorageException fromErrorStatus(int arg0) {
            return CallStatic<StorageException>("fromErrorStatus", arg0);
        }
        public static StorageException fromException(Throwable arg0) {
            return CallStatic<StorageException>("fromException", arg0);
        }
        public static StorageException fromException(Throwable arg0, int arg1) {
            return CallStatic<StorageException>("fromException", arg0, arg1);
        }
        public int getErrorCode() {
            return Call<int>("getErrorCode");
        }
        public int getHttpCode() {
            return Call<int>("getHttpCode");
        }
        public Throwable getCause() {
            return Call<Throwable>("getCause");
        }
        public bool overRetryTimes() {
            return Call<bool>("overRetryTimes");
        }
    }
}