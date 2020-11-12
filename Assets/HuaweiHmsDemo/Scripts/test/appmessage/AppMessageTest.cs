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
            // appMessaging.setDisplayEnable(false);
            registerEvent("Show/Hide App Message", ShowAppMessage);
            registerEvent("Force Fetch", ForceFetch);
            registerEvent("Add OnClick Listener", AddOnClickListener);
            registerEvent("Add Dismiss Listener", AddDismissListener);
            registerEvent("Add Display Listener", AddDisplayListener);
            registerEvent("Register Custom view", RegisterCustomView);
            registerEvent("Remove Custom view", RemoveCustomView);
            registerEvent("Set Display Location", SetDisplayLocation);
            registerEvent("trigger", Trigger);
        }

        public void ShowAppMessage()
        {
            showApp = !showApp;
            appMessaging.setDisplayEnable(showApp);
            TestTip.Inst.ShowText($"set display to {showApp}");
        }
        
        public void ForceFetch()
        {
            appMessaging.setForceFetch();
            TestTip.Inst.ShowText("force fetch");
        }

        public void AddOnClickListener()
        {
            ClickListener listener = new ClickListener(); 
            appMessaging.addOnClickListener(listener);
            TestTip.Inst.ShowText("Add on click listener success");
        }
        
        public void AddDismissListener()
        {
            DismissListener listener = new DismissListener(); 
            appMessaging.addOnDismissListener(listener);
            TestTip.Inst.ShowText("Add on dismiss listener success");
        }
        
        public void AddDisplayListener()
        {
            DisplayListener listener = new DisplayListener(); 
            appMessaging.addOnDisplayListener(listener);
            TestTip.Inst.ShowText("Add on display listener success");
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

        public void SetDisplayLocation()
        {
            appMessaging.setDisplayLocation(MessageLocation.BOTTOM);
            TestTip.Inst.ShowText("set location");
        }

        public void Trigger()
        {
            appMessaging.trigger("justtest");
            TestTip.Inst.ShowText("trigger");
        }
    }
}