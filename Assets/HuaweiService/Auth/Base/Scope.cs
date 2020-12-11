using UnityEngine;
using System.Collections.Generic;
using HuaweiService;

namespace HuaweiService.Auth
{
    public class Scope_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.support.api.entity.auth.Scope";
    }
    public class Scope :HmsClass<Scope_Data>
    {
        public Scope (): base() { }
        public Scope (string arg0): base(arg0) { }
        public int hashCode() {
            return Call<int>("hashCode");
        }
        public string toString() {
            return Call<string>("toString");
        }
        public int describeContents() {
            return Call<int>("describeContents");
        }
        public void writeToParcel(Parcel arg0, int arg1) {
            Call("writeToParcel", arg0, arg1);
        }
        public string getScopeUri() {
            return Call<string>("getScopeUri");
        }
    }
}