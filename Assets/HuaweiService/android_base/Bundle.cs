using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class Bundle_Data : IHmsBaseClass{
        public string name => "android.os.Bundle";
    }
    public class Bundle :HmsClass<Bundle_Data>
    {
        public Bundle (int arg0): base(arg0) { }
        public Bundle (ClassLoader arg0): base(arg0) { }
        public Bundle (): base() { }
        public Bundle (Bundle arg0): base(arg0) { }
        public Bundle (PersistableBundle arg0): base(arg0) { }
        public void putByte(string arg0, byte arg1) {
            Call("putByte", arg0, arg1);
        }
        public void putShort(string arg0, short arg1) {
            Call("putShort", arg0, arg1);
        }
        public void putChar(string arg0, char arg1) {
            Call("putChar", arg0, arg1);
        }
        public void putFloat(string arg0, float arg1) {
            Call("putFloat", arg0, arg1);
        }
        public void putBoolean(string arg0, bool arg1) {
            Call("putBoolean", arg0, arg1);
        }
        public void putInt(string arg0, int arg1) {
            Call("putInt", arg0, arg1);
        }
        public void putLong(string arg0, long arg1) {
            Call("putLong", arg0, arg1);
        }
        public void putDouble(string arg0, double arg1) {
            Call("putDouble", arg0, arg1);
        }
        public void putString(string arg0, string arg1) {
            Call("putString", arg0, arg1);
        }
    }
}