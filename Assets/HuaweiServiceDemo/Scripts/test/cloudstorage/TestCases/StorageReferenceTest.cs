using HuaweiService;
using HuaweiService.CloudStorage;
using UnityEngine;

namespace CloudStorageTest
{
    public class StorageReferenceTest
    {
        private AGCStorageManagement mAGCStorageManagement;

        public void run()
        {
            storageReferenceTest();
            Debug.Log("storageReferenceTest finished.");
        }

        private void initAGCStorageManagement()
        {
            mAGCStorageManagement = AGCStorageManagement.getInstance();
        }


        private void storageReferenceTest()
        {
            initAGCStorageManagement();

            StorageReference reference = mAGCStorageManagement.getStorageReference("storageReferenceTest.data");
            AGCStorageManagement storage = reference.getStorage();
            if (storage == null)
            {
                Debug.Log("storageReferenceTest fail: storage is null");
                return;
            }

            StorageReference child = reference.child("/");
            if (child == null)
            {
                Debug.Log("storageReferenceTest fail: child is null");
                return;
            }

            StorageReference parent = reference.getParent();
            if (parent == null)
            {
                Debug.Log("storageReferenceTest fail: parent is null");
                return;
            }

            StorageReference root = reference.getRoot();
            if (root == null)
            {
                Debug.Log("storageReferenceTest fail: root is null");
                return;
            }

            Task updateTask = reference.updateFileMetadata(new FileMetadata());
            if (updateTask == null)
            {
                Debug.Log("storageReferenceTest fail: updateTask is null");
                return;
            }

            Task task = reference.getFileMetadata();
            if (task == null)
            {
                Debug.Log("storageReferenceTest fail: task is null");
                return;
            }

            Task listTask = reference.list(1);
            if (listTask == null)
            {
                Debug.Log("storageReferenceTest fail: listTask is null");
                return;
            }

            Task listTaskSec = reference.list(1, "1");
            if (listTaskSec == null)
            {
                Debug.Log("storageReferenceTest fail: listTaskSec is null");
                return;
            }

            Task listAll = reference.listAll();
            if (listAll == null)
            {
                Debug.Log("storageReferenceTest fail: listAll is null");
                return;
            }

            StreamDownloadTask stream = reference.getStream();
            if (stream == null)
            {
                Debug.Log("storageReferenceTest fail: stream is null");
                return;
            }

            StreamDownloadTask streamSecond = reference.getStream(new MyStreamHandler());
            if (streamSecond == null)
            {
                Debug.Log("storageReferenceTest fail: streamSecond is null");
                return;
            }

            Task getByteTask = reference.getBytes(10);
            if (getByteTask == null)
            {
                Debug.Log("storageReferenceTest fail: getByteTask is null");
                return;
            }

            Task downloadUrl = reference.getDownloadUrl();
            if (downloadUrl == null)
            {
                Debug.Log("storageReferenceTest fail: downloadUrl is null");
                return;
            }

            List activeUploadList = reference.getActiveUploadTasks();
            if (activeUploadList == null)
            {
                Debug.Log("storageReferenceTest fail: activeUploadList is null");
                return;
            }

            List activeDownloadList = reference.getActiveDownloadTasks();
            if (activeDownloadList == null)
            {
                Debug.Log("storageReferenceTest fail: activeDownloadList is null");
                return;
            }


            StorageReference ref_1 = mAGCStorageManagement.getStorageReference("putFileTest_1.data");
            UploadTask uploadFirst = ref_1.putFile(new File("empty_first"));
            Debug.Log("putFileTest_1 success");
            
            StorageReference ref_2 = mAGCStorageManagement.getStorageReference("putFileTest_2.data");
            UploadTask uploadSecond = ref_2.putFile(new File("empty_second"), new FileMetadata(), new Long(0));
            Debug.Log("putFileTest_2 success");
            
            StorageReference ref_3 = mAGCStorageManagement.getStorageReference("putFileTest_3.data");
            UploadTask uploadThird = ref_3.putFile(new File("empty_third"), new FileMetadata());
            Debug.Log("putFileTest_3 success");

            
            StorageReference ref_4 = mAGCStorageManagement.getStorageReference("putFileTest_4.data");
            FileMetadata metadata = new FileMetadata();
            metadata.setSHA256Hash("0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef");
            UploadTask byteFirst = ref_4.putBytes(new byte[100], metadata, new Long(0));
            Debug.Log("putFileTest_4 success");

            DownloadTask downloadFirst = reference.getFile(new File("download_first.data"));
            Debug.Log("download_first success");
            Uri myUri = Uri.parse("content://downloads/public_downloads");
            if (myUri == null)
            {
                Debug.Log("Uri parse fail");
            }
            else
            {
                Debug.Log("Uri parse success");
                DownloadTask downloadSecond = reference.getFile(myUri);
            }

            string bucket = reference.getBucket();
            string name = reference.getName();
            string path = reference.getPath();
            int compareTo = reference.compareTo(ref_3);
            string toString = reference.toString();

            Long myObject = new Long(10);
            bool equal = reference.equals(myObject.obj);
            int hashcode = reference.hashCode();

            Task deleteTask = reference.delete();
            if (deleteTask == null)
            {
                Debug.Log("storageReferenceTest fail: deleteTask is null");
                return;
            }

            Debug.Log("storageReferenceTest success. bucket: " + bucket +
                      ", name: " + name +
                      ", path: " + path +
                      ", compareTo: " + compareTo +
                      ", toString: " + toString +
                      ", equal: " + equal +
                      ", hashcode: " + hashcode);
        }

        public class MyStreamHandler : StreamDownloadTask.StreamHandler
        {
            public void readStream(StreamDownloadTask.StreamDownloadResult var1, InputStream var2)
            {
                Debug.Log("readStream");
            }
        }
    }
}