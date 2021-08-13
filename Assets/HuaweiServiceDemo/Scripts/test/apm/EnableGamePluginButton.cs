using UnityEngine;
using UnityEngine.UI;

namespace ApmTest
{
    public class EnableGamePluginButton : MonoBehaviour
    {
        // Start is called before the first frame update
        public Button m_button;
        private GameApmTest m_test;
        private bool m_gamePluginStatus;

        void Start()
        {
            m_gamePluginStatus = false;
            m_test = new GameApmTest();
            Button btn = m_button.GetComponent<Button>();
            btn.onClick.AddListener(this.switchStatus);
        }

        void switchStatus()
        {
            m_test.switchGamePluginStatus(m_gamePluginStatus);
            m_gamePluginStatus = !m_gamePluginStatus;
        }
    }
}