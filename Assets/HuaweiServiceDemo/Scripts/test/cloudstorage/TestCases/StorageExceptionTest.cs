using HuaweiService;
using HuaweiService.CloudStorage;
using UnityEngine;

namespace CloudStorageTest
{
    public class StorageExceptionTest
    {
        public void run()
        {
            storageExceptionTest();
            Debug.Log("StorageExceptionTest finished.");
        }

        private void storageExceptionTest()
        {
            StorageException storageException = StorageException.fromErrorStatus(11009);
            StorageException fromException = StorageException.fromException(storageException.toType<Throwable>());
            StorageException fromException2 = StorageException.fromException(storageException.toType<Throwable>(), 0);

            int errorCode = storageException.getErrorCode();
            int httpCode = storageException.getHttpCode();
            Throwable cause = storageException.getCause();

            bool retry = storageException.overRetryTimes();

            Debug.Log("storageExceptionTest success. errorCode: " + errorCode +
                      ", httpCode: " + httpCode +
                      ",retry: " + retry +
                      "cause: " + cause);
        }
    }
}