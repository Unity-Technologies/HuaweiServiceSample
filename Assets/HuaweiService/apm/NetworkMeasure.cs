using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.apm
{
    public class NetworkMeasure_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.apms.custom.NetworkMeasure";
    }
    public class NetworkMeasure :HmsClass<NetworkMeasure_Data>
    {
        public NetworkMeasure (string arg0, string arg1): base(arg0, arg1) { }
        public NetworkMeasure (): base() { }
        public void start() {
            Call("start");
        }
        public void stop() {
            Call("stop");
        }
        public void setStatusCode(int arg0) {
            Call("setStatusCode", arg0);
        }
        public void setBytesSent(long arg0) {
            Call("setBytesSent", arg0);
        }
        public void setBytesReceived(long arg0) {
            Call("setBytesReceived", arg0);
        }
        public void setContentType(string arg0) {
            Call("setContentType", arg0);
        }
        public void putProperty(string arg0, string arg1) {
            Call("putProperty", arg0, arg1);
        }
        public void removeProperty(string arg0) {
            Call("removeProperty", arg0);
        }
        public Map getProperties() {
            return Call<Map>("getProperties");
        }
        public string getProperty(string arg0) {
            return Call<string>("getProperty", arg0);
        }
    }
}