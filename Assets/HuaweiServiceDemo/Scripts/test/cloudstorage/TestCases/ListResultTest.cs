using HuaweiService;
using HuaweiService.CloudStorage;
using UnityEngine;

namespace CloudStorageTest
{
    public class ListResultTest
    {
        private AGCStorageManagement mAGCStorageManagement;

        private void initAGCStorageManagement()
        {
            mAGCStorageManagement = AGCStorageManagement.getInstance();
        }

        public void run()
        {
            listResultTest();
            Debug.Log("FileMetadataTest finished.");
        }

        private void listResultTest()
        {
            initAGCStorageManagement();
            StorageReference reference = mAGCStorageManagement.getStorageReference();

            Task listTask = reference.listAll();
            ListResult listResult = HmsUtil.GetHmsBase<ListResult>(Tasks.await(listTask));

            List fileList = listResult.getFileList();
            if (fileList == null)
            {
                Debug.Log("listResultTest fail: fileList is null");
                return;
            }

            List dirList = listResult.getDirList();
            if (dirList == null)
            {
                Debug.Log("listResultTest fail: dirList is null");
                return;
            }

            string pageMaker = listResult.getPageMarker();
            Debug.Log("listResultTest success. pageMaker: " + pageMaker);
        }
    }
}