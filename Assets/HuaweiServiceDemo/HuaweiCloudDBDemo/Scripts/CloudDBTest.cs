using System;
using System.Collections;
using HuaweiAuthDemo;
using HuaweiService;
using HuaweiService.Auth;
using HuaweiService.CloudDB;
using UnityEngine;

namespace HuaweiServiceDemo {
    public class CloudDBTest : Test<CloudDBTest> {
        private AGConnectCloudDB mCloudDB;
        private CloudDBZone mCloudDBZone;

        private ListenerHandler mRegister;

        private CloudDBZoneConfig mConfig;
        private CloudDBZoneQuery mQuery;
        private static bool captureSnapshot;
        private static CloudDBZoneObjectList<BookInfo> mObjectList = new CloudDBZoneObjectList<BookInfo> ();

        private const string mClouudDBZoneName = "QuickStartDemo";
        private const string bookInfoClass = "com.huawei.agc.clouddb.quickstart.model.BookInfo";
        private DBSnapshotListener<BookInfo> mSnapshotListener = new DBSnapshotListener<BookInfo> ((CloudDBZoneSnapshot<BookInfo> cloudDBZoneSnapshot, AGConnectCloudDBException exception) => {
            if (exception.getCode () != 0) {
                TestTip.Inst.ShowText ("onSnapshot exception: " + exception.getMessage ());
                return;
            }
            // Capture SnapShot to test Snapshot.
            if (CloudDBTest.captureSnapshot) {
                CloudDBTest.captureSnapshot = false;
                CloudDBTest.testSnapShot (cloudDBZoneSnapshot);
                return;
            }

            mObjectList = cloudDBZoneSnapshot.getSnapshotObjects ();
            try {
                if (mObjectList != null) {
                    TestTip.Inst.ShowText ("snapShotObjects size: " + mObjectList.size ());
                }
            } catch (System.Exception e) {
                TestTip.Inst.ShowText ("onSnapshot:(getObject) " + e.Message);

            } finally {
                cloudDBZoneSnapshot.release ();
            }
        });

        private OnSnapshotListener onSnapshot = new OnSnapshotListener ();

        private bool enabled;
        private int level = 0;
        public CloudDBTest () {
            AGConnectCloudDB.initialize (new Context ());
            mCloudDB = AGConnectCloudDB.getInstance ();
            captureSnapshot = false;
            login ();
        }
        public override void RegisterEvent (TestEvent registerEvent) {
            registerEvent ("Clear Log", clearLog);
            registerEvent ("create ObjectType", CreateObjectType);
            registerEvent ("Get CloudDBZoneConfig", getCloudDBZoneConfig);
            // CloudDB
            registerEvent ("Open CloudDBZone", OpenCloudDBZone);
            registerEvent ("Close CloudDBZone", closeCloudDBZone);
            registerEvent ("Delete CloudDBZone", deleteCloudDBZone);
            registerEvent ("Enable Network", enableNetwork);
            registerEvent ("Disable Network", disableNetwork);
            registerEvent ("Add Subscription", addSubscription);
            // CloudDBZone
            registerEvent ("upsert BookInfo", upsertBookInfo);
            registerEvent ("Delete BookInfos", deleteBookInfo);
            registerEvent ("Execute AverageQuery", executeAverageQuery);
            registerEvent ("Execute UsyncQuery", executeUnsyncQuery);

            registerEvent ("Set CloudDBZoneConfig", setCloudDBZoneConfig);
            registerEvent ("Get CloudDBZoneConfigs", getCloudDBZoneConfigs);
            registerEvent ("Get ObjectInfo", getCloudDBZoneObjectInfo);
            // CloudDBZoneQuery
            registerEvent ("Test Query", testQuery);
            registerEvent ("Set CaptureSnapshot", setCaptureSnapshot);
            registerEvent ("Test Transaction", testTransaction);

        }
        public void clearLog () {
            TestTip.Inst.Clear ();
        }

        public void CreateObjectType () {
            try {
                mCloudDB.createObjectType (ObjectTypeInfoHelper.getObjectTypeInfo ());
                TestTip.Inst.ShowText ("createObjectType successfully. ");
            } catch (System.Exception e) {
                TestTip.Inst.ShowText ("createObjectType: " + e.Message);
            }
        }

