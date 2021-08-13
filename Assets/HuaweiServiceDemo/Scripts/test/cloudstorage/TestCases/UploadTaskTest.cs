using System.Threading;
using HuaweiService;
using HuaweiService.CloudStorage;
using UnityEngine;

namespace CloudStorageTest
{
    public class UploadTaskTest
    {
        private AGCStorageManagement mAGCStorageManagement;

        public UploadTaskTest()
        {
            initAGCStorageManagement();
        }

        private void initAGCStorageManagement()
        {
            mAGCStorageManagement = AGCStorageManagement.getInstance();
        }

        public void addOnCanceledListenerTest()
        {
            Debug.Log("UploadTask addOnCanceledListenerTest");

            byte[] data = new byte[100000];
            string filename = "addOnCanceledListenerTest.data";

            StorageReference storageReference = mAGCStorageManagement.getStorageReference(filename);
            UploadTask task = storageReference.putBytes(data, new FileMetadata());


            Debug.Log("add addOnCanceledListener");
            //task.addOnCanceledListener(new MyOnCanceledListener("MyOnCanceledListener"));

            MyOnCanceledListener actitvity_listener = new MyOnCanceledListener("ActivityListener");
            task.addOnCanceledListener(new Activity(), actitvity_listener);

            MyOnCanceledListener executor_listener = new MyOnCanceledListener("ExecutorListener");
            task.addOnCanceledListener(new MyExecutor("ExecutorListener"), executor_listener);

            MyOnCanceledListener listener = new MyOnCanceledListener("NormalListener");
            task.addOnCanceledListener(listener);

            Debug.Log("remove addOnCanceledListener");
            MyOnCanceledListener remove = new MyOnCanceledListener("remove");
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
            Debug.Log("UploadTask addOnCompleteListenerTest");


            byte[] data = new byte[10];
            string filename = "addOnCompleteListenerTest.data";

            StorageReference storageReference = mAGCStorageManagement.getStorageReference(filename);
            UploadTask task = storageReference.putBytes(data, new FileMetadata());

            task.addOnCompleteListener(new MyOnCompleteListener("NormalListener"))
                .addOnCompleteListener(new Activity(), new MyOnCompleteListener("ActivityListener"))
                .addOnCompleteListener(new MyExecutor("ExecutorListener"),
                    new MyOnCompleteListener("ExecutorListener"));

            MyOnCompleteListener remove = new MyOnCompleteListener("remove");
            task.addOnCompleteListener(remove);
            task.removeOnCompleteListener(remove);

            Debug.Log("task.isComplete status: " + task.isComplete());

            Debug.Log("UploadTask addOnCompleteListenerTest success");
        }

        public void addOnFailureListenerTest()
        {
            Debug.Log("UploadTask addOnFailureListenerTest");


            byte[] data = new byte[100000];
            string filename = "addOnFailureListenerTest.data";

            StorageReference storageReference = mAGCStorageManagement.getStorageReference(filename);
            UploadTask task = storageReference.putBytes(data, new FileMetadata());

            task.addOnFailureListener(new MyFailureListener("NormalListener"))
                .addOnFailureListener(new Activity(), new MyFailureListener("ActivityListener"))
                .addOnFailureListener(new MyExecutor("ExecutorListener"), new MyFailureListener("ExecutorListener"));

            MyFailureListener remove = new MyFailureListener("remove");
            task.addOnFailureListener(remove);
            task.removeOnFailureListener(remove);

            Debug.Log("UploadTask addOnFailureListenerTest success");
        }

        public void addOnSuccessListenerTest()
        {
            Debug.Log("UploadTask addOnSuccessListenerTest");

            byte[] data = new byte[10];
            string filename = "addOnSuccessListenerTest.data";

            StorageReference storageReference = mAGCStorageManagement.getStorageReference(filename);
            UploadTask task = storageReference.putBytes(data, new FileMetadata());

            task.addOnSuccessListener(new MySuccessListener("NormalListener"))
                .addOnSuccessListener(new Activity(), new MySuccessListener("ActivityListener"))
                .addOnSuccessListener(new MyExecutor("ExecutorListener"), new MySuccessListener("ExecutorListener"));

            MySuccessListener remove = new MySuccessListener("remove");
            task.addOnSuccessListener(remove);
            task.removeOnSuccessListener(remove);

            Debug.Log("task.isSuccessful status: " + task.isSuccessful());

            Debug.Log("UploadTask addOnSuccessListenerTest success");
        }

        public void addOnPausedListenerTest()
        {
            Debug.Log("UploadTask addOnPausedListenerTest");


            byte[] data = new byte[100];
            string filename = "addOnPausedListenerTest.data";

            StorageReference storageReference = mAGCStorageManagement.getStorageReference(filename);
            UploadTask task = storageReference.putBytes(data, new FileMetadata());

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

            task.onPaused();
            Debug.Log("task.onPaused status: " + task.isPaused());
            Thread.Sleep(2000);
            task.resume();

            Debug.Log("UploadTask addOnPausedListenerTest success");
        }

