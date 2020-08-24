using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace HuaweiHmsDemo
{
    public class TestBtn : MonoBehaviour
    {
        public Text t;
        public Button btn;
    
        public void Init(string text,UnityAction action)
        {
            t.text = text;
            btn.onClick.AddListener(()=>{tryAction(action);});
        }

        public static void tryAction(UnityAction action)
        {
            try
            {
                action.Invoke();
            }
            catch (System.Exception e)
            {
                TestTip.Inst.ShowText(e.ToString());
            }
        }
    }
}
