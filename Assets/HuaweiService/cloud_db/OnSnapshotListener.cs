using System.Collections.Generic;
using UnityEngine;

namespace HuaweiService.CloudDB {
    public class OnSnapshotListener_Data : IHmsBaseListener {
        public string name => "com.huawei.agconnect.cloud.database.OnSnapshotListener";
        public string buildName => "";
    }
    public class OnSnapshotListener : HmsListener<OnSnapshotListener_Data> {
        public OnSnapshotListener () : base () { }
        public virtual void onSnapshot (CloudDBZoneSnapshot arg0, AGConnectCloudDBException arg1) {
            Call ("onSnapshot", arg0, arg1);
        }
        public void onSnapshot (AndroidJavaObject arg0, AndroidJavaObject arg1) {
            onSnapshot (HmsUtil.GetHmsBase<CloudDBZoneSnapshot> (arg0),
                HmsUtil.GetHmsBase<AGConnectCloudDBException> (arg1));
        }
    }

    public class OnSnapshotListener<T> : OnSnapshotListener where T : IDatabaseModel, new () {
        public virtual void onSnapshot (CloudDBZoneSnapshot<T> arg0, AGConnectCloudDBException arg1) {
            Call ("onSnapshot", arg0, arg1);
        }
        public void onSnapshot (AndroidJavaObject arg0, AndroidJavaObject arg1) {
            string msg = "";
            int code = 0;
            if (arg1 != null) {
                msg = arg1.Call<string> ("getMessage");
                code = arg1.Call<int> ("getCode");
            }
            onSnapshot (HmsUtil.GetHmsBase<CloudDBZoneSnapshot<T>> (arg0),
                new AGConnectCloudDBException (msg, code));
        }
    }

}