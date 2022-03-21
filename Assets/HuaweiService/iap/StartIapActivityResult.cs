using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.IAP
{
    public class StartIapActivityResult_Data : IHmsBaseClass{
        public string name => "com.huawei.hms.iap.entity.StartIapActivityResult";
    }
    public class StartIapActivityResult :HmsClass<StartIapActivityResult_Data>
    {
        public StartIapActivityResult (Intent arg0): base(arg0) { }
        public StartIapActivityResult (): base() { }
        public void startActivity(Activity arg0) {
            Call("startActivity", arg0);
        }
    }
}