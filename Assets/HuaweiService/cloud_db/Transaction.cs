using System;
using System.Collections.Generic;
using UnityEngine;

namespace HuaweiService.CloudDB {
    public delegate bool apply (Transaction t);

    public class Transaction_Data : IHmsBaseClass {
        public string name => "com.huawei.agconnect.cloud.database.Transaction";
    }
    public class Transaction : HmsClass<Transaction_Data> {
        public Transaction () {
        }
        public List executeQuery (CloudDBZoneQuery arg0) {
            return Call<List> ("executeQuery", arg0);
        }
        public Transaction executeUpsert<T> (List<T> arg0) where T : IDatabaseModel {
            return Call<Transaction> ("executeUpsert", arg0);
        }
        public Transaction executeDelete (List arg0)  {
            return Call<Transaction> ("executeDelete", arg0);
        }
        public bool isTransactionEmpty () {
            return Call<bool> ("isTransactionEmpty");
        }

        public class Function : AndroidJavaProxy {
            private apply cb;

            private static string _name = "com.huawei.agconnect.cloud.database.Transaction$Function";
            public Function (apply cb) : base (_name) {
                this.cb = cb;
            }
            public bool apply (AndroidJavaObject arg0) {
                Type type = typeof (Transaction);
                Transaction input = (Transaction) Activator.CreateInstance (type);
                input.obj = arg0;
                return this.cb.Invoke (input);
            }
        }
    }
}