using UnityEngine;
using UnityEngine.UI;
using System;
using HuaweiService;

namespace ApmTest
{
    public class AddCusttomTraceButton : MonoBehaviour
    {
        // Start is called before the first frame update
        public Button m_button;
        public ApmTest m_test;

        void Start()
        {
            Button btn = m_button.GetComponent<Button>();
            btn.onClick.AddListener(this.AttributeTest);
        }

        public void AttributeTest()
        {
            SingReturnTest.GetMax(6, 6);
            SingReturnTest.GetMin(6, 7);
            Debug.Log("SingReturnTest finished!");
            MultiReturnTest.GetMax(6, 7, 8);
            Debug.Log("MultiReturnTest finished!");
            try
            {
                ThrowExceptionTest.GetMax(10, 6);
                ThrowExceptionTest.GetMax(6, 10);
            }
            catch (System.Exception e)
            {
                Debug.Log(e);
                Debug.Log("ThrowExceptionTest finished!");
            }
        }
    }


    public class SingReturnTest
    {
        [AddCustomTrace("SingReturnTest", true)]
        public static int GetMax(int a, int b)
        {
            Debug.LogFormat("SingReturnTest.GetMax: a = {0}, b = {1}", a, b);
            return a > b ? a : b;
        }

        [AddCustomTrace("EnableClose", false)]
        public static int GetMin(int a, int b)
        {
            Debug.LogFormat("SingReturnTest.GetMin: a = {0}, b = {1}", a, b);
            return a < b ? a : b;
        }
    }


    public class MultiReturnTest
    {
        [AddCustomTrace("MultiReturnTest", true)]
        public static int GetMax(int a, int b, int c)
        {
            Debug.LogFormat("MultiReturnTest.GetMax: a = {0}, b = {1}, c={2}", a, b, c);
            if (a > b)
            {
                if (a > c)
                {
                    return a;
                }
                else
                {
                    return c;
                }
            }
            else
            {
                if (b > c)
                {
                    return b;
                }
                else
                {
                    return c;
                }
            }
        }
    }

    public class ThrowExceptionTest
    {
        [AddCustomTrace("ThrowExceptionTest")]
        public static int GetMax(int a, int b)
        {
            if (a > b)
                return a;
            else
                throw new ArgumentNullException("a shoud larger than b.");
        }
    }
}