using UnityEngine;
using UnityEngine.UI;

namespace CloudStorageTest
{
	public class StreamDownloadButton : MonoBehaviour
	{
		// Start is called before the first frame update
		public Button m_button;
		public StreamDownloadTest m_test;

		void Start()
		{
			Button btn = m_button.GetComponent<Button>();
			m_test = new StreamDownloadTest();
			btn.onClick.AddListener(m_test.run);        
		}
	}
}
