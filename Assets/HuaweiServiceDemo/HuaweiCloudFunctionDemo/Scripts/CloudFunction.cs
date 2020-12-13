using System;
using System.Collections;
using System.Collections.Generic;
using HuaweiService;
using HuaweiService.CloudFunction;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

namespace HuaweiServiceDemo {
    public class CloudFunction : MonoBehaviour {
        public InputField Number1InputField;
        public InputField Number2InputField;
        public InputField TimeoutInoutField;

        public Text timeout;
        public static CloudFunction inst;
        public FunctionCallable func;
        public AGConnectFunction function = null;
        // Start is called before the first frame update
         public CloudFunction()
        {
            inst = this;
        }

        void Start () {
            function = AGConnectFunction.getInstance ();
            func = function.wrap ("test-$latest");
        }

        // Update is called once per frame
        void Update () { }

        public void OnSumButtonClick () {
            var number1 = int.Parse (this.Number1InputField.text);
            var number2 = int.Parse (this.Number2InputField.text);

            Number number = new Number {
                number1 = number1,
                number2 = number2
            };

            try {
                Task task = func.call (number);
                task.addOnCompleteListener (new FunctionCompleteListener<Sum> ((sumResult) => {
                    var val = sumResult.getResult ();
                    TestTip.Inst.ShowText ("Get Result: " + val);
                }));

            } catch (System.Exception exception) {
                TestTip.Inst.ShowText (exception.ToString ());
            }

        }

        public void OnSetTimeoutClick () {
            try {
                var timeout = Convert.ToInt64 (TimeoutInoutField.text);
                func.setTimeout (timeout, TimeUnit.MILLISECONDS);
                TestTip.Inst.ShowText ("SetTimeout. ");
            } catch (System.Exception e) {
                TestTip.Inst.ShowText ("SetTimeout Failed:  " + e.ToString ());
            }
        }

        public void OnGetTimeoutClick () {
            try {
                var timeout = Convert.ToString (func.getTimeout ());
                CloudFunction.inst.timeout.text = "Timeout: " + timeout;
                TestTip.Inst.ShowText ("GetTimeout: " + timeout);
            } catch (System.Exception e) {
                TestTip.Inst.ShowText ("GetTimeout Failed:  " + e.ToString ());
                throw;
            }
        }

        public void OnCallNoParamsClick () {
            Task task = function.wrap ("noparams-$latest").call();
            task.addOnCompleteListener (new FunctionCompleteListener ((result) => {
                TestTip.Inst.ShowText ("Call noParams result: " + result);
            }));
        }
        public void OnCloneClick () {
            FunctionCallable fc = func.clone (1000, TimeUnit.MILLISECONDS);
            if (fc.getTimeout () == 1000) {
                TestTip.Inst.ShowText ("Call Clone Succussfully.");
            } else {
                TestTip.Inst.ShowText ("Call Clone Failed.");
            }
        }

    }
}