using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.apm
{
    public class GameAPM_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.apms.game.GameAPM";
    }
    public class GameAPM :HmsClass<GameAPM_Data>
    {
        public GameAPM (): base() { }
        public static GameAPM getInstance() {
            return CallStatic<GameAPM>("getInstance");
        }
        public void start() {
            Call("start");
        }
        public void stop() {
            Call("stop");
        }
        public string startLoadingScene(GameAttribute arg0) {
            return Call<string>("startLoadingScene", arg0);
        }
        public void stopLoadingScene(string arg0) {
            Call("stopLoadingScene", arg0);
        }
        public void setCurrentGameAttribute(GameAttribute arg0) {
            Call("setCurrentGameAttribute", arg0);
        }
        public void setReportRate(int arg0) {
            Call("setReportRate", arg0);
        }
        public void enableGamePlugin(bool arg0) {
            Call("enableGamePlugin", arg0);
        }
        
        
    }
}