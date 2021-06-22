# HuaweiService.clouddb

### Scenario: AGConnectCloudDB Initialize`初始化`
| Description | Api | Reference |
---|---|---
Initializes an AGConnectCloudDB.<br>`初始化` | initialize(Context context) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-agconnectclouddb
Obtains an AGConnectCloudDB instance. <br>`获取一个AGConnectCloudDB实例` | getInstance() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-agconnectclouddb
Set AGConnectCloudDB mode<br> `设置端侧AGConnectCloudDB的升级模式` | getInstance(HttpURLConnectionFactory factory) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-agconnectclouddb
Create or revise object type, identify CloudDBZoneObject storage set <br>`创建或修改对象类型，定义存储CloudDBZoneObject的集合` | setUpgradeProcessMode(CloudDBZoneUpgradeProcessMode upgradeProcessMode) | 
Creates or modifies object types and defines a set for storing CloudDBZoneObjects.<br>`获取端侧AGConnectCloudDB实例中的全部CloudDBZoneConfig列表` | createObjectType(ObjectTypeInfo objectTypeInfo) throws AGConnectCloudDBException | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-agconnectclouddb
Obtains all CloudDBZoneConfig lists in the AGConnectCloudDB instance on the device.<br>`创建或者打开一个Cloud DB zone对象，一个Cloud DB zone对象表示一个唯一的数据存储区域` | getCloudDBZoneConfigs() throws AGConnectCloudDBException | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-agconnectclouddb
Closes the Cloud DB zone object opened on the device. <br> `关闭端侧打开的Cloud DB zone对象` | closeCloudDBZone(CloudDBZone zone) throws AGConnectCloudDBException | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-agconnectclouddb
Deletes the Cloud DB zone object that is no longer used on the device.<br>`删除端侧不再使用的Cloud DB zone对象` | deleteCloudDBZone(String zoneName) throws AGConnectCloudDBException | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-agconnectclouddb
Enables data synchronization between the device and cloud.<br>`打开端云之间的数据同步开关` | enableNetwork(String zoneName) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-agconnectclouddb
Closes data synchronization between the device and cloud. <br>`关闭端云之间的数据同步开关` | disableNetwork(String zoneName) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-agconnectclouddb

### Scenario: CloudDBZone`存储区操作`
| Description | Api | Reference |
---|---|---
Obtains the current configuration information of Cloud DB zone.<br>`获取当前Cloud DB zone的配置信息` | getCloudDBZoneConfig() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-clouddbzone
Writes an object to the current Cloud DB zone.<br>`将一个对象写入到当前Cloud DB zone` <br> Writes a group of objects to the current Cloud DB zone in batches.<br>`将一组对象批量写入到当前Cloud DB zone` | executeUpsert(CloudDBZoneObject cloudDBZoneObject) <br><br> executeUpsert(final List<? extends CloudDBZoneObject> objectList) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-clouddbzone
Deletes a Cloud DB zone object whose primary key value is the same as that of the input object.<br>`删除Cloud DB zone中与传入对象主键值相同的一个对象` <br> Deletes a group of Cloud DB zone objects whose primary key values are the same as those of the input object list in batches.`批量删除Cloud DB zone中与传入对象列表主键值相同的一组对象。删除指定对象类型中的所有数据。` | executeDelete(CloudDBZoneObject cloudDBZoneObject) <br> executeDelete(final List<? extends CloudDBZoneObject> objectList) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-clouddbzone
Queries object data that meets specified conditions in Cloud DB zone and encapsulates the query result set into a CloudDBZoneSnapshot. `从Cloud DB zone中查询满足特定条件的对象数据，并将查询到的结果集封装到一个CloudDBZoneSnapshot中` | executeQuery(final CloudDBZoneQuery<T> cloudDBZoneQuery, finalCloudDBZoneQueryPolicy queryPolicy) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-clouddbzone
Queries object data that meets specified conditions in Cloud DB zone and returns the average value of specified fields. `从Cloud DB zone中查找满足特定条件的对象数据，返回指定字段的平均值` | executeAverageQuery(final CloudDBZoneQuery<T>cloudDBZoneQuery, final String fieldName, finalCloudDBZoneQueryPolicy queryPolicy) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-clouddbzone
Queries all object data that meets specified conditions in Cloud DB but has not been synchronized to the cloud, and encapsulates the query result set into a CloudDBZoneSnapshot. `从Cloud DB中查询所有满足指定条件，但尚未同步到云端的对象数据，并将查询到的结果集封装到一个CloudDBZoneSnapshot中` | executeQueryUnsynced(final CloudDBZoneQuery cloudDBZoneQuery) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-clouddbzone
Executes a specified transaction operation. `执行一个指定的事务操作。` | runTransaction(final Transaction.Function function) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-clouddbzone
Registers a listener for a specified object on the device or cloud. When the data of the object that is listened on is changed, the registered OnSnapshotListener callback is triggered. `注册一个对端侧或者云侧特定对象数据的侦听，当侦听的对象数据发生变化，触发注册的OnSnapshotListener回调` | subscribeSnapshot(CloudDBZoneQuery<T>cloudDBZoneQuery,CloudDBZoneQueryPolicy queryPolicy, OnSnapshotListener<T>listener) throws AGConnectCloudDBException | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-clouddbzone

