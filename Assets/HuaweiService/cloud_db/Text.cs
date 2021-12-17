using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.CloudDB
{
    public class Text_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.cloud.database.Text";
    }
    public class Text :HmsClass<Text_Data>
    {
        public Text (): base() { }
        public Text (string content): base(content) { }
        public string get() {
            return Call<string>("get");
        }
        public void set(string content) {
            Call("set", content);
        }
        public bool equals(AndroidJavaObject arg0) {
            return Call<bool>("equals", arg0);
        }
        public int hashCode() {
            return Call<int>("hashCode");
        }
        public string toString() {
            return Call<string>("toString");
        }
    }
}