# HuaweiService.cloudstorage

### Scenario: AGCStorageManagement`初始化`
| Description | Api | Reference |
---|---|---
Initializes the default storage instance.<br>`初始化系统默认的存储实例` | AGCStorageManagement.getInstance(); | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/AGCStorageManagement
Initializes your own storage instance. <br> `初始化开发者自己创建的的存储实例。` | getInstance(String bucketName) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/AGCStorageManagement
Initializes the storage instance using the builder class for HttpURLConnection, which that you have overridden. <br> `使用重写的HttpURLConnection的创建类来初始化存储实例。` | getInstance(HttpURLConnectionFactory factory) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/AGCStorageManagement

### Scenario: AGCStorageManagement`创建引用`
| Description | Api | Reference |
---|---|---
Creates a reference to the root directory.<br> `创建根目录的引用。` | getStorageReference() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/AGCStorageManagement
Creates a reference to a file or directory with a specified file path address. <br> `创建指定文件路径地址的文件或目录的引用。` | getStorageReference(String objectPath) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/AGCStorageManagement
Creates a reference to a cloud file or directory with a specified file path. <br> `创建指定云端地址的文件或目录的引用。` | getReferenceFromUrl(String fullUrl) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/AGCStorageManagement

### Scenario: AGCStorageManagement`获取配置`
| Description | Api | Reference |
---|---|---
Obtains the maximum upload timeout interval. <br> `获取最大的上传超时时间。` | getMaxUploadTimeout() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/AGCStorageManagement
Obtains the maximum download timeout interval. <br> `获取最大的下载超时时间。` | getMaxDownloadTimeout() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/AGCStorageManagement
Obtains the maximum request timeout interval. <br> `获取最大的请求超时时间。` | getMaxRequestTimeout() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/AGCStorageManagement
Obtains the maximum number of retries. <br> `获取最大的重试次数。` | getRetryTimes() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/AGCStorageManagement
Sets the maximum upload timeout interval. <br> `设置最大的上传超时时间，值必须大于0， <br>单位：秒` | setMaxUploadTimeout(long maxUploadTimeout) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/AGCStorageManagement
Sets the maximum download timeout interval. <br> `设置最大的下载超时时间，值必须大于0，<br> 单位：秒。` | setMaxDownloadTimeout(long maxDownloadTimeout) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/AGCStorageManagement
Sets the maximum request timeout interval. <br> `设置最大的请求超时时间，值必须大于0，<br>单位：秒。` | setMaxRequestTimeout(long maxRequestTimeout) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/AGCStorageManagement
Sets the maximum number of retries. <br> `设置最大的重试次数。` | setRetryTimes(int retryTimes) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/AGCStorageManagement

### Scenario: StorageReference`云端文件的引用`
| Description | Api | Reference |
---|---|---
Obtains an AGCStorageManagement instance to which the reference belongs.<br>`获取引用所在AGCStorageManagement实例。` | getStorage() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageReference
Obtains the reference to a subdirectory. <br> `获取子目录的引用。` | child(String objectPath) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageReference
Obtains the reference to a directory.<br>`获取父目录的引用。` | getParent() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageReference
Obtains the reference to the root directory.<br>`获取根目录引用。` | getRoot() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageReference
Obtains the name of a storage instance to which the reference belongs. <br> `获取引用所在的存储实例名称。` | getBucket() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageReference
Obtains a file or directory name.<br> `获取文件名。` | getName() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageReference
Obtains the path of a file or directory on the cloud server. <br> `获取云端文件的路径。` | getPath() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageReference
Obtains metadata of a file or directory.<br> `获取文件或目录的元数据。` | getFileMetadata() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageReference
Updates file metadata in overwrite mode. <br> `更新文件元数据，采用覆盖更新的方式。` | updateFileMetadata(FileMetadata attribute) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageReference

### Scenario: StorageReference `删除文件` 
| Description | Api | Reference |
---|---|---
Deletes a file from the cloud server. <br> `删除云端文件。删除目录时，请先枚举并删除该目录下的所有文件，否则目录不会被删除。` | delete() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageReference

