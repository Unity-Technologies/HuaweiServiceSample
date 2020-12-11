using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HuaweiAuthDemo
{
    public class PanelController : MonoBehaviour
    {
        private AbstractPanel m_CurrentPanel;
        private static PanelController panelController;
        [SerializeField] public static PopupController popupinstance;
        public static UserAccount userInfo;

        void Awake()
        {
            if (popupinstance == null)
            {
                popupinstance = GameObject.Find("PopUp").GetComponent<PopupController>();
            }

            if (userInfo == null)
            {
                userInfo= GameObject.Find("UserAccount").GetComponent<UserAccount>();
            }
            

        }

        public void OpenPanel(AbstractPanel panel)
        {
            if (m_CurrentPanel == null || panel.name != m_CurrentPanel?.name)
            {
                panel.OpenPanel();

                m_CurrentPanel?.ClosePanel();
                m_CurrentPanel = panel;
            }
        }

        public void Start()
        {
            panelController = this;
        }

        public void OnBack()
        {
            m_CurrentPanel.Back();
            m_CurrentPanel = m_CurrentPanel.ParentPanel;
        }

        public void OnClose()
        {
            m_CurrentPanel?.ClosePanel();
            m_CurrentPanel = null;
        }

        public static PanelController getInstance()
        {
            return panelController == null
                ? GameObject.Find("Panels").GetComponent<PanelController>()
                : panelController;
        }
    }
}