        public void addOnProgressListenerTest()
        {
            Debug.Log("UploadTask addOnProgressListenerTest");

            byte[] data = new byte[100];
            string filename = "addOnProgressListenerTest.data";

            StorageReference storageReference = mAGCStorageManagement.getStorageReference(filename);
            UploadTask task = storageReference.putBytes(data, new FileMetadata());

            task.addOnProgressListener(new MyProgressListener("1"))
                .addOnProgressListener(new Activity(), new MyProgressListener("2"))
                .addOnProgressListener(new MyExecutor("addOnProgressListenerTest"), new MyProgressListener("3"));

            MyProgressListener remove = new MyProgressListener("remove");
            task.addOnProgressListener(remove);
            task.removeOnProgressListener(remove);

            bool isInProgress = task.isInProgress();
            Debug.Log("UploadTask addOnProgressListenerTest success, is InProgress status: " + isInProgress);
        }

        public void uploadFile(string filename, int size)
        {
            Debug.Log("upload file start.");

            byte[] data = new byte[size];

            StorageReference storageReference = mAGCStorageManagement.getStorageReference(filename);

            UploadTask task = storageReference.putBytes(data, new FileMetadata());

            task.addOnFailureListener(new MyFailureListener())
                .addOnSuccessListener(new MySuccessListener())
                .addOnProgressListener(new MyProgressListener())
                .addOnPausedListener(new MyPausedListener());

            StorageTask.ErrorResult err = new MyErrorResult();
            Exception e = err.getError();

            task.setResult(err.obj);
            err = task.getResult();
            if (err == null)
            {
                Debug.Log("uploadFileTest fail, getResult err is null.");
                return;
            }

            StorageTask.ErrorResult timePointState = task.getTimePointState();
            if (timePointState == null)
            {
                Debug.Log("uploadFileTest fail, getTimePointState result is null.");
                return;
            }

            Exception exp = task.getException();
            if (exp == null)
            {
                Debug.Log("uploadFileTest fail, getException result is null.");
                return;
            }

            task.setException(exp);

            AndroidJavaObject ajObj = task.getResultThrowException(new AndroidJavaClass("java.lang.Exception"));
            if (ajObj == null)
            {
                Debug.Log("uploadFileTest fail, getException result is null.");
                return;
            }


            Debug.Log("upload file test success.");
        }

        public void continueWithTest()
        {
            byte[] data = new byte[100];
            string filename = "continueWithTest.data";

            StorageReference storageReference = mAGCStorageManagement.getStorageReference(filename);
            UploadTask task = storageReference.putBytes(data, new FileMetadata());

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

        public void timePointStateBaseTest()
        {
            byte[] data = new byte[100];
            string filename = "timePointStateBaseTest.data";

            StorageReference storageReference = mAGCStorageManagement.getStorageReference(filename);
            UploadTask task = storageReference.putBytes(data, new FileMetadata());
            StorageTask.ErrorResult err = task.getTimePointState();
            StorageTask.TimePointStateBase timePoint = HmsUtil.GetHmsBase<StorageTask.TimePointStateBase>(err.obj);
            Exception e = timePoint.getError();
            if (e == null)
            {
                Debug.Log("timePointStateBaseTest fail, error result is null");
                return;
            }

            StorageReference timeRef = timePoint.getStorage();
            if (timeRef == null)
            {
                Debug.Log("timePointStateBaseTest fail, timeRef is null");
                return;
            }

            StorageTask storageTask = timePoint.getTask();
            if (storageTask == null)
            {
                Debug.Log("timePointStateBaseTest fail, storageTask is null");
                return;
            }

            Debug.Log("timePointStateBaseTest success");
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
            Debug.Log("upload fail: " + m_name);
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
            Debug.Log("upload success: " + m_name);
        }
    }

    public class MyProgressListener : OnProgressListener
    {
        private string m_name;

        public MyProgressListener(string name)
        {
            m_name = name;
        }

        public MyProgressListener()
        {
            m_name = "default";
        }

        public override void onProgress(AndroidJavaObject arg0)
        {
            UploadTask.UploadResult uploadResult = HmsUtil.GetHmsBase<UploadTask.UploadResult>(arg0);
            FileMetadata metadata = uploadResult.getMetadata();
            if (metadata == null)
            {
                Debug.LogFormat("MyProgressListener:onProgress, get metadata failed!");
            }

            Debug.LogFormat(m_name + " progress : {0}",
                (uploadResult.getBytesTransferred() * 1.0) / uploadResult.getTotalByteCount());
        }
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
            Debug.Log("upload pause: " + m_name);
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
            Debug.Log("upload canceled: " + m_name);
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
            Debug.Log("upload OnComplete: " + m_name);
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
}