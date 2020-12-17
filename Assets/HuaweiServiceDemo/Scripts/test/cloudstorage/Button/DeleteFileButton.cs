using UnityEngine;
using UnityEngine.UI;

namespace CloudStorageTest
{
    public class DeleteFileButton : MonoBehaviour
    {
        // Start is called before the first frame update
        public Button m_button;
        public DeleteFileTest m_test;

        void Start()
        {
            Button btn = m_button.GetComponent<Button>();
            m_test = new DeleteFileTest();
            btn.onClick.AddListener(m_test.run);
        }
    }
}