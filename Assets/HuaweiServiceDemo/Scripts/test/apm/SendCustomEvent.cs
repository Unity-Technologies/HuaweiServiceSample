using UnityEngine;
using UnityEngine.UI;


namespace ApmTest
{
    public class SendCustomEvent : MonoBehaviour
    {
        // Start is called before the first frame update
        public Button m_button;
        public ApmTest m_test;

        void Start()
        {
            Button btn = m_button.GetComponent<Button>();
            m_test = new ApmTest();
            btn.onClick.AddListener(m_test.sendCustomEvent);
        }
    }
}