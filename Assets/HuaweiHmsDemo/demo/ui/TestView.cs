using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HuaweiHmsDemo
{
    public class TestView : MonoBehaviour
    {
        public bool AdsEnabled;
        public bool AnalyticEnabled;
        public bool PushEnabled;
        public bool LocationEnabled;
        public Transform btnParent;
        public GameObject btnPrefab;
        public TestTip testTip;
        private int index = 1;
        public int start = 0;
        public int space = 40;
        public void Start()
        {
            Initial();
        }
        public void Initial(){
            Screen.SetResolution (1080, 2340,true); // hack
            if(AdsEnabled){
                AdsTest.GetInstance().RegistEvent(RegistEvent);
            }
            if(AnalyticEnabled){
                AnalyticTest.GetInstance().RegistEvent(RegistEvent);
            }
            if(PushEnabled){
                PushTest.GetInstance().RegistEvent(RegistEvent);
            }
            if(LocationEnabled){
                LocationTest.GetInstance().RegistEvent(RegistEvent);
            }
        }

        public void RegistEvent(string text,UnityAction action)
        {
            var btnClone = Instantiate(btnPrefab, btnParent);
            var btn = btnClone.GetComponent<TestBtn>();
            btn.transform.localPosition = new Vector3(0, start - space * index, 0);
            btn.Init(text,action);
            index++;
        }
    }
}