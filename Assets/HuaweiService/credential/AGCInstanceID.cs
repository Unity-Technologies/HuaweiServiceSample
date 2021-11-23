using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.credential
{
    public class AGCInstanceID_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.common.api.AGCInstanceID";
    }
    public class AGCInstanceID :HmsClass<AGCInstanceID_Data>
    {
        public AGCInstanceID (): base() { }
        public static AGCInstanceID getInstance(Context arg0) {
            return CallStatic<AGCInstanceID>("getInstance", arg0);
        }
        public string getId() {
            return Call<string>("getId");
        }
        public long getCreationTime() {
            return Call<long>("getCreationTime");
        }
        public void deleteAAID() {
            Call("deleteAAID");
        }
    }
}