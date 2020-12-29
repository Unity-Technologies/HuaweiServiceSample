using System.Collections;
using System.Collections.Generic;
using HuaweiService;
using HuaweiService.appmessage;
using UnityEngine;

namespace HuaweiServiceDemo
{
    public partial class Util
    {
        public static void ShowAppMessage(AppMessage arg0, string message)
        {
            TestTip.Inst.ShowText(message);
            TestTip.Inst.ShowText($"id: {arg0.getId()}");
            TestTip.Inst.ShowText($"start time: {arg0.getStartTime()}");
            TestTip.Inst.ShowText($"end time: {arg0.getEndTime()}");
            TestTip.Inst.ShowText($"frequency type: {arg0.getFrequencyType()}");
        }
    }
    
    // Callback for a message tap.
    public class ClickListener : AGConnectAppMessagingOnClickListener
    {
        public override void onMessageClick(AppMessage arg0)
        {
           Util.ShowAppMessage(arg0, "Click Listener");
        }
    }

    // Callback for message closing.
    public class DismissListener : AGConnectAppMessagingOnDismissListener
    {
        public override void onMessageDismiss(AppMessage arg0, AGConnectAppMessagingCallback.DismissType arg1)
        {
            // base.onMessageDismiss(arg0, arg1);
            Util.ShowAppMessage(arg0, "Dismiss Listener");
            TestTip.Inst.ShowText(arg1.ToString());
        }
    }

    // Callback for message display.
    public class DisplayListener : AGConnectAppMessagingOnDisplayListener
    {
        public override void onMessageDisplay(AppMessage arg0)
        {
            // base.onMessageDisplay(arg0);
            Util.ShowAppMessage(arg0, "Display Listener");
        }
    }

    // Callback for message loading exceptions.
    public class OnErrorListener : AGConnectAppMessagingOnErrorListener
    {
        public override void onMessageError(AppMessage arg0)
        {
            TestTip.Inst.ShowText("message errors");
        }
    }

    public class CustomDisplayView : AGConnectAppMessagingDisplay
    {
        public override void displayMessage(AppMessage arg0, AGConnectAppMessagingCallback arg1)
        {
            Util.ShowAppMessage(arg0, "Custom Display");
            arg1.onMessageClick(arg0);
            arg1.onMessageDismiss(arg0, AGConnectAppMessagingCallback.DismissType.BACK_BUTTON);
            arg1.onMessageDisplay(arg0);
            arg1.onMessageError(arg0);
        }
    }

}