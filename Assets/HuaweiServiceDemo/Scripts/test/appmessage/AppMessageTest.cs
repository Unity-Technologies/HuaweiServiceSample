using HuaweiService.appmessage;
using Location = HuaweiService.appmessage.Location;

namespace HuaweiServiceDemo
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

        public bool showMessage = false;
        public bool fetchMessage = false;

        public static string EVENTNAME = "JUSTTEST";

        public override void RegisterEvent(TestEvent registerEvent)
        {
            registerEvent("Show/Hide App Message", ShowAppMessage);
            registerEvent("App Message State", ShowAppMessageState);
            registerEvent("Enable/Disable Fetch", EnableFetchMessage);
            registerEvent("Fetch Message State", EnableFetchMessageState);
            registerEvent("Force Fetch", ForceFetch);
            registerEvent("Add OnClick Listener", AddOnClickListener);
            registerEvent("Add Dismiss Listener", AddDismissListener);
            registerEvent("Add Display Listener", AddDisplayListener);
            registerEvent("Add Error Listener", AddErrorListener);
            registerEvent("Register Custom view", RegisterCustomView);
            registerEvent("Remove Custom view", RemoveCustomView);
            registerEvent("Set Display Location", SetDisplayLocation);
            registerEvent("trigger", Trigger);
        }

        // set message display enable state
        public void ShowAppMessage()
        {
            showMessage = !showMessage;
            appMessaging.setDisplayEnable(showMessage);
            TestTip.Inst.ShowText($"set display to {showMessage}");
        }

        // show message display enable state
        public void ShowAppMessageState()
        {
            var enable = appMessaging.isDisplayEnable();
            TestTip.Inst.ShowText($"is display enable {enable}");
        }

        // set fetch message enable state
        public void EnableFetchMessage()
        {
            fetchMessage = !fetchMessage;
            appMessaging.setFetchMessageEnable(fetchMessage);
            TestTip.Inst.ShowText($"set fetch message to {fetchMessage}");
        }

        // show fetch message enable state
        public void EnableFetchMessageState()
        {
            var enable = appMessaging.isFetchMessageEnable();
            TestTip.Inst.ShowText($"is fetch enable: {enable}");
        }

        // force fetch message
        public void ForceFetch()
        {
            appMessaging.setForceFetch();
            TestTip.Inst.ShowText("force fetch");
        }

        // Adds a listener for message tap events.
        public void AddOnClickListener()
        {
            ClickListener listener = new ClickListener();
            appMessaging.addOnClickListener(listener);
            TestTip.Inst.ShowText("Add on click listener success");
        }

        // Adds a listener for message closing events.
        public void AddDismissListener()
        {
            DismissListener listener = new DismissListener();
            appMessaging.addOnDismissListener(listener);
            TestTip.Inst.ShowText("Add on dismiss listener success");
        }

        // Adds a listener for message display events.
        public void AddDisplayListener()
        {
            DisplayListener listener = new DisplayListener();
            appMessaging.addOnDisplayListener(listener);
            TestTip.Inst.ShowText("Add on display listener success");
        }
        
        // Adds a listener for message error.
        public void AddErrorListener()
        {
            OnErrorListener listener = new OnErrorListener();
            appMessaging.addOnErrorListener(listener);
            TestTip.Inst.ShowText("Add on error listener success");
        }

        // Adds a custom in-app message.
        public void RegisterCustomView()
        {
            CustomDisplayView view = new CustomDisplayView();
            appMessaging.addCustomView(view);
            TestTip.Inst.ShowText("Add custom view success");
        }

        // Deletes custom in-app message
        public void RemoveCustomView()
        {
            appMessaging.removeCustomView();
            TestTip.Inst.ShowText("remove custom view success");
        }

        // Sets the display position of a pop-up or image message
        public void SetDisplayLocation()
        {
            appMessaging.setDisplayLocation(Location.BOTTOM);
            TestTip.Inst.ShowText("set location");
        }

        // Triggers a custom event
        public void Trigger()
        {
            appMessaging.trigger(EVENTNAME);
            TestTip.Inst.ShowText("trigger");
        }
    }
}