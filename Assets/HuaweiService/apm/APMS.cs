using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.apm
{
    public class APMS_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.apms.APMS";
    }
    public class APMS :HmsClass<APMS_Data>
    {
        public APMS (): base() { }
        public static APMS getInstance() {
            return CallStatic<APMS>("getInstance");
        }
        public void enableCollection(bool arg0) {
            Call("enableCollection", arg0);
        }
        public void enableAnrMonitor(bool arg0) {
            Call("enableAnrMonitor", arg0);
        }
        public CustomTrace createCustomTrace(string arg0) {
            return Call<CustomTrace>("createCustomTrace", arg0);
        }
        public NetworkMeasure createNetworkMeasure(string arg0, string arg1) {
            return Call<NetworkMeasure>("createNetworkMeasure", arg0, arg1);
        }
        
        public void startGamePlugin() {
           GameAPM.getInstance().start();
        }
        public void stopGamePlugin() {
            GameAPM.getInstance().stop();
        }
        public string startLoadingScene(GameAttribute arg0)
        {
            return GameAPM.getInstance().startLoadingScene(arg0);
        }
        public void stopLoadingScene(string arg0)
        {
            GameAPM.getInstance().stopLoadingScene(arg0);
        }
        public void setCurrentGameAttribute(GameAttribute arg0) {
            GameAPM.getInstance().setCurrentGameAttribute(arg0);
        }
        public void setReportRate(int arg0) {
            GameAPM.getInstance().setReportRate(arg0);
        }
        public void enableGamePlugin(bool arg0) {
            GameAPM.getInstance().enableGamePlugin(arg0);
        }
    }
}