### Scenario: CloudDBZoneConfig`配置`
| Description | Api | Reference |
---|---|---
Synchronization property of the Cloud DB zone, which specifies whether to synchronize data of Cloud DB zone between the device and the cloud and the synchronization mode.`Cloud DB zone的数据同步属性` | public enum CloudDBZoneSyncProperty CLOUDDBZONE_LOCAL_ONLY | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-clouddbzoneconfig
Access property of the Cloud DB zone, which is used to define the security property when an application accesses Cloud DB zone.`Cloud DB zone的访问属性` | public enum CloudDBZoneAccessProperty CLOUDDBZONE_CLOUD_CACHE | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-clouddbzoneconfig
Obtains the Cloud DB zone name on the device.getCloudDBZoneName() `获取端侧Cloud DB zone的名称。` | getCloudDBZoneName() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-clouddbzoneconfig
Obtains the Cloud DB zone data synchronization property on the device. `获取端侧Cloud DB zone的数据同步属性` | getSyncProperty() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-clouddbzoneconfig
Obtains the Cloud DB zone access property on the device.`获取端侧Cloud DB zone的访问属性` | getAccessProperty() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-clouddbzoneconfig
Determines whether the Cloud DB zone data is encrypted on the device.`判断端侧Cloud DB zone是否加密` | isEncrypted() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-clouddbzoneconfig
Sets or changes the key for encrypting and storing Cloud DB zone data on the device.`设置或者修改端侧Cloud DB zone数据加密存储的密钥` | setEncryptedKey(String key, String rekey) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-clouddbzoneconfig
Sets the data persistency property of Cloud DB zone on the device.`设置端侧Cloud DB zone的数据持久化属性`<br>Obtains the data persistence information of Cloud DB zone on the device.`获取端侧Cloud DB zone的数据持久化信息` | setPersistenceEnabled(boolean isPerEnable) <br> getPersistenceEnabled() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-clouddbzoneconfig
Sets the storage space size of Cloud DB zone on the device. `设置端侧Cloud DB zone的存储空间大小`<br>Obtains the storage space size of Cloud DB zone on the device.`获取端侧Cloud DB zone的存储空间大小` | setCapacity(long capacity) <br> getCapacity() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-clouddbzoneconfig

### Scenario: ### CloudDBZoneObject`对象类型的操作`
| Description | Api | Reference |
---|---|---
Obtains the name of an object type.`获取对象类型的名称` | getObjectTypeName() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-clouddbzoneobject
Gets the full path of the custom object type class.`获取自定义对象类型类的全路径` | getPackageName() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-clouddbzoneobject

