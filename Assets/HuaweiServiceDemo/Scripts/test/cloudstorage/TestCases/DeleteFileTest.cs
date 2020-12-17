using HuaweiService.CloudStorage;
using UnityEngine;

namespace CloudStorageTest
{
    public class DeleteFileTest
    {
        private AGCStorageManagement mAGCStorageManagement;

        private void initAGCStorageManagement()
        {
            mAGCStorageManagement = AGCStorageManagement.getInstance();
        }

        public void run()
        {
            deleteFileTest();
            Debug.Log("DeleteFileTest finished.");
        }

        private void deleteFileTest()
        {
            initAGCStorageManagement();
            StorageReference reference = mAGCStorageManagement.getStorageReference("addOnCompleteListenerTest.data");
            reference.delete();
            Debug.Log("DeleteFileTest success.");
        }
    }
}