        public void OpenCloudDBZone () {
            mConfig = new CloudDBZoneConfig ("QuickStartDemo",
                CloudDBZoneConfig.CloudDBZoneSyncProperty.CLOUDDBZONE_CLOUD_CACHE,
                CloudDBZoneConfig.CloudDBZoneAccessProperty.CLOUDDBZONE_PUBLIC);
            mConfig.setPersistenceEnabled (true);
            try {
                Task openDBZoneTask = mCloudDB.openCloudDBZone2 (mConfig, true);
                openDBZoneTask.addOnSuccessListener (new HmsSuccessListener<CloudDBZone> ((cloudDBZone) => {
                    mCloudDBZone = cloudDBZone;
                    TestTip.Inst.ShowText ("open clouddbzone success");
                    addSubscription ();
                })).addOnFailureListener (new HmsFailureListener ((HuaweiService.Exception e) => {
                    TestTip.Inst.ShowText ("open clouddbzone failed " + e.toString ());
                }));
            } catch (System.Exception e) {
                TestTip.Inst.ShowText ("createObjectType: " + e.Message);
            }
        }

        public void getCloudDBZoneConfigs () {
            try {
                List configList = mCloudDB.getCloudDBZoneConfigs ();
                if (configList != null) {
                    TestTip.Inst.ShowText ("GetCloudDBZoneConfigs: " + configList.toArray ().Length);
                }
            } catch (System.Exception e) {
                TestTip.Inst.ShowText ("GetCloudDBZoneConfig: " + e.Message);
            }

        }

        public void closeCloudDBZone () {
            if (mCloudDBZone == null) {
                TestTip.Inst.ShowText ("CloudDBZone is null, try re-open it");
                return;
            }
            try {
                mRegister?.remove ();
                mCloudDB.closeCloudDBZone (mCloudDBZone);
                TestTip.Inst.ShowText ("close clouddbzone success");
            } catch (System.Exception e) {
                TestTip.Inst.ShowText ("closeCloudDBZone: " + e.Message);
            }
        }

        public void deleteCloudDBZone () {
            try {
                mCloudDB.deleteCloudDBZone ("QuickStartDemo");
                TestTip.Inst.ShowText ("DeleteCloudDBZone: QuickStartDemo");
            } catch (System.Exception e) {
                TestTip.Inst.ShowText ("deleteCloudDBZone: " + e.Message);
            }
        }

        public void enableNetwork () {
            mCloudDB.enableNetwork (mClouudDBZoneName);
            TestTip.Inst.ShowText ("Enable Network");

        }
        public void disableNetwork () {
            mCloudDB.disableNetwork (mClouudDBZoneName);
            TestTip.Inst.ShowText ("Disable Network");
        }

        public void addSubscription () {

            if (mCloudDBZone == null) {
                TestTip.Inst.ShowText ("CloudDBZone is null, try re-open it");
                return;
            }
            try {
                CloudDBZoneQuery snapshotQuery = CloudDBZoneQuery.where (new AndroidJavaClass (bookInfoClass))
                    .equalTo ("shadowFlag", true);
                mRegister = mCloudDBZone.subscribeSnapshot (snapshotQuery,
                    CloudDBZoneQuery.CloudDBZoneQueryPolicy.POLICY_QUERY_FROM_CLOUD_ONLY, mSnapshotListener);
                TestTip.Inst.ShowText ("Add subscription success");
            } catch (System.Exception e) {
                TestTip.Inst.ShowText ("subscribeSnapshot: " + e.Message);
            }
        }

