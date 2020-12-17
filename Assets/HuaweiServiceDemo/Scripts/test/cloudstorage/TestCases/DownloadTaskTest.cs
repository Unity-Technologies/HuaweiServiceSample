using System.Threading;
using HuaweiService;
using HuaweiService.CloudStorage;
using UnityEngine;


namespace CloudStorageTest
{
    public class DownloadTaskTest
    {
        private AGCStorageManagement mAGCStorageManagement;

        public DownloadTaskTest()
        {
            initAGCStorageManagement();
        }

        public void run()
        {
            downloadTest();

            Debug.Log("DownloadTaskTest finished.");
        }

        private void initAGCStorageManagement()
        {
            mAGCStorageManagement = AGCStorageManagement.getInstance();
        }

        private string storageFileName = "MetadataLoader.cpp";
        private string downloadFileFolder = "/sdcard/";

        private void downloadTest()
        {
            Debug.Log("downloadTest start");
            StorageReference reference = mAGCStorageManagement.getStorageReference(storageFileName);
            Debug.Log("getStorageReference end");
            string downloadFilePath = downloadFileFolder + "downloadTest.cpp";

            Debug.Log("downloadFilePath: " + downloadFilePath);
            File file = new File(downloadFilePath);

            try
            {
                DownloadTask task = reference.getFile(file);
                if (task == null)
                {
                    Debug.Log("downloadTask is null");
                }
                else
                {
                    Debug.Log("downloadTask is not null");
                    StorageTask.ErrorResult err = new MyErrorResult();
                    Exception e = err.getError();

                    task.setResult(err.obj);
                    err = task.getResult();
                    if (err == null)
                    {
                        Debug.Log("downloadFileTest fail, getResult err is null.");
                        return;
                    }

                    StorageTask.ErrorResult timePointState = task.getTimePointState();
                    if (timePointState == null)
                    {
                        Debug.Log("downloadFileTest fail, getTimePointState result is null.");
                        return;
                    }

                    Exception exp = task.getException();
                    if (exp == null)
                    {
                        Debug.Log("downloadFileTest fail, getException result is null.");
                        return;
                    }

                    task.setException(exp);

                    AndroidJavaObject ajObj = task.getResultThrowException(new AndroidJavaClass("java.lang.Exception"));
                    if (ajObj == null)
                    {
                        Debug.Log("downloadFileTest fail, getException result is null.");
                        return;
                    }

                    Debug.Log("downloadTest Success");
                }
            }
            catch (System.Exception e)
            {
                Debug.Log(e);
            }
        }

        public void addOnCanceledListenerTest()
        {
            Debug.Log("DownloadTask addOnCanceledListenerTest");

            StorageReference reference = mAGCStorageManagement.getStorageReference(storageFileName);
            string downloadFilePath = downloadFileFolder + "addOnCanceledListenerTest.cpp";
            File file = new File(downloadFilePath);
            DownloadTask task = reference.getFile(file);


            Debug.Log("add addOnCanceledListener");
            //task.addOnCanceledListener(new MyOnCanceledListener("MyOnCanceledListener"));

            MyOnCanceledListener actitvity_listener = new MyOnCanceledListener("ActivityListener");
            task.addOnCanceledListener(new Activity(), actitvity_listener);

            MyOnCanceledListener executor_listener = new MyOnCanceledListener("ExecutorListener");
            task.addOnCanceledListener(new MyExecutor("ExecutorListener"), executor_listener);

            MyOnCanceledListener listener = new MyOnCanceledListener("NormalListener");
            task.addOnCanceledListener(listener);

            Debug.Log("remove addOnCanceledListener");
            MyOnCanceledListener remove = new MyOnCanceledListener("remoremoveve");
            task.addOnCanceledListener(new Activity(), remove);
            task.removeOnCanceledListener(remove);

            // UnityEngine.Debug.Log("cancel");
            Debug.Log("task.isCanceled status: " + task.isCanceled());
            if (!task.isCanceled())
            {
                task.pause();
                task.cancel();
            }

            Debug.Log("after cancel: task.isCanceled status: " + task.isCanceled());

            Debug.Log("UploadTask addOnCanceledListenerTest success");
        }

