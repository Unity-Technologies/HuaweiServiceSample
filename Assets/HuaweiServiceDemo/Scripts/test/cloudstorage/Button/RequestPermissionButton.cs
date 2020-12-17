using HuaweiService;
using UnityEngine;
using UnityEngine.UI;

namespace CloudStorageTest
{
    public class RequestPermissionButton : MonoBehaviour
    {
        public Button m_button;

        private string[] permissions =
        {
            "android.permission.READ_EXTERNAL_STORAGE",
            "android.permission.WRITE_EXTERNAL_STORAGE",
        };

        void Start()
        {
            Button btn = m_button.GetComponent<Button>();
            btn.onClick.AddListener(request);
        }

        void request()
        {
            AndroidJavaClass javaUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = javaUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            Activity aaa = HmsUtil.GetHmsBase<Activity>(currentActivity);
            ActivityCompat.requestPermissions(aaa, permissions, 1);
        }
    }
}