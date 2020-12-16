using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.apm
{
    public class CustomTrace_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.apms.custom.CustomTrace";
    }
    public class CustomTrace :HmsClass<CustomTrace_Data>
    {
        public const int MAX_CUSTOM_TRACE_NAME_LENGTH = 100;
        public const int MAX_CUSTOM_TRACE_PROPERTIES = 5;
        public const int MAX_PROPERTY_KEY_LENGTH = 40;
        public const int MAX_PROPERTY_VALUE_LENGTH = 100;
        public const int MAX_MEASURE_NAME_LENGTH = 100;
        public const string NAME_RULE = "^[\u4e00-\u9fa5_a-zA-Z0-9]+$";
        public CustomTrace (string arg0): base(arg0) { }
        public CustomTrace (): base() { }
        public void start() {
            Call("start");
        }
        public void stop() {
            Call("stop");
        }
        public void putProperty(string arg0, string arg1) {
            Call("putProperty", arg0, arg1);
        }
        public void removeProperty(string arg0) {
            Call("removeProperty", arg0);
        }
        public string getProperty(string arg0) {
            return Call<string>("getProperty", arg0);
        }
        public void incrementMeasure(string arg0, long arg1) {
            Call("incrementMeasure", arg0, arg1);
        }
        public long getMeasure(string arg0) {
            return Call<long>("getMeasure", arg0);
        }
        public void putMeasure(string arg0, long arg1) {
            Call("putMeasure", arg0, arg1);
        }
        public Map getTraceProperties() {
            return Call<Map>("getTraceProperties");
        }
    }
}