        public void upsertBookInfo () {
            if (mCloudDBZone == null) {
                TestTip.Inst.ShowText ("CloudDBZone is null, try re-open it");
                return;
            }
            var bookInfo = new BookInfo { Id = 4 };

            Task task = mCloudDBZone.executeUpsert (bookInfo);
            task.addOnSuccessListener (new HmsSuccessListener<int> ((cloudDBZoneResult) => {
                TestTip.Inst.ShowText ("upsert " + cloudDBZoneResult + " records");
            })).addOnFailureListener (new HmsFailureListener ((exception) => {
                TestTip.Inst.ShowText ("upsert bookinfo failed: " + exception.toString ());
            }));

            List<BookInfo> list = new List<BookInfo> ();
            list.add (new BookInfo { Id = 5 });
            list.add (new BookInfo { Id = 6 });
            list.add (new BookInfo { Id = 7, BookName = "testTransaction"});


            Task task2 = mCloudDBZone.executeUpsert (list);
            task2.addOnSuccessListener (new HmsSuccessListener<int> ((cloudDBZoneResult) => {
                TestTip.Inst.ShowText ("upsert " + cloudDBZoneResult + " records");
            })).addOnFailureListener (new HmsFailureListener ((exception) => {
                TestTip.Inst.ShowText ("upsert bookinfo failed: " + exception.toString ());
            }));
        }

        public void deleteBookInfo () {
            if (mCloudDBZone == null) {
                TestTip.Inst.ShowText ("CloudDBZone is null, try re-open it");
                return;
            }
            mQuery = CloudDBZoneQuery.where (new AndroidJavaClass (bookInfoClass));
            Task queryTask = mCloudDBZone.executeQuery (mQuery, CloudDBZoneQuery.CloudDBZoneQueryPolicy.POLICY_QUERY_FROM_CLOUD_ONLY);
            queryTask.addOnSuccessListener (new HmsSuccessListener<CloudDBZoneSnapshot<BookInfo>> ((snapshot) => {
                mObjectList = snapshot.getSnapshotObjects ();

                BookInfo bookInfo = mObjectList.get (3);
                Task deleteTask = mCloudDBZone.executeDelete (bookInfo);
                deleteTask.addOnSuccessListener (new HmsSuccessListener<int> ((cloudDBZoneResult) => {
                    TestTip.Inst.ShowText ("delete " + cloudDBZoneResult + " records");
                })).addOnFailureListener (new HmsFailureListener ((exception) => {
                    TestTip.Inst.ShowText ("delete bookinfo failed: " + exception.toString ());
                }));

                List<BookInfo> list = new List<BookInfo> ();
                list.add (mObjectList.get (4));
                list.add (mObjectList.get (5));
                Task deleteTask2 = mCloudDBZone.executeDelete (list);
                deleteTask2.addOnSuccessListener (new HmsSuccessListener<int> ((cloudDBZoneResult) => {
                    TestTip.Inst.ShowText ("delete " + cloudDBZoneResult + " records");
                })).addOnFailureListener (new HmsFailureListener ((exception) => {
                    TestTip.Inst.ShowText ("delete bookinfo failed: " + exception.toString ());
                }));

            })).addOnFailureListener (new HmsFailureListener ((exception) => {
                TestTip.Inst.ShowText ("Query book list from cloud failed: " + exception.toString ());
            }));

        }

        public void executeQuery (string tag) {
            if (mCloudDBZone == null || mQuery == null) {
                TestTip.Inst.ShowText ("CloudDBZone or CloudDBZoneQuery is null, try re-open it");
                return;
            }
            Task queryTask = mCloudDBZone.executeQuery (mQuery, CloudDBZoneQuery.CloudDBZoneQueryPolicy.POLICY_QUERY_FROM_CLOUD_ONLY);
            queryTask.addOnSuccessListener (new HmsSuccessListener<CloudDBZoneSnapshot<BookInfo>> ((snapshot) => {
                processQueryResult (snapshot, tag);
            })).addOnFailureListener (new HmsFailureListener ((exception) => {
                TestTip.Inst.ShowText ("Query book list from cloud failed: " + exception.toString ());
            }));
        }

        public void executeAverageQuery () {
            if (mCloudDBZone == null) {
                TestTip.Inst.ShowText ("CloudDBZone is null, try re-open it");
                return;
            }
            mQuery = CloudDBZoneQuery.where (new AndroidJavaClass (bookInfoClass));
            Task queryTask = mCloudDBZone.executeAverageQuery (mQuery, "price", CloudDBZoneQuery.CloudDBZoneQueryPolicy.POLICY_QUERY_FROM_CLOUD_ONLY);
            queryTask.addOnSuccessListener (new HmsSuccessListener<double> ((result) => {
                TestTip.Inst.ShowText ("query average price: " + result);
            })).addOnFailureListener (new HmsFailureListener ((exception) => {
                TestTip.Inst.ShowText ("query average price failed: " + exception.toString ());
            }));
        }

