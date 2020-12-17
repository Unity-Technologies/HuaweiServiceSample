using UnityEngine;
using UnityEngine.UI;


namespace CloudStorageTest{
	public class StorageExceptionButton : MonoBehaviour
	{
	    // Start is called before the first frame update
	    public Button m_button;
	    public StorageExceptionTest m_test;

	    void Start()
	    {
	        Button btn = m_button.GetComponent<Button>();
	        m_test = new StorageExceptionTest();
	        btn.onClick.AddListener(m_test.run);        
	    }
	}
}
