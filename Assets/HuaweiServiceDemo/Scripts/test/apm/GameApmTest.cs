using System.IO;
using System.Threading;
using UnityEngine;
using HuaweiService.apm;
using HuaweiService;
using UnityEngine.UI;

namespace ApmTest
{
    public class GameApmTest
    {
        private static string sceneHandler = "";
        static int gameApmTest_count = 0;
        private static int stopLoadingSceneTest_count = 0;
        public void gameApmTest(Text text)
        {
            gameApmTest_count++;
            text.text = "gameApmTest start, count: " + gameApmTest_count + "\n";
            
            GameAttribute attribute = new GameAttribute("newscene", GameAttribute.LoadingState.LOADING);
            text.text += "create new attribute success\n";
            
            APMS.getInstance().startGamePlugin();
            text.text +="GameAPM start\n";
            
            APMS.getInstance().enableGamePlugin(true);
            text.text +="enableGamePlugin: true\n";

            sceneHandler = APMS.getInstance().startLoadingScene(attribute);
            text.text +="startLoadingScene, sceneHandler= " + sceneHandler + "\n";

            APMS.getInstance().setCurrentGameAttribute(attribute);
            text.text +="setCurrentGameAttribute\n";

            APMS.getInstance().setReportMinRate(1);
            text.text += "setReportRate\n";

            text.text += "gameApmTest success\n\n";
        }

        public void stopLoadingScene(Text text)
        {
            stopLoadingSceneTest_count++;
            text.text = "stopLoadingSceneTest start, count: " + stopLoadingSceneTest_count + "\n";
            
            APMS.getInstance().stopLoadingScene(sceneHandler);
            text.text +="stopLoadingScene\n";

            APMS.getInstance().stopGamePlugin();
            text.text +="GameAPM stop\n"; 
            
            text.text += "stopLoadingSceneTest success\n";
        }
        
        public void switchGamePluginStatus(bool status, Text text)
        {
            if (status == false)
            {
                Debug.Log("switch enableCollection status from false -> true");
                APMS.getInstance().enableGamePlugin(true);
                text.text = "enableCollection status: true";
            }
            else if (status == true)
            {
                Debug.Log("switch enableCollection status from true -> false");
                APMS.getInstance().enableGamePlugin(false);
                text.text = "enableCollection status: false";
            }
        }
        
    }
}
