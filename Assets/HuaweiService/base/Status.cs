using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class Status_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.support.api.client.Status";
    }
    public class Status :HmsClass<Status_Data>
    {
        public static Status SUCCESS => HmsUtil.GetStaticValue<Status>("SUCCESS");
    
        public static Status FAILURE => HmsUtil.GetStaticValue<Status>("FAILURE");
    
        public static Status RESULT_CANCELED => HmsUtil.GetStaticValue<Status>("RESULT_CANCELED");
    
        public static Status RESULT_DEAD_CLIENT => HmsUtil.GetStaticValue<Status>("RESULT_DEAD_CLIENT");
    
        public static Status RESULT_INTERNAL_ERROR => HmsUtil.GetStaticValue<Status>("RESULT_INTERNAL_ERROR");
    
        public static Status RESULT_INTERRUPTED => HmsUtil.GetStaticValue<Status>("RESULT_INTERRUPTED");
    
        public static Status RESULT_TIMEOUT => HmsUtil.GetStaticValue<Status>("RESULT_TIMEOUT");
    
        public static Status MessageNotFound => HmsUtil.GetStaticValue<Status>("MessageNotFound");
    
        public static Status CoreException => HmsUtil.GetStaticValue<Status>("CoreException");
    
        public static HuaweiService.Auth.Parcelable.Creator CREATOR => HmsUtil.GetStaticValue<HuaweiService.Auth.Parcelable.Creator>("CREATOR");
    
        public Status (int arg0, string arg1, Intent arg2): base(arg0, arg1, arg2) { }
        public Status (int arg0, string arg1, PendingIntent arg2): base(arg0, arg1, arg2) { }
        public Status (int arg0, string arg1): base(arg0, arg1) { }
        public Status (int arg0): base(arg0) { }
        public Status (): base() { }
        public int getStatusCode() {
            return Call<int>("getStatusCode");
        }
        public string getStatusMessage() {
            return Call<string>("getStatusMessage");
        }
        public PendingIntent getResolution() {
            return Call<PendingIntent>("getResolution");
        }
        public bool isSuccess() {
            return Call<bool>("isSuccess");
        }
        public bool hasResolution() {
            return Call<bool>("hasResolution");
        }
        public void startResolutionForResult(Activity arg0, int arg1) {
            Call("startResolutionForResult", arg0, arg1);
        }
        public bool equals(AndroidJavaObject arg0) {
            return Call<bool>("equals", arg0);
        }
        public int describeContents() {
            return Call<int>("describeContents");
        }
        public void writeToParcel(Parcel arg0, int arg1) {
            Call("writeToParcel", arg0, arg1);
        }
        public int hashCode() {
            return Call<int>("hashCode");
        }
        public string toString() {
            return Call<string>("toString");
        }
    }
}