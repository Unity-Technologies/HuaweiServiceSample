using System.Collections;
using System.Collections.Generic;
using HuaweiHms;
using UnityEngine;

namespace HuaweiHmsDemo
{
    public class ClickListener : AGConnectAppMessagingOnClickListener
    {
        public override void onMessageClick(AppMessage arg0)
        {
            // base.onMessageClick(arg0);
            TestTip.Inst.ShowText($"{arg0.getId()}");
            TestTip.Inst.ShowText($"{arg0.getEndTime()}");
            TestTip.Inst.ShowText($"{arg0.getFrequencyType()}");
        }
    }

    public class CustomDisplayView : AGConnectAppMessagingDisplay
    {
        public override void displayMessage(AppMessage arg0, AGConnectAppMessagingCallback arg1)
        {
            // base.displayMessage(arg0, arg1);
            TestTip.Inst.ShowText($"id: {arg0.getId()}");
            TestTip.Inst.ShowText($"start     time: {arg0.getStartTime()}");
            TestTip.Inst.ShowText($"end time: {arg0.getEndTime()}");
            TestTip.Inst.ShowText($"frequency type: {arg0.getFrequencyType()}");
        }
    }

}