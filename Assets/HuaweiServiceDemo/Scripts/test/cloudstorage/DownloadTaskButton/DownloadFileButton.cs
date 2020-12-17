using UnityEngine;
using UnityEngine.UI;


namespace CloudStorageTest{
	public class DownloadFileButton : MonoBehaviour
	{
	    // Start is called before the first frame update
	    public Button m_button;
	    public DownloadTaskTest m_test;

	    void Start()
	    {
	        Button btn = m_button.GetComponent<Button>();
	        m_test = new DownloadTaskTest();
	        btn.onClick.AddListener(downloadFile);        
	    }

	    private void downloadFile(){
		    m_test.run();
	    }
	}
}
