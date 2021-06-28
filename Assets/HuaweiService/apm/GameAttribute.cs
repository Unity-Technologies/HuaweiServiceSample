using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.apm
{
    public class GameAttribute_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.apms.game.GameAttribute";
    }
    public class GameAttribute :HmsClass<GameAttribute_Data>
    {
        public GameAttribute(string arg0, LoadingState arg1) : base(arg0, arg1)
        {
            this.obj = this.obj;
            
        }
        public GameAttribute() : base()
        {
            this.obj = this.obj;
        }
        public LoadingState getLoadingState() {
            return Call<LoadingState>("getLoadingState");
        }
        public void setLoadingState(LoadingState arg0) {
            Call("setLoadingState", arg0);
        }
        public string getScene() {
            return Call<string>("getScene");
        }
    
        public class LoadingState_Data : IHmsBaseClass{
            public string name => "com.huawei.agconnect.apms.game.GameAttribute$LoadingState";
        }
        public class LoadingState :HmsClass<LoadingState_Data>
        {
            public static LoadingState NOT_LOADING => HmsUtil.GetStaticValue<LoadingState>("NOT_LOADING");
        
            public static LoadingState LOADING => HmsUtil.GetStaticValue<LoadingState>("LOADING");
        
            public LoadingState (string arg0, int arg1, int arg2): base(arg0, arg1, arg2) { }
            public LoadingState (): base() { }
        }
    }
}