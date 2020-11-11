using System.Security.Cryptography;
using HuaweiHms;
using UnityEngine;

namespace HuaweiHmsDemo
{
    public class AppMessageTest : Test<AppMessageTest>
    {
        private AGConnectAppMessaging appMessaging
        {
            get
            {
                if (_appMessaging == null)
                {
                    _appMessaging = AGConnectAppMessaging.getInstance(); 
                }

                return _appMessaging;
            }
        }

        private AGConnectAppMessaging _appMessaging;

        public bool showApp = false;

        public override void RegisterEvent(TestEvent registerEvent)
        {
            registerEvent("Show/Hide App Message", ShowAppMessage);
            registerEvent("Add OnClick Listener", AddOnClickListener);
            registerEvent("Register Custom view", RegisterCustomView);
            registerEvent("Remove Custom view", RemoveCustomView);
        }

        public void ShowAppMessage()
        {
            showApp = !showApp;
            appMessaging.setDisplayEnable(showApp);
            TestTip.Inst.ShowText($"set display to {showApp}");
        }

        public void AddOnClickListener()
        {
            ClickListener listener = new ClickListener(); 
            appMessaging.addOnClickListener(listener);
            TestTip.Inst.ShowText("Add on click listener success");
        }

        public void RegisterCustomView()
        {
            CustomDisplayView view = new CustomDisplayView(); 
            appMessaging.addCustomView(view);
            TestTip.Inst.ShowText("Add custom view success");
        }

        public void RemoveCustomView()
        {
            appMessaging.removeCustomView();
            TestTip.Inst.ShowText("remove custom view success");
        }
    }
}