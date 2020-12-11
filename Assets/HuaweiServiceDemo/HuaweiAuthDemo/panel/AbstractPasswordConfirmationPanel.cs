using HuaweiAuthDemo;
using TMPro;
using UnityEngine;

namespace HuaweiAuthDemo
{
    public abstract class AbstractPasswordConfirmationPanel : AbstractPanel
    {
        [SerializeField]
        protected TMP_InputField emailorPhone = default;

        [SerializeField]
        protected TMP_InputField password = default;

        [SerializeField]
        protected TMP_InputField passwordConfirmation = default;
        
        [SerializeField]
        protected TMP_InputField verifyCode = default;


        protected PrimaryActionButton m_Btn;
        protected PrimaryActionButton verify_Btn;

        protected PanelController m_MainController;

        private void Start()
        {
            m_MainController = PanelController.getInstance();
            var buttons = GetComponentsInChildren<PrimaryActionButton>();

            foreach (var button in buttons)
            {
                if (button.name == "Sign Up Button")
                {
                    m_Btn = button;
                }

                if (button.name == "verifyButton")
                {
                    verify_Btn = button;
                }
                
            }

            emailorPhone.text = null;
            password.text = null;
            passwordConfirmation.text = null;

            emailorPhone.onValueChanged.AddListener(OnValueChange);
            password.onValueChanged.AddListener(OnValueChange);
            passwordConfirmation.onValueChanged.AddListener(OnValueChange);
        }

        private void OnValueChange(string text)
        {
            if (FormUtils.AreInputFieldsNotEmpty(emailorPhone.text, password.text, passwordConfirmation.text))
            {
                if (!m_Btn.IsInteractable())
                    m_Btn.interactable = true;
            }
            else
            {
                if (m_Btn.IsInteractable())
                    m_Btn.interactable = false;
            }
        }
    }
}
