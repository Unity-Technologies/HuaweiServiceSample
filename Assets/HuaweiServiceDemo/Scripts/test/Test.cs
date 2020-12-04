using HuaweiService;
using UnityEngine.Events;

namespace HuaweiServiceDemo{
    public delegate void TestEvent(string text,UnityAction action);
    public abstract class Test<T> where T:new(){
        private static T _inst;
        public static T GetInstance(){
            return _inst == null?_inst = new T():_inst;
        }
        public abstract void RegisterEvent(TestEvent registerEvent);
    }
}