using HuaweiService;
using HuaweiService.CloudStorage;
using UnityEngine;

namespace CloudStorageTest
{
    public class FileMetadataTest
    {
        public void run()
        {
            fileMetadataTest();
            Debug.Log("FileMetadataTest finished.");
        }


        private void fileMetadataTest()
        {
            FileMetadata metadata = new FileMetadata();

            metadata.setSHA256Hash("random hash");
            string myhash = metadata.getSHA256Hash();
            TestLog("SHA256HashTest", "random hash", myhash);

            metadata.setContentType("my type");
            string contentType = metadata.getContentType();
            TestLog("ContentTypeTest", "my type", contentType);

            metadata.setCacheControl("my cache control");
            string cache = metadata.getCacheControl();
            TestLog("CacheControlTest", "my cache control", cache);

            metadata.setContentDisposition("my disposition");
            string disposition = metadata.getContentDisposition();
            TestLog("ContentDispositionTest", "my disposition", disposition);

            metadata.setContentEncoding("my encoding");
            string encoding = metadata.getContentEncoding();
            TestLog("ContentEncodingTest", "my encoding", encoding);

            metadata.setContentLanguage("my language");
            string language = metadata.getContentLanguage();
            TestLog("ContentEncodingTest", "my language", language);

            HashMap hashMap = new HashMap();
            metadata.setCustomMetadata(hashMap.toType<Map>());
            Map myData = metadata.getCustomMetadata();
            if (myData == null)
            {
                Debug.Log("getCustomMetadata fail, myData is null");
                return;
            }

            TestLog("myData", "myData", language);

            var refer = metadata.getStorageReference();
            if (refer == null)
            {
                Debug.Log("getStorageReferenceTest fail.");
                return;
            }

            string bucket = metadata.getBucket();
            string ctime = metadata.getCTime();
            string mtime = metadata.getMTime();
            string name = metadata.getName();
            string path = metadata.getPath();
            Long size = metadata.getSize();
            Debug.Log("fileMetadataTest success. " +
                      "bucket: " + bucket +
                      "ctime: " + ctime +
                      "mtime: " + mtime +
                      "name: " + name +
                      "path: " + path +
                      "size: " + size);
        }

        private void TestLog(string caseName, string targetValue, string actualValue)
        {
            if (targetValue != actualValue)
            {
                Debug.Log(caseName + "fail. " + "target: " + targetValue + ", actual: " + actualValue);
            }
            else
            {
                Debug.Log(caseName + "success. " + "target: " + targetValue + ", actual: " + actualValue);
            }
        }
    }
}