using HuaweiService;
using HuaweiService.CloudStorage;
using UnityEngine;

namespace CloudStorageTest
{
    public class AGCStorageManagementTest
    {
        private AGCStorageManagement mAGCStorageManagement;

        public void run()
        {
            getInstanceTest();
            getStorageReferenceTest();
            timeOutTest();
            retryTimesTest();
            Debug.Log("AGCStorageManagementTest finished!");
        }

        public void getInstanceTest()
        {
            string result = "success";
            mAGCStorageManagement = AGCStorageManagement.getInstance();
            if (mAGCStorageManagement == null)
            {
                Debug.Log("AGCStorageManagement.getInstance() is null");
                result = "fail";
            }

            mAGCStorageManagement = AGCStorageManagement.getInstance("https://ops-dre.agcstorage.link");
            if (mAGCStorageManagement == null)
            {
                Debug.Log("AGCStorageManagement.getInstance(string arg0) is null");
                result = "fail";
            }

            MyConnnectionFactroty httpFac = new MyConnnectionFactroty();
            mAGCStorageManagement = AGCStorageManagement.getInstance(httpFac);
            if (mAGCStorageManagement == null)
            {
                Debug.Log("AGCStorageManagement.getInstance(HttpURLConnectionFactory arg0) is null");
                result = "fail";
            }

            mAGCStorageManagement = AGCStorageManagement.getInstance("https://ops-dre.agcstorage.link", httpFac);
            if (mAGCStorageManagement == null)
            {
                Debug.Log("AGCStorageManagement.getInstance(string arg0, HttpURLConnectionFactory arg1) is null");
                result = "fail";
            }

            Debug.Log("AGCStorageManagementTest getInstanceTest " + result);
        }

        public void getStorageReferenceTest()
        {
            string result = "success";

            mAGCStorageManagement = AGCStorageManagement.getInstance();
            StorageReference sr = mAGCStorageManagement.getStorageReference();
            if (sr == null)
            {
                Debug.Log("mAGCStorageManagement.getStorageReference is null.");
                result = "fail";
            }

            sr = mAGCStorageManagement.getStorageReference("addOnSuccessListenerTest.data");
            if (sr == null)
            {
                Debug.Log("mAGCStorageManagement.getStorageReference with argument is null.");
                result = "fail";
            }

            sr = mAGCStorageManagement.getReferenceFromUrl(
                "https://ops-dre.agcstorage.link/v0/unity-cloud-test-6ujit/addOnCompleteListenerTest.data?token=62ae812b-1128-47cb-b4fd-54e5a94a8286");
            if (sr == null)
            {
                Debug.Log("mAGCStorageManagement.getReferenceFromUrl is null.");
                result = "fail";
            }

            Debug.Log("AGCStorageManagementTest getStorageReferenceTest " + result);
        }

        public void timeOutTest()
        {
            string result = "success";

            mAGCStorageManagement = AGCStorageManagement.getInstance();

            mAGCStorageManagement.setMaxDownloadTimeout(11);
            mAGCStorageManagement.setMaxRequestTimeout(2);
            mAGCStorageManagement.setMaxUploadTimeout(3);

            long maxUploadTime = mAGCStorageManagement.getMaxUploadTimeout();
            long maxDownloadTimeout = mAGCStorageManagement.getMaxDownloadTimeout();
            long maxRequestTimeout = mAGCStorageManagement.getMaxRequestTimeout();

            Debug.Log("AGCStorageManagementTest getStorageReferenceTest " + result +
                      ", maxUploadTime: " + maxUploadTime +
                      ", maxDownloadTimeout: " + maxDownloadTimeout +
                      ", maxRequestTimeout: " + maxRequestTimeout);

            Debug.Log("AGCStorageManagementTest getStorageReferenceTest " + result);
        }

        public void retryTimesTest()
        {
            string result = "success";

            mAGCStorageManagement = AGCStorageManagement.getInstance();

            mAGCStorageManagement.setRetryTimes(4);
            int retryTimes = mAGCStorageManagement.getRetryTimes();

            Debug.Log("AGCStorageManagementTest retryTimesTest " + result + ", retryTimes: " + retryTimes);
        }

        public class MyConnnectionFactroty : HttpURLConnectionFactory
        {
            public override HttpURLConnection createConnection(URL arg0)
            {
                URL url = new URL("https://developer.huawei.com");
                URLConnection rulConnection = url.openConnection();
                HttpURLConnection httpUrlConnection = rulConnection.toType<HttpURLConnection>();

                return httpUrlConnection;
            }
        }
    }
}