### Scenario: CloudDBZoneObjectList`对象类型列表的操作`
| Description | Api | Reference |
---|---|---
Obtains the number of data objects contained in the CloudDBZoneObjectList object.`获取CloudDBZoneObjectList对象所包含的数据对象个数` | size() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-clouddbzoneobjectlist
Obtains an object from the CloudDBZoneObjectList based on the subscript.`根据下标获取CloudDBZoneObjectList中的某个对象` | get(int index) throws AGConnectCloudDBException | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-clouddbzoneobjectlist
Obtains the next object in CloudDBZoneObjectList. `获取CloudDBZoneObjectList中的下一个对象` | next() throws AGConnectCloudDBException | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-clouddbzoneobjectlist
Determines whether the next object in CloudDBZoneObjectList exists. `判断CloudDBZoneObjectList中的下一个对象是否存在` | hasNext() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-clouddbzoneobjectlist

### Scenario: CloudDBZoneQuery`查询数据`
| Description | Api | Reference |
---|---|---
Query policy, which specifies the data source to be queried.<br> `查询的策略，指定查询的数据来源：<br>从本地缓存查询。<br>从云侧存储区服务器查询。<br>优先从云侧存储区服务器查询，如果查询失败，则从本地缓存查询。` | public enum CloudDBZoneQueryPolicy POLICY_QUERY_FROM_LOCAL_ONLY <br> public enum CloudDBZoneQueryPolicy POLICY_QUERY_FROM_CLOUD_ONLY <br> public enum CloudDBZoneQueryPolicy POLICY_QUERY_FROM_CLOUD_PRIOR | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-clouddbzonequery
Obtains a CloudDBZoneQuery object and specifies the object type to be queried. The CloudDBZoneQuery object does not provide any construction method. You can obtain an object type instance only by using the where method. <br> `获取一个CloudDBZoneQuery对象，并指定查询的对象类型。CloudDBZoneQuery对象不提供任何构造方法，只能通过where方法获取一个对象类型实例` | public static <T extends CloudDBZoneObject> CloudDBZoneQuery<T> where(Class<T> entityClass) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-clouddbzonequery
Adds a query condition：where the value of a field in an entity class is equal to a specified value. <br> where the value of a field in an entity class is not equal to a specified value. <br> where the value of a field in an entity class is greater than a specified value. <br> where the value of a field in an entity class is greater than or equal to a specified value. <br> where the value of a field in an entity class is less than a specified value. <br> Adds a query condition where the value of a field in an entity class is less than or equal to a specified value. <br> where the value of a field in an entity class is contained in a specified array. <br> `添加实体类中某个字段的值：<br>等于指定值的查询条件<br>大于指定值的查询条件。<br>大于等于指定值的查询条件。<br>小于指定值的查询条件。<br>小于等于指定值的查询条件。<br>被指定数组所包含的查询条件。` | equalTo(fieldName, value)  <br> <br>  notEqualTo(fieldName, value) <br> <br>  greaterThan(fieldName, value)  <br> <br> greaterThanOrEqualTo(fieldName, value) <br>  <br> lessThan(fieldName, value)lessThanOrEqualTo(fieldName, value) <br>  <br> in(fieldName, value) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-clouddbzonequery
Adds a query condition：<br> where the value of a field of the string or text type in an entity class starts with a specified substring. <br> where the value of a field of the string or text type in an entity class ends with a specified substring. <br> where the value of a field of the string or text type in an entity class contains a specified substring. <br> `添加实体类中某个String/Text类型的字段值： <br> 以指定子串开头的查询条件。 <br> 以指定子串结尾的查询条件。 <br> 包含指定子串的查询条件。` | beginsWith(fieldName, value) <br><br> endsWith(fieldName, value) <br><br> contains(fieldName, value) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-clouddbzonequery
Adds a query condition：where a field in an entity class is null. where a field in an entity class is not null. <br> `添加实体类中某个字段的值：<br>为空的查询条件。<br>不为空的查询条件。` | isNull(String fieldName) <br> isNotNull(String fieldName) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-clouddbzonequery
Sorts the query results in ascending order by a specified field. <br> `设置查询结果按指定字段升序排列` <br>Sorts the query results in descending order by a specified field.<br>`设置查询结果按指定字段升序排列。` | orderByAsc(String fieldName) <br> orderByDesc(String fieldName) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-clouddbzonequery
Adds a query condition to specify that only the count object data records starting from the specified offset position in the query result set are returned. <br> `添加查询条件，用于限定返回查询结果集中的数据数量。` | limit(int count, int offset) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-clouddbzonequery

