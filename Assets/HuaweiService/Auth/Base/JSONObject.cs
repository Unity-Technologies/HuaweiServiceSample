using UnityEngine;
using System.Collections.Generic;
using HuaweiService;

namespace HuaweiService.Auth
{
    public class JSONObject_Data : IHmsBaseClass{
        public string name => "org.json.JSONObject";
    }
    public class JSONObject :HmsClass<JSONObject_Data>
    {
        public JSONObject (): base() { }
        public JSONObject (JSONTokener arg0): base(arg0) { }
        public JSONObject (string arg0): base(arg0) { }
        public JSONObject (Map arg0): base(arg0) { }
        public JSONObject (JSONObject arg0, string[] arg1): base(arg0, arg1) { }
        public JSONObject put(string arg0, bool arg1) {
            return Call<JSONObject>("put", arg0, arg1);
        }
        public JSONObject put(string arg0, double arg1) {
            return Call<JSONObject>("put", arg0, arg1);
        }
        public JSONObject put(string arg0, int arg1) {
            return Call<JSONObject>("put", arg0, arg1);
        }
        public JSONObject put(string arg0, long arg1) {
            return Call<JSONObject>("put", arg0, arg1);
        }
        public JSONObject put(string arg0, AndroidJavaObject arg1) {
            return Call<JSONObject>("put", arg0, arg1);
        }
        public JSONObject putOpt(string arg0, AndroidJavaObject arg1) {
            return Call<JSONObject>("putOpt", arg0, arg1);
        }
    }
}