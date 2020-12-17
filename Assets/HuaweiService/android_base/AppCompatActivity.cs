using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class AppCompatActivity_Data : IHmsBaseClass{
        public string name => "androidx.appcompat.app.AppCompatActivity";
    }
    public class AppCompatActivity :HmsClass<AppCompatActivity_Data>
    {
        public AppCompatActivity (int arg0): base(arg0) { }
        public AppCompatActivity (): base() { }
    }
}