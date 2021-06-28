using UnityEngine;
using UnityEngine.UI;

namespace ApmTest
{
    public class StopLoadingSceneButton : MonoBehaviour
    {
        // Start is called before the first frame update
        public Button m_button;

        void Start()
        {
            Button btn = m_button.GetComponent<Button>();
            btn.onClick.AddListener(this.stopLoadingScene);
        }

        void stopLoadingScene()
        {
            GameApmTest test = new GameApmTest();
            Text text = this.GetComponentInChildren<Text>();
            test.stopLoadingScene(text);
        }
    }
}