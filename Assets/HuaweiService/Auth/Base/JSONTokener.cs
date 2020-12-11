using UnityEngine;
using System.Collections.Generic;
using HuaweiService;

namespace HuaweiService.Auth
{
    public class JSONTokener_Data : IHmsBaseClass{
        public string name => "org.json.JSONTokener";
    }
    public class JSONTokener :HmsClass<JSONTokener_Data>
    {
        public JSONTokener (string arg0): base(arg0) { }
        public JSONTokener (): base() { }
        public AndroidJavaObject nextValue() {
            return Call<AndroidJavaObject>("nextValue");
        }
        public string nextString(char arg0) {
            return Call<string>("nextString", arg0);
        }
        public string toString() {
            return Call<string>("toString");
        }
    }
}