using UnityEngine;
using UnityEngine.UI;


namespace CloudStorageTest
{
    public class FileMetadataButton : MonoBehaviour
    {
        // Start is called before the first frame update
        public Button m_button;
        public FileMetadataTest m_test;

        void Start()
        {
            Button btn = m_button.GetComponent<Button>();
            m_test = new FileMetadataTest();
            btn.onClick.AddListener(m_test.run);
        }
    }
}