        public void addOnCompleteListenerTest()
        {
            Debug.Log("DownloadTask addOnCompleteListenerTest");

            StorageReference reference = mAGCStorageManagement.getStorageReference(storageFileName);
            string downloadFilePath = downloadFileFolder + "addOnCompleteListenerTest.cpp";
            File file = new File(downloadFilePath);
            DownloadTask task = reference.getFile(file);

            task.addOnCompleteListener(new MyOnCompleteListener("NormalListener"))
                .addOnCompleteListener(new Activity(), new MyOnCompleteListener("ActivityListener"))
                .addOnCompleteListener(new MyExecutor("ExecutorListener"),
                    new MyOnCompleteListener("ExecutorListener"));

            MyOnCompleteListener remove = new MyOnCompleteListener("remove");
            task.addOnCompleteListener(remove);
            task.removeOnCompleteListener(remove);

            Debug.Log("task.isComplete status: " + task.isComplete());

            Debug.Log("DownloadTask addOnCompleteListenerTest success");
        }

        public void addOnFailureListenerTest()
        {
            Debug.Log("DownloadTask addOnFailureListenerTest");

            StorageReference reference = mAGCStorageManagement.getStorageReference(storageFileName);
            string downloadFilePath = downloadFileFolder + "addOnFailureListenerTest.cpp";
            File file = new File(downloadFilePath);
            DownloadTask task = reference.getFile(file);

            task.addOnFailureListener(new MyFailureListener("NormalListener"))
                .addOnFailureListener(new Activity(), new MyFailureListener("ActivityListener"))
                .addOnFailureListener(new MyExecutor("ExecutorListener"), new MyFailureListener("ExecutorListener"));

            MyFailureListener remove = new MyFailureListener("remove");
            task.addOnFailureListener(remove);
            task.removeOnFailureListener(remove);

            Debug.Log("DownloadTask addOnFailureListenerTest success");
        }

        public void addOnSuccessListenerTest()
        {
            Debug.Log("DownloadTask addOnSuccessListenerTest");

            StorageReference reference = mAGCStorageManagement.getStorageReference(storageFileName);
            string downloadFilePath = downloadFileFolder + "addOnSuccessListenerTest.cpp";

            File file = new File(downloadFilePath);
            DownloadTask task = reference.getFile(file);

            task.addOnSuccessListener(new MySuccessListener("NormalListener"))
                .addOnSuccessListener(new Activity(), new MySuccessListener("ActivityListener"))
                .addOnSuccessListener(new MyExecutor("ExecutorListener"), new MySuccessListener("ExecutorListener"));

            MySuccessListener remove = new MySuccessListener("remove");
            task.addOnSuccessListener(remove);
            task.removeOnSuccessListener(remove);

            Debug.Log("task.isSuccessful status: " + task.isSuccessful());

            Debug.Log("DownloadTask addOnSuccessListenerTest success");
        }

        public void addOnPausedListenerTest()
        {
            Debug.Log("DownloadTask addOnPausedListenerTest");

            StorageReference reference = mAGCStorageManagement.getStorageReference(storageFileName);
            string downloadFilePath = downloadFileFolder + "addOnPausedListenerTest.cpp";
            File file = new File(downloadFilePath);
            DownloadTask task = reference.getFile(file);

            task.addOnPausedListener(new MyPausedListener("1"))
                .addOnPausedListener(new Activity(), new MyPausedListener("2"))
                .addOnPausedListener(new MyExecutor("ExecutorListener"), new MyPausedListener("3"));

            MyPausedListener remove = new MyPausedListener("remove");
            task.addOnPausedListener(remove);
            task.removeOnPausedListener(remove);

            task.pause();
            Debug.Log("task.isPaused status: " + task.isPaused());
            Thread.Sleep(2000);
            task.resume();

            Debug.Log("after task.resume status: " + task.isPaused());

            Debug.Log("DownloadTask addOnPausedListenerTest success");
        }

        public void addOnProgressListenerTest()
        {
            Debug.Log("DownloadTask addOnProgressListenerTest");

            StorageReference reference = mAGCStorageManagement.getStorageReference(storageFileName);
            string downloadFilePath = downloadFileFolder + "addOnProgressListenerTest.cpp";
            File file = new File(downloadFilePath);
            DownloadTask task = reference.getFile(file);

            task.addOnProgressListener(new MyDownloadProgressListener("1"))
                .addOnProgressListener(new Activity(), new MyDownloadProgressListener("2"))
                .addOnProgressListener(new MyExecutor("addOnProgressListenerTest"),
                    new MyDownloadProgressListener("3"));

            MyDownloadProgressListener remove = new MyDownloadProgressListener("remove");
            task.addOnProgressListener(remove);
            task.removeOnProgressListener(remove);

            bool isInProgress = task.isInProgress();
            Debug.Log("DownloadTask addOnProgressListenerTest success, is InProgress status: " + isInProgress);
        }