### Scenario: CloudDBZoneSnapshot `快照数据处理`
| Description | Api | Reference |
---|---|---
Determines whether the current snapshot contains objects that have not been synchronized to the cloud. <br> `判断当前快照中是否存在尚未同步到云端的对象。` <br> Determines whether the object data in the current snapshot can be queried from the cloud. <br> `判断当前快照中的对象数据是否从云端查询得到。` | hasPendingWrites() <br> isFromCloud() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-clouddbzonesnapshot
Obtains all object data from snapshots. <br> `获取快照中全量的对象数据。` <br> Obtains the object data added or modified in a snapshot. <br> `获取快照中新增或者修改的对象数据。`<br> Obtains the newly deleted object data from the snapshot. <br> `获取快照中新删除的对象数据。` | getSnapshotObjects() <br> getUpsertedObjects() <br> getDeletedObjects() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-clouddbzonesnapshot
Releases resources occupied by the snapshot.<br>`释放快照占用的资源。` | release() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-clouddbzonesnapshot

### Scenario: ListenerHandler`快照侦听`
| Description | Api | Reference |
---|---|---
Deregisters the snapshot listener.<br>`注销快照侦听。` | remove() | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-listenerhandler

### Scenario: Function`定义事务需要执行的操作`
| Description | Api | Reference |
---|---|---
The API is used to define the operations to be performed by a transaction, that is, define the executeQuery(), executeUpsert(), and executeDelete() operations in the Transaction class. Cloud DB automatically calls the apply() method to perform user-defined operations. <br> `通过实现此接口来定义事务需要执行的操作，即定义Transaction类中的executeQuery()、executeUpsert()和executeDelete()操作。Cloud DB会自动调用apply()方法来执行开发者自定义的操作。` | apply(Transaction transaction) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-function

### Scenario: Transaction`事务描述`
| Description | Api | Reference |
---|---|---
Queries a set of objects that meet specific conditions from the Cloud DB zone on the cloud in a transaction. <br> `在事务中从云侧存储区查询获取满足特定条件的对象集合。<br>事务是原子的，事务内的操作要么全部成功，要么全部失败。` | public <T extends CloudDBZoneObject> List<T> executeQuery(CloudDBZoneQuery<T> cloudDBZoneQuery) throws AGConnectCloudDBException | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-transaction
Writes a group of objects to the Cloud DB zone in a transaction in batches. <br> `在事务中将一组对象批量写入到云侧存储区,事务内的操作要么全部成功，要么全部失败。` | public Transaction executeUpsert(List<? extends CloudDBZoneObject> objectList) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-transaction
Deletes a group of objects from the Cloud DB zone in a transaction in batches. <br> `在事务中批量删除云侧存储区中的一组对象。事务内的操作要么全部成功，要么全部失败。<br>删除操作只关注对象的主键是否一致，不考虑对象其他属性和存储的数据是否匹配。` | public Transaction executeDelete(List<? extends CloudDBZoneObject> objectList) | https://developer.huawei.com/consumer/en/doc/development/AppGallery-connect-References/clouddb-transaction

