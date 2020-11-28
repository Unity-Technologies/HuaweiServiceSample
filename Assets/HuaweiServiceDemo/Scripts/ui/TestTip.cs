using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HuaweiHmsDemo
{
    public class TestTip : MonoBehaviour
    {
        public static TestTip Inst;
        public Text text;
        private bool dirty = false;
        private string word = "";
        public TestTip()
        {
            Inst = this;
        }

        public void ShowText(string t)
        {
            word += (t + "\n");
            dirty = true;
        }

        public void Update(){
            if(dirty){
                dirty = false;
                text.text = word;
            }
        }
    }
}