        public void continueWithTest()
        {
            StorageReference reference = mAGCStorageManagement.getStorageReference(storageFileName);
            string downloadFilePath = downloadFileFolder + "continueWithTest.cpp";
            File file = new File(downloadFilePath);
            DownloadTask task = reference.getFile(file);

            task.continueWith(new MyExecutor("continueWithTestExecutor"),
                new MyContinuation("MyExecutor&MyContinuation"));
            task.continueWith(new MyContinuation("MyContinuation"));
            task.continueWithTask(new MyContinuation("MyContinuation&Task"));
            task.continueWithTask(new MyExecuteResult("continueWithTestExecuteResult"));
            task.continueWithTask(new MyExecutor("continueWithTestExecutor&Task"),
                new MyContinuation("MyExecutor&MyContinuation&Task"));

            task.onSuccessTask(new MyExecutor("onSuccessTask"), new MySuccessContinuation("onSuccessTask"));
            task.onSuccessTask(new MySuccessContinuation("onSuccessTaskSingle"));

            Debug.Log("continueWithTest Success");
        }

        public class MyPausedListener : OnPausedListener
        {
            private string m_name;

            public MyPausedListener(string name)
            {
                m_name = name;
            }

            public MyPausedListener()
            {
                m_name = "default";
            }

            public override void onPaused(AndroidJavaObject arg0)
            {
                Debug.Log("download pause: " + m_name);
            }
        }

        public class MyOnCanceledListener : OnCanceledListener
        {
            private string m_name;

            public MyOnCanceledListener(string name)
            {
                m_name = name;
            }

            public override void onCanceled()
            {
                Debug.Log("download canceled: " + m_name);
            }
        }

        public class MyOnCompleteListener : OnCompleteListener
        {
            private string m_name;

            public MyOnCompleteListener(string name)
            {
                m_name = name;
            }

            public override void onComplete(Task arg0)
            {
                Debug.Log("download OnComplete: " + m_name);
            }
        }

        public class MyContinuation : Continuation
        {
            private string m_name;

            public MyContinuation(string name)
            {
                m_name = name;
            }

            public override AndroidJavaObject then(Task arg0)
            {
                Debug.Log("MyContinuation: " + m_name);
                return null;
            }
        }

        public class MyDownloadProgressListener : OnProgressListener
        {
            private string m_name;

            public MyDownloadProgressListener(string name)
            {
                m_name = name;
            }

            public MyDownloadProgressListener()
            {
                m_name = "default";
            }

            public override void onProgress(AndroidJavaObject arg0)
            {
                DownloadTask.DownloadResult downloadResult = HmsUtil.GetHmsBase<DownloadTask.DownloadResult>(arg0);
                Debug.LogFormat(m_name + " progress : {0}",
                    (downloadResult.getBytesTransferred() * 1.0) / downloadResult.getTotalByteCount());
            }
        }


        public class MyErrorResult : StorageTask.ErrorResult
        {
            public override Exception getError()
            {
                Debug.Log("MyErrorResult");
                return null;
            }
        }

        public class MySuccessContinuation : SuccessContinuation
        {
            private string m_name;

            public MySuccessContinuation(string name)
            {
                m_name = name;
            }

            public override Task then(AndroidJavaObject arg0)
            {
                Debug.Log(m_name);
                return null;
            }
        }

        public class MyExecutor : Executor
        {
            private string m_name;

            public MyExecutor(string name)
            {
                m_name = name;
            }

            public override void execute(Runnable arg0)
            {
                Debug.Log(m_name);
            }
        }

        public class MyExecuteResult : ExecuteResult
        {
            private string m_name;

            public MyExecuteResult(string name)
            {
                m_name = name;
            }

            public override void onComplete(Task arg0)
            {
                Debug.Log(m_name);
            }
        }

        public class MyFailureListener : OnFailureListener
        {
            private string m_name;

            public MyFailureListener(string name)
            {
                m_name = name;
            }

            public MyFailureListener()
            {
                m_name = "default";
            }

            public override void onFailure(Exception ex)
            {
                Debug.Log("download fail: " + m_name);
            }
        }

        public class MySuccessListener : OnSuccessListener
        {
            private string m_name;

            public MySuccessListener(string name)
            {
                m_name = name;
            }

            public MySuccessListener()
            {
                m_name = "default";
            }

            public override void onSuccess(AndroidJavaObject ex)
            {
                Debug.Log("download success: " + m_name);
            }
        }
    }
}