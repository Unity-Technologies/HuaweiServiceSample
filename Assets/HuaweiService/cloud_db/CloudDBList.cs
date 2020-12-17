using System;
using HuaweiService;
using UnityEngine;

namespace HuaweiService.CloudDB {
    public interface IDatabaseModel {
		AndroidJavaObject GetObj();
        void SetObj(AndroidJavaObject arg0);
	}
    public class List<T> : List where T : IDatabaseModel{
        public bool add (T arg0) {
            AndroidJavaObject obj = arg0.GetObj();
            return add (obj);
        }

        public void add (int arg0, T arg1) {
            AndroidJavaObject obj = arg1.GetObj();
            add(arg0, obj);
        }

        public int Size () {
            return Call<int> ("size");
        }

    }
}