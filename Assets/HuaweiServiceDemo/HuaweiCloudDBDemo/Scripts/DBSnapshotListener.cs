using HuaweiService;
using HuaweiService.CloudDB;
using UnityEngine;

namespace HuaweiServiceDemo {
    public delegate void SnapShotCb<T> (CloudDBZoneSnapshot<T> arg0, AGConnectCloudDBException arg1) where T : IDatabaseModel, new ();

    public class DBSnapshotListener<T> : OnSnapshotListener<T> where T : IDatabaseModel, new () {
        private SnapShotCb<T> cb;

        public DBSnapshotListener (SnapShotCb<T> cb) {
            this.cb = cb;
        }
        public override void onSnapshot (CloudDBZoneSnapshot<T> arg0, AGConnectCloudDBException arg1) {
            if (cb != null) {
                var exception = new AGConnectCloudDBException();
                exception.obj = arg1.obj;
                cb.Invoke (arg0, arg1);
            }
        }
    }

    public delegate void SuccessCb (AndroidJavaObject o);
    public delegate void FailureCb (Exception e);
    public class DBSuccessListener : OnSuccessListener {
        public SuccessCb cb;
        public DBSuccessListener (SuccessCb c) {
            cb = c;
        }
        public override void onSuccess (AndroidJavaObject arg0) {
            TestTip.Inst.ShowText ("OnSuccessListener onSuccess");
            if (cb != null) {
                cb.Invoke (arg0);
            }
        }
    }
    public class DBFailureListener : OnFailureListener {
        public FailureCb cb;
        public DBFailureListener (FailureCb c) {
            cb = c;
        }
        public override void onFailure (Exception arg0) {
            TestTip.Inst.ShowText ("OnFailureListener onFailure");
            if (cb != null) {
                cb.Invoke (arg0);
            }
        }
    }
}