### Scenario: StorageReference`获取文件列表`
| Description | Api | Reference |
---|---|---
Obtains a file list under a directory in pagination mode.<br> `分页获取目录下的文件列表。` | list(int max, String marker) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageReference
Obtains the list of files with a specified number in a directory. <br> `获取目录下指定文件数量的文件列表。` | list(int max) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageReference
Obtains all objects in a directory, including files and subdirectories. <br> `获取目录下所有文件列表。` | listAll() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageReference

### Scenario: StorageReference`上传文件`
| Description | Api | Reference |
---|---|---
Saves a local file to the cloud server and continues to upload the remaining part of the file from the offset position. <br> `将本地文件存储到云端，从offset位置继续上传文件的剩下部分。` | putFile(File srcFile, FileMetadata attribute, Long offset) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageReference
Saves a local file to the cloud server. <br> `将本地文件存储到云端。` | putFile(File srcFile, FileMetadata attribute) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageReference
Saves a local file to the cloud server. <br> `将本地文件存储到云端。` | putFile(File srcFile) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageReference
Uploads a local file binary byte array to the cloud server. <br> `将本地的二进制字节数组上传到云端。` | putBytes(byte[] bytes, FileMetadata attribute) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageReference
Uploads a local binary byte array from the offset position to the cloud server. <br> `从offset位置开始将本地的二进制字节数组上传到云端。` | putBytes(byte[] bytes, FileMetadata attribute, Long offset) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageReference

### Scenario: StorageReference`下载文件`
| Description | Api | Reference |
---|---|---
Downloads a cloud file to a specified local file. <br> `下载一个云端文件到指定的本地文件（文件由App管理，当文件大小超过0字节时，该接口会将文件大小作为断点续传的偏移位置，继续从云端下载）` | getFile(File destFile) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageReference
Downloads a cloud file to a local file with a specified URI. <br> `下载一个云端文件到指定的Uri文件（文件由App管理，当文件大小超过0字节时，该接口会将文件大小作为断点续传的偏移位置，继续从云端下载）` | getFile(Uri destUri) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageReference
Returns a stream download task. <br> `返回一个流式的下载任务。` | getStream() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageReference
Returns a stream download task that implements a stream processing event. <br> `返回一个实现了数据流处理事件的流式下载任务` | getStream(StreamDownloadTask.StreamHandler streamHandler) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageReference
Downloads specified data from the cloud server to a binary byte array. <br> `从云端存储中下载指定的数据到二进制字节数组中` | getBytes(final long maxDownloadBytes) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageReference
Obtains the sharing URL of a cloud file. <br> `获取云端文件的分享地址` | getDownloadUrl() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageReference
Obtains the ongoing upload task list under the current reference. <br> `获取当前引用下处于运行状态的上传任务列表` | getActiveUploadTasks() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageReference
Obtains the ongoing download task list under the current reference. <br> `获取当前引用下处于运行状态的下载任务列表` | getActiveDownloadTasks() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageReference

### Scenario: StorageReference`文件操作` 
| Description | Api | Reference |
---|---|---
Compares reference addresses.<br> `比较引用地址。` | compareTo(StorageReference other) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageReference
Returns the reference URL. <br> `返回引用的Url地址。` | toString() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageReference
Compares references. <br>`比较引用是否相同。` | equals(Object other) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageReference
Obtains the hashcode of a reference. <br> `返回引用的hashcode值。` | hashCode() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageReference

### Scenario: FileMetadata`配置文件云数据`
| Description | Api | Reference |
---|---|---
Sets the SHA-256 value for file upload verification.<br> `设置上传文件的sha256（上传文件校验使用，更新元数据时该参数无意义）` | setSHA256Hash(String sha256) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/FileMetadata
Sets ContentType for the standard HTTP header.<br>`设置标准HTTP头部的ContentType类型。` | setContentType(String contentType) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/FileMetadata
Sets CacheControl for the standard HTTP header. <br> `设置标准HTTP头部的CacheControl设置。` | setCacheControl(String cacheControl) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/FileMetadata
Sets ContentDisposition for the standard HTTP header. <br> `设置标准HTTP头部的ContentDisposition设置。` | setContentDisposition(String contentDisposition) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/FileMetadata
Sets ContentEncoding for the standard HTTP header. <br> `设置标准HTTP头部的ContentEncoding设置。` | setContentEncoding(String contentEncoding) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/FileMetadata
Sets ContentLanguage for the standard HTTP header. <br> `设置标准HTTP头部的ContentLanguage设置。` | setContentLanguage(String contentLanguage) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/FileMetadata
Sets custom cloud file attributes. <br> ` 设置自定义的云端文件属性，不区分大小写，并且需要符合标准HTTP头部的规范。` | setCustomMetadata(Map<String, String> metadata) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/FileMetadata
Obtains a reference to a file or directory. <br> `返回文件或目录的引用。` | getStorageReference() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/FileMetadata

### Scenario: FileMetadata`文件的元数据操作`
| Description | Api | Reference |
---|---|---
Obtains the name of a storage instance. <br> `获取存储实例名。` | getBucket() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/FileMetadata
Obtains a file creation time. <br> `获取文件创建时间。` | getCTime() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/FileMetadata
Obtains the modification time of a file. <br> `获取文件修改时间。` | getMTime() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/FileMetadata
Obtains the name of a file on the cloud server. <br> `获取云端文件名。` | getName() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/FileMetadata
Obtains the path of a file on the cloud server. <br> `获取云端文件路径。` | getPath() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/FileMetadata
Obtains the size of a file on the cloud server. <br> `获取云端文件大小。` | getSize() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/FileMetadata
Obtains the SHA-256 value set during file upload. <br> `获取上传文件时设置的sha256。` | getSHA256Hash() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/FileMetadata
Obtains the type of a file on the cloud server. <br> `获取云端文件类型。` | getContentType() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/FileMetadata
Obtains the CacheControl setting of a user. <br> `获取用户设置的CacheControl设置。` | getCacheControl() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/FileMetadata
Obtains the ContentDisposition setting of a user. <br> `获取用户设置的ContentDisposition设置。` | getContentDisposition() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/FileMetadata
Obtains the ContentEncoding setting of a user. <br> `获取用户设置的ContentEncoding设置。` | getContentEncoding() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/FileMetadata
Obtains the ContentLanguage setting of a user. <br> `获取用户设置的ContentLanguage设置。` | getContentLanguage() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/FileMetadata
Obtains custom cloud file attributes. <br> `获取自定义的云端文件属性。` | getCustomMetadata() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/FileMetadata

### Scenario: StorageTask`注册任务`
| Description | Api | Reference |
---|---|---
Registers a listener for task cancellation. <br> `注册任务取消的监听器。` | addOnCanceledListener(OnCanceledListener listener) <br> addOnCanceledListener(Executor executor, OnCanceledListener listener) <br> addOnCanceledListener(Activity activity, OnCanceledListener listener) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageTask
Registers a listener for task completion. <br> `注册任务完成的监听器。` | addOnCompleteListener(OnCompleteListener<TResult> listener) <br> addOnCompleteListener(Executor executor, <br> OnCompleteListener<TResult> listener) <br> addOnCompleteListener(Activity activity, <br> OnCompleteListener<TResult> listener) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageTask
Registers a listener for task failure. <br> `注册任务失败的监听器。` | addOnFailureListener(OnFailureListener listener) <br> addOnFailureListener(Executor executor, OnFailureListener listener) <br> addOnFailureListener(Activity activity, OnFailureListener listener) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageTask
Registers a listener for task success. <br> `注册任务成功的监听器。` | addOnSuccessListener(OnSuccessListener<TResult> listener) <br> addOnSuccessListener(Executor executor, <br> OnSuccessListener<TResult> listener) <br> addOnSuccessListener(Activity activity, <br> OnSuccessListener<TResult> listener) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageTask
Registers a listener for task suspension. <br> `注册任务暂停的监听器。` | addOnPausedListener(OnPausedListener<TResult> listener) <br> addOnPausedListener(Executor executor, OnPausedListener<TResult> listener) <br> addOnPausedListener(Activity activity, OnPausedListener<TResult> listener) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageTask
Registers a listener for task execution. <br> `注册任务执行中的监听器。` | addOnProgressListener(OnProgressListener<TResult> listener) <br> addOnProgressListener(Executor executor, <br> OnProgressListener<TResult> listener) <br> addOnProgressListener(Activity activity, <br> OnProgressListener<TResult> listener) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageTask

### Scenario: StorageTask`任务处理`
| Description | Api | Reference |
---|---|---
Continues to execute the current task. <br> `继续执行任务。` | continueWithTask(ExecuteResult<TResult> executeResult) <br> continueWith(Continuation<TResult, TContinuationResult> <br> continuation) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageTask
Continues to execute the task. <br> `当前任务成功完成后，执行下一个任务。` | continueWith(Executor executor, Continuation<TResult, TContinuationResult> continuation) <br> continueWithTask(Executor executor, Continuation<TResult, Task<TContinuationResult>> continuation)
onSuccessTask(SuccessContinuation<TResult, TContinuation> continuation) <br> onSuccessTask(Executor executor, SuccessContinuation<TResult, TContinuation> continuation) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageTask
Cancels a task.`取消任务。` <br> Suspends a task.`暂停任务。` <br> Resumes a task.`继续任务。` | cancel() <br> pause() <br> resume() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageTask
Determines whether a task is canceled. `任务是否已取消。`<br>
Determines whether a task is complete.`任务是否已完成。`<br>
Determines whether a task is successful.`任务是否已成功。`<br>
Determines whether a task is being executed.`任务是否正在执行中。`<br>
Determines whether a task is suspended.`任务是否已暂停。`<br> | isCanceled() <br> isComplete() <br> isSuccessful() <br> isInProgress() <br> isPaused()| https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageTask
Obtains result information.`获取结果信息。`<br> Sets result information.`设置结果信息。` <br> Obtains the task result. `返回任务结果。` | getResult() <br> setResult(TResult result) <br> getTimePointState() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageTask
Obtains exception information. `获取异常信息。` <br> Sets exception information.`设置异常信息` <br> Obtains the result when an exception occurs. `获取结果时抛出的异常。` | getException() <br> setException(Exception exception) <br> getResultThrowException(Class<E> exceptionClass) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageTask
Removes the listener. `移除任务监听器` | removeOnCanceledListener(OnCanceledListener listener) <br> removeOnCompleteListener(OnCompleteListener<TResult> listener) <br> removeOnFailureListener(OnFailureListener listener) <br> removeOnSuccessListener(OnSuccessListener<TResult> listener) <br> removeOnPausedListener(OnPausedListener<TResult> listener) <br> removeOnProgressListener(OnProgressListener<TResult> listener) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageTask
Obtains error information.<br>`任务执行状态中的错误信息。` | StorageTask.ErrorResult. getError() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageTask-ErrorResult

### Scenario: StorageTask.TimePointStateBase`任务状态信息`
| Description | Api | Reference |
---|---|---
Obtains a StorageTask instance.<br>`获取StorageTask实例。`| getTask() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageTask-TimePointStateBase
Obtains the reference to a task.<br>`获取该任务的引用。` | getStorage() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageTask-TimePointStateBase
Obtains exception information.<br>`获取异常信息。` | getError() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageTask-TimePointStateBase

### Scenario: Download Task `下载任务操作`
| Description | Api | Reference |
---|---|---
Cancels a task. <br>`取消文件下载任务` | DownloadTask.onCanceled() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/DownloadTask
Suspends a task. <br>`暂停文件下载任务` | DownloadTask.onPaused() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/DownloadTask
Cancels a task. <br>`取消流式下载任务的结果信息。` | StreamDownloadTask.onCanceled() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StreamDownloadTask
Refreshes the task progress. <br>`刷新流式下载任务进度` | StreamDownloadTask.onProgress() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StreamDownloadTask
Reads data from streams for service processing. <br> `数据流读取接口` | StreamDownloadTask.StreamHandler.readStream(StreamDownloadResult state, InputStream stream) throws IOException | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StreamDownloadTask-StreamHandler

