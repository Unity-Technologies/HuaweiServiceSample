using System;
using System.Collections;
using System.Collections.Generic;
using HuaweiService;
using HuaweiService.CloudFunction;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

namespace HuaweiServiceDemo {
    public class Number {
        public int number1;
        public int number2;
        public int sum () {
            return number1 + number2;
        }
    }
    public class Sum {
        public int result;
        public int getResult () {
            return result;
        }
    }
}