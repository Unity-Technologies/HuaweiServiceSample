using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.CloudDB
{
    public class OnSnapshotListenerData : IHmsBaseListener
    {
        public string name => "com.huawei.agconnect.cloud.database.OnSnapshotListener";
        public string buildName => "";
    }
    public class OnSnapshotListener : HmsListener<OnSnapshotListenerData>
    {
    
        public virtual void onSnapshot(CloudDBZoneSnapshot snapshot, AGConnectCloudDBException e) {
            Call("onSnapshot", snapshot, e);
        }
    
        public void onSnapshot(AndroidJavaObject snapshot, AndroidJavaObject e){
            onSnapshot(HmsUtil.GetHmsBase<CloudDBZoneSnapshot>(snapshot), HmsUtil.GetHmsBase<AGConnectCloudDBException>(e));
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