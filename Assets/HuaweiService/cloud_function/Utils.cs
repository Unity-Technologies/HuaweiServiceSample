using System;
using System.Collections.Generic;
using UnityEngine;

namespace HuaweiService.CloudFunction {

    public class JsonSerializer {
        public static string ToJson (object obj) {
            JsonModel model = new JsonModel (obj);
            return $"{{\"{model.ClassName}\":{model.ClassValue}}}";
        }

        public static T FromJson<T> (string json) {
            T m = JsonUtility.FromJson<T>(json);
            return m;
        }
    }

    public class JsonModel {
        public string ClassName { get; set; }
        public string ClassValue { get; set; }
        public JsonModel () { }
        public JsonModel (object obj) {
            ClassName = obj.GetType ().Name.ToLower ();
            ClassValue = JsonUtility.ToJson(obj);
        }

    }
}