        public void executeUnsyncQuery () {
            if (mCloudDBZone == null) {
                TestTip.Inst.ShowText ("CloudDBZone is null, try re-open it");
                return;
            }
            var tag = "Unsync";
            mQuery = CloudDBZoneQuery.where (new AndroidJavaClass (bookInfoClass));
            Task queryTask = mCloudDBZone.executeQueryUnsynced (mQuery);
            queryTask.addOnSuccessListener (new HmsSuccessListener<CloudDBZoneSnapshot<BookInfo>> ((snapshot) => {
                TestTip.Inst.ShowText ("ExecuteQueryUnsynced.");
                processQueryResult (snapshot, tag);
            })).addOnFailureListener (new HmsFailureListener ((exception) => {
                TestTip.Inst.ShowText ("ExecuteQueryUnsynced failed: " + exception.toString ());
            }));
        }

        private void processQueryResult (CloudDBZoneSnapshot<BookInfo> snapshot, string tag) {
            mObjectList = snapshot.getSnapshotObjects ();
            List<BookInfo> bookInfoList = new List<BookInfo> ();
            try {
                string result = "";
                while (mObjectList.hasNext ()) {
                    BookInfo bookInfo = mObjectList.next ();
                    bookInfoList.add (bookInfo);
                    result += $"{bookInfo.BookName} ";
                }
                TestTip.Inst.ShowText ($"QueryResult {tag}: {result}");

            } catch (System.Exception e) {
                TestTip.Inst.ShowText ($"QueryResult {tag}: {e.Message}");
            } finally {
                snapshot.release ();
            }
        }

        public void getCloudDBZoneConfig () {
            string name = mConfig.getCloudDBZoneName ();
            CloudDBZoneConfig.CloudDBZoneAccessProperty accessProperty = mConfig.getAccessProperty ();
            CloudDBZoneConfig.CloudDBZoneSyncProperty asyncProperty = mConfig.getSyncProperty ();
            bool isEncrypted = mConfig.isEncrypted ();
            bool getPersistenceEnabled = mConfig.getPersistenceEnabled ();
            long capacity = mConfig.getCapacity ();
            TestTip.Inst.ShowText ($"CloudDBZoneName: {name}");
            TestTip.Inst.ShowText ($"CloudDBZoneAccessProperty: {accessProperty}");
            TestTip.Inst.ShowText ($"CloudDBZoneAsyncProperty: {asyncProperty}");
            TestTip.Inst.ShowText ($"CloudDBZone isEncrypted: {isEncrypted}");
            TestTip.Inst.ShowText ($"CloudDBZone getPersistenceEnabled: {getPersistenceEnabled}");
            TestTip.Inst.ShowText ($"CloudDBZone capacity : {capacity}");
        }

        public void setCloudDBZoneConfig () {
            if (mConfig == null) {
                TestTip.Inst.ShowText ("CloudDBConfig is null");
                return;
            }
            mConfig.setEncryptedKey ("123456", null);
            mConfig.setPersistenceEnabled (true);
            mConfig.setCapacity (200000000);
        }

        public void getCloudDBZoneObjectInfo () {
            BookInfo bookInfo = new BookInfo {
                BookName = "test5",
                Price = 12.0,
                ShadowFlag = false
            };
            TestTip.Inst.ShowText ($"CloudDBZoneObjectInfo Package: {bookInfo.getObjectTypeName()}");
            TestTip.Inst.ShowText ($"CloudDBZoneObjectInfo Package: {bookInfo.getPackageName()}");
        }

