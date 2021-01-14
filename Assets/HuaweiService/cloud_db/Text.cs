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
        public Text (string arg0): base(arg0) { }
        public string get() {
            return Call<string>("get");
        }
        public void set(string arg0) {
            Call("set", arg0);
        }
        public int hashCode() {
            return Call<int>("hashCode");
        }
        public bool equals(Text arg0) {
            return Call<bool>("equals", arg0);
        }
    }
}