### Scenario: DownloadTask.DownloadResult`下载任务的结果信息`
| Description | Api | Reference |
---|---|---
Get transferred bytes `获取已传输的字节。 `| getBytesTransferred() | 
Get total byte count `获取下载文件的总字节。` | getTotalByteCount() |

### Scenario: StreamDownloadTask.StreamDownloadResult`流式下载任务的结果信息`
| Description | Api | Reference |
---|---|---
Obtains passed bytes.<br>`获取已传输的字节。` | getBytesTransferred() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StreamDownloadTask-StreamDownloadResult
Obtains the total file size.<br>`获取文件总大小。` | getTotalByteCount() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StreamDownloadTask-StreamDownloadResult
Obtains a response stream.<br>`获取响应数据流。` | getStream() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StreamDownloadTask-StreamDownloadResult

### Scenario: UploadTask`上传任务的操作`
| Description | Api | Reference |
---|---|---
Resumes the upload of a file to the cloud server.<br> `将上传任务延续上一次的进度上传到云端。` | resume() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/UploadTask
Pauses the current upload task. <br> `暂停当前上传任务。` | onPaused() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/UploadTask
Cancels a task. `取消任务。` | onCanceled() |https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/UploadTask
Resets task status. `重置任务状态。` |  resetState() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/UploadTask
Executes a task. `执行任务。` | schedule() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/UploadTask

### Scenario: UploadTask.UploadResult`上传任务的结果信息`
| Description | Api | Reference |
---|---|---
Obtains passed bytes.<br>`获取已传输的字节。` | getBytesTransferred() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/UploadTask-UploadResult
Obtains the total number of bytes of an uploaded file. <br> `获取上传文件的总字节` | getTotalByteCount() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/UploadTask-UploadResult
Obtains metadata of an uploaded file.<br>`获取云端文件的云数据信息` | getMetadata() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/UploadTask-UploadResult

### Scenario: ListResult`获取文件和子目录信息的列表`
| Description | Api | Reference |
---|---|---
Obtains the references to all files in ListResult.`获取ListResult中所有文件的引用。` | getFileList() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/ListResult
Obtains the references to all directories in ListResult. `获取ListResult中所有目录的引用。` | getDirList() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/ListResult
Obtains the pagination identifier for pagination query. `获取分页查询时的分页标识符。` | getPageMarker() | 
https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/ListResult

### Scenario: ProgressListener`任务监听器`
| Description | Api | Reference |
---|---|---
Callback method when the task progress changes. <br> `任务运行过程中的监听器，用来刷新任务进度条。` | public interface OnProgressListener<TResult> <br> onProgress(TResult timePointState) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/OnProgressListener
Callback method when a task is suspended. `暂停任务的监听器。` | public interface OnPausedListener<TResult> <br> OnPaused(TResult timePointState) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/OnPausedListener

### Scenario: StorageException`错误消息和错误码定义`
| Description | Api | Reference |
---|---|---
Converts an exception status code to a storage exception. <br> `通过异常状态码转换为对应的StorageException` | fromErrorStatus(int status) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageException
Converts an exception to a storage exception. <br> `通过异常转换为对应的StorageException。` | fromException(Throwable exception) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageException
Converts an exception to a storage exception.<br> `通过异常转换为对应的StorageException。` | fromException(Throwable exception, int httpStatusCode) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageException
Obtains the result code of an exception. <br> `获取异常响应码。` | getErrorCode() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageException
Obtains the description of an HTTP status code. <br> `获取HTTP状态码描述信息。` | getHttpCode() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageException
Obtains an exception response. <br> `获取异常响应内容。` | getCause() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageException
Checks whether the number of retry times reaches the maximum. <br> `请求重试次数过多，请稍候重试。` | overRetryTimes() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/StorageException