        public void testQuery () {
            mQuery = CloudDBZoneQuery.where (new AndroidJavaClass (bookInfoClass)).equalTo ("id", 1);
            executeQuery ("author is cedric");
            mQuery = CloudDBZoneQuery.where (new AndroidJavaClass (bookInfoClass)).notEqualTo ("author", "cedric");
            executeQuery ("author is not cedric");
            mQuery = CloudDBZoneQuery.where (new AndroidJavaClass (bookInfoClass)).greaterThan ("price", 11.0);
            executeQuery ("price > 11.0");
            mQuery = CloudDBZoneQuery.where (new AndroidJavaClass (bookInfoClass)).greaterThanOrEqualTo ("price", 11.0);
            executeQuery ("price >= 11.0");
            mQuery = CloudDBZoneQuery.where (new AndroidJavaClass (bookInfoClass)).lessThan ("publishTime", new Date ((long) 1607500800));
            executeQuery ("publishTime < 1607500800");
            mQuery = CloudDBZoneQuery.where (new AndroidJavaClass (bookInfoClass)).lessThanOrEqualTo ("price", 24.0);
            executeQuery ("price <= 24.0");
            mQuery = CloudDBZoneQuery.where (new AndroidJavaClass (bookInfoClass)).@in ("author", new string[] { "cedric" });
            executeQuery ("cedric in author");
            mQuery = CloudDBZoneQuery.where (new AndroidJavaClass (bookInfoClass)).beginsWith ("author", "ce");
            executeQuery ("author beginsWith ce");
            mQuery = CloudDBZoneQuery.where (new AndroidJavaClass (bookInfoClass)).endsWith ("author", "ic");
            executeQuery ("author endsWith ic");
            mQuery = CloudDBZoneQuery.where (new AndroidJavaClass (bookInfoClass)).contains ("author", "dr");
            executeQuery ("author contains dr");
            mQuery = CloudDBZoneQuery.where (new AndroidJavaClass (bookInfoClass)).isNull ("author");
            executeQuery ("author isNull");
            mQuery = CloudDBZoneQuery.where (new AndroidJavaClass (bookInfoClass)).isNotNull ("author");
            executeQuery ("author isNotNull");
            mQuery = CloudDBZoneQuery.where (new AndroidJavaClass (bookInfoClass)).orderByAsc ("author");
            executeQuery ("author by asc");
            mQuery = CloudDBZoneQuery.where (new AndroidJavaClass (bookInfoClass)).orderByDesc ("author");
            executeQuery ("author by desc");
            mQuery = CloudDBZoneQuery.where (new AndroidJavaClass (bookInfoClass)).limit (1, 0);
            executeQuery ("limit 1 by 0");
        }

        public void setCaptureSnapshot () {
            captureSnapshot = true;
        }

        public static void testSnapShot (CloudDBZoneSnapshot<BookInfo> snapshot) {
            if (snapshot != null) {
                TestTip.Inst.ShowText ("Snapshot hasPendingWrites: " + snapshot.hasPendingWrites ());
                TestTip.Inst.ShowText ("Snapshot isFromCloud: " + snapshot.isFromCloud ());
                TestTip.Inst.ShowText ("Snapshot getSnapshotObjects: " + snapshot.getSnapshotObjects ().size ());
                TestTip.Inst.ShowText ("Snapshot getDeletedObjects: " + snapshot.getDeletedObjects ().size ());
                TestTip.Inst.ShowText ("Snapshot getUpsertedObjects: " + snapshot.getUpsertedObjects ().size ());
            }
        }

        public void testTransaction () {
            Transaction.Function f = new Transaction.Function ((t) => {
                try {
                    mQuery = CloudDBZoneQuery.where (new AndroidJavaClass (bookInfoClass)).equalTo ("bookName", "testTransaction");
                    var queryList = t.executeQuery (mQuery);
                    TestTip.Inst.ShowText ("Transaction success:  " + queryList.toArray ().Length);


                    t = t.executeDelete (queryList);
                    TestTip.Inst.ShowText ("Transaction success:  " + queryList.toArray ().Length);
                } catch (System.Exception e) {
                    TestTip.Inst.ShowText ("Transaction fail:  " + e.Message);
                    return false;
                }
                return true;
            });
            TestTip.Inst.ShowText ("Run Transaction.");
            mCloudDBZone.runTransaction (f);
        }

        public void login () {
            AGConnectAuth auth = AGConnectAuth.getInstance ();
            auth.signInAnonymously ().addOnSuccessListener (new HuaweiOnsuccessListener<SignInResult> ((signresult) => {
                TestTip.Inst.ShowText ("sign in successfully." + signresult.getUser ().getUid ());

            })).addOnFailureListener (new HuaweiOnFailureListener ((e) => {
                TestTip.Inst.ShowText ("sign in failed");
            }));
        }

    }
}