using UnityEngine;
using UnityEngine.UI;

namespace ApmTest
{
    public class EnableAnrMonitorButton : MonoBehaviour
    {
        // Start is called before the first frame update
        public Button m_button;
        public ApmTest m_test;
        private bool m_ampsAnrStatus;

        void Start()
        {
            m_ampsAnrStatus = false;
            Button btn = m_button.GetComponent<Button>();
            m_test = new ApmTest();
            btn.onClick.AddListener(this.switchStatus);
        }

        void switchStatus()
        {
            m_test.switchAnrMonitorStatus(m_ampsAnrStatus);
            m_ampsAnrStatus = !m_ampsAnrStatus;
        }
    }
}