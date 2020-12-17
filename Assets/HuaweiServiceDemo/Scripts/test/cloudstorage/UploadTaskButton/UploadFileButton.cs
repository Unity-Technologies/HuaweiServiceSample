using UnityEngine;
using UnityEngine.UI;


namespace CloudStorageTest{
	public class UploadFileButton : MonoBehaviour
	{
	    // Start is called before the first frame update
	    public Button m_button;
	    public UploadTaskTest m_test;

	    void Start()
	    {
	        Button btn = m_button.GetComponent<Button>();
	        m_test = new UploadTaskTest();
	        btn.onClick.AddListener(uploadFile);        
	    }

	    private void uploadFile(){
		    string name = "unityTest.data";
	    	int size = 10;
	        m_test.uploadFile(name, size);
	    }
	}
}
