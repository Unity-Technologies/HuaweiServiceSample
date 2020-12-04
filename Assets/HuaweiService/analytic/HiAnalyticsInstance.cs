using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.analytic
{
    public class HiAnalyticsInstance_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.analytics.HiAnalyticsInstance";
    }
    public class HiAnalyticsInstance :HmsClass<HiAnalyticsInstance_Data>
    {
        public HiAnalyticsInstance (): base() { }
        public void setUserId(string arg0) {
            Call("setUserId", arg0);
        }
        public void clearCachedData() {
            Call("clearCachedData");
        }
        public void onEvent(string arg0, Bundle arg1) {
            Call("onEvent", arg0, arg1);
        }
        public void pageEnd(string arg0) {
            Call("pageEnd", arg0);
        }
        public void pageStart(string arg0, string arg1) {
            Call("pageStart", arg0, arg1);
        }
        public void setAnalyticsEnabled(bool arg0) {
            Call("setAnalyticsEnabled", arg0);
        }
        public void setMinActivitySessions(long arg0) {
            Call("setMinActivitySessions", arg0);
        }
        public void setPushToken(string arg0) {
            Call("setPushToken", arg0);
        }
        public void setSessionDuration(long arg0) {
            Call("setSessionDuration", arg0);
        }
        public void setUserProfile(string arg0, string arg1) {
            Call("setUserProfile", arg0, arg1);
        }
        public Task getAAID() {
            return Call<Task>("getAAID");
        }
        public Map getUserProfiles(bool arg0) {
            return Call<Map>("getUserProfiles", arg0);
        }
    }
}