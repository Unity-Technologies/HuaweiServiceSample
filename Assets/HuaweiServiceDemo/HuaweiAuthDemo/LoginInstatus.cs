using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HuaweiAuthDemo
{


    public class LoginInstatus : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] private GameObject loginButton;

        public GameObject LoginButton
        {
            get { return loginButton; }
            private set { loginButton = value; }
        }

        [SerializeField] private GameObject accountButton;

        public GameObject AccountButton
        {
            get { return accountButton; }
            private set { accountButton = value; }
        }

        public void OnLogin()
        {
            LoginButton.GetComponent<Canvas>().enabled = false;
            AccountButton.GetComponent<Canvas>().enabled = true;
        }

        public void OnLogout()
        {
            LoginButton.GetComponent<Canvas>().enabled = true;
            AccountButton.GetComponent<Canvas>().enabled = false;
        }
    }
}
