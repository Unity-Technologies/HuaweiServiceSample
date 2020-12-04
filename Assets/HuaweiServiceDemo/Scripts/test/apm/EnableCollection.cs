using UnityEngine;
using UnityEngine.UI;


namespace ApmTest
{
    public class EnableCollection : MonoBehaviour
    {
        // Start is called before the first frame update
        public Button m_button;
        public ApmTest m_test;
        private bool m_collectionStatus;

        void Start()
        {
            m_collectionStatus = false;
            Button btn = m_button.GetComponent<Button>();
            m_test = new ApmTest();
            btn.onClick.AddListener(this.switchStatus);
        }

        void switchStatus()
        {
            m_test.switchCollectionStatus(m_collectionStatus);
            m_collectionStatus = !m_collectionStatus;
        }
    }
}