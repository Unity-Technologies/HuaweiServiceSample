using System;
using HuaweiService.Auth;
using UnityEngine;
using UnityEngine.UI;

namespace HuaweiAuthDemo
{
    [Serializable]
    public class ActionBar
    {
        public RectTransform container;
        public RectTransform content;
        public Transform title;
        public Transform separationLine;
        public Button closeButton;
        public Button backButton;
    }

    [Serializable]
    public class Footer
    {
        public RectTransform rectTransform;
        public Button secondaryActionButton;
        public Transform separationLine;
    }

    /// <summary>
    /// Base class for all panels
    /// </summary>
    public abstract class AbstractPanel : MonoBehaviour
    {
        private Canvas canvas;

        public AbstractPanel ParentPanel;

        public ActionBar actionBar;
        public Footer secondaryActionFooter;

        void Awake()
        {
            canvas = gameObject.GetComponent<Canvas>();
        }

        public virtual void OpenPanel()
        {
            ShowPanel();
        }

        public void ClosePanel()
        {
            HidePanel();
        }

        public void Back()
        {
            HidePanel();
            ParentPanel?.ShowPanel();
        }

        protected virtual void ShowPanel()
        {
            canvas.enabled = true;
        }

        protected virtual void HidePanel()
        {
            // reset all input fields
            foreach (InputField inputField in GetComponentsInChildren<InputField>())
                inputField.text = null;
            canvas.enabled = false;
        }

        public void LogOutClick()
        {
            try
            {
                if (AGConnectAuth.getInstance().getCurrentUser() != null)
                {
                    AGConnectAuth.getInstance().signOut();
                    PanelController.popupinstance.ShowInfo("User has been sign out!");
                }
                else
                {
                    PanelController.popupinstance.ShowInfo("Don't need log out, no user");
                }
                
            } catch (System.Exception e)
            {
                Error error = new Error();
                error.message = e.Message;
                PanelController.popupinstance.ShowError(error);
            }
            
        }

        public bool haveCurrentUser(AbstractPanel parentPanel)
        {
            AGConnectUser user = AGConnectAuth.getInstance().getCurrentUser();
            if (user.getUid()==null||user.getUid() == "")
            {
                return false;
            }
            ParentPanel = parentPanel;
            PanelController.getInstance()
                .OpenPanel(PanelController.getInstance().GetComponentInChildren<UserAccount>());
            return true;
        }
    }
}