using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.push
{
    public class HmsInstanceId_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.aaid.HmsInstanceId";
    }
    public class HmsInstanceId :HmsClass<HmsInstanceId_Data>
    {
        public const string TAG = "HmsInstanceId";
        public HmsInstanceId (): base() { }
        public static HmsInstanceId getInstance(Context arg0) {
            return CallStatic<HmsInstanceId>("getInstance", arg0);
        }
        public string getId() {
            return Call<string>("getId");
        }
        public long getCreationTime() {
            return Call<long>("getCreationTime");
        }
        public string getToken(string arg0, string arg1) {
            return Call<string>("getToken", arg0, arg1);
        }
        public string getToken() {
            return Call<string>("getToken");
        }
        public void deleteToken(string arg0, string arg1) {
            Call("deleteToken", arg0, arg1);
        }
        public void deleteAAID() {
            Call("deleteAAID");
        }
        public Task getAAID() {
            return Call<Task>("getAAID");
        }
    }
}