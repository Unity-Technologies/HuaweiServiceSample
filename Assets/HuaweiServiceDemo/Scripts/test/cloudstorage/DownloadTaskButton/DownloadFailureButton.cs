using UnityEngine;
using UnityEngine.UI;


namespace CloudStorageTest{
	public class DownloadFailureButton : MonoBehaviour
	{
	    // Start is called before the first frame update
	    public Button m_button;
	    public DownloadTaskTest m_test;

	    void Start()
	    {
	        Button btn = m_button.GetComponent<Button>();
	        m_test = new DownloadTaskTest();
	        btn.onClick.AddListener(m_test.addOnFailureListenerTest);        
	    }
	}
}
