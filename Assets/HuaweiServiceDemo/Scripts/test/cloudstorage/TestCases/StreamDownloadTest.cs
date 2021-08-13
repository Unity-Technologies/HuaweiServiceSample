using HuaweiService;
using HuaweiService.CloudStorage;
using UnityEngine;

namespace CloudStorageTest
{
	public class StreamDownloadTest
	{
		
		private AGCStorageManagement mAGCStorageManagement;
		
		private string storageFileName= "MetadataLoader.cpp";

		private void initAGCStorageManagement()
		{
			mAGCStorageManagement = AGCStorageManagement.getInstance();
		}
		
		public void run()
		{
			streamDownloadTest();
			Debug.Log("StorageExceptionTest finished.");
		}
		
		private void streamDownloadTest()
		{
			initAGCStorageManagement();
			StorageReference reference = mAGCStorageManagement.getStorageReference(storageFileName);
			StreamDownloadTask streamTask = reference.getStream();
			if (streamTask == null)
			{
				Debug.Log("downloadStream is null");
			}

			MyStreamHandler myStreamHandler = new MyStreamHandler();
			StreamDownloadTask streamTaskWithHandler = reference.getStream(myStreamHandler);
			if (streamTaskWithHandler == null)
			{
				Debug.Log("streamTaskWithHandler is null");
			}

			Debug.Log("streamDownloadTest success");
		}
	}
	
	public class MyStreamHandler : StreamDownloadTask.StreamHandler{
		public override void readStream(StreamDownloadTask.StreamDownloadResult var1, InputStream var2)
		{
			InputStream ins = var1.getStream();
			if (ins == null)
			{
				Debug.Log("streamDownloadTest getStream fail, ins is null");
			}
			
			long count = var1.getTotalByteCount();
			long transferred = var1.getBytesTransferred();
			
			Debug.Log("MyStreamHandler, totalCount: " + count + "transferred: " + transferred);
		}
	}
}
