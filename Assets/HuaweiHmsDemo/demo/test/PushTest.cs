using System;
using UnityEngine;
using HuaweiHms;
using Exception = HuaweiHms.Exception;

namespace HuaweiHmsDemo
{
    public class PushTest:Test<PushTest>
    {
        public PushTest(){
            SetListener();
        }
        public override void RegisterEvent(TestEvent registerEvent){
            registerEvent("get AAID",() => SetAAID(true));
            registerEvent("delete AAID",() => SetAAID(false));
            registerEvent("get token",GetToken);
            registerEvent("delete token",DeleteToken);
            registerEvent("get auto init enabled", GetAutoInitEnabled);
            registerEvent("set auto init enabled",SetAutoInitEnabled);
            registerEvent("SubscribeTest",SubscribeTest);
            registerEvent("UnSubscribeTest",UnSubscribeTest);
            registerEvent("TurnOn",TurnOn);
            registerEvent("TurnOff",TurnOff);
            registerEvent("SendMessage",SendMessage);
        }

        public void SetAAID(bool isGet)
        {
            if (isGet)
            {
                Task id = HmsInstanceId.getInstance(new Context()).getAAID();
                id.addOnSuccessListener(new HmsSuccessListener<AAIDResult>((aaidResult) =>
                {
                    String aaId = aaidResult.getId();
                    TestTip.Inst.ShowText("getAAID success:" + aaId);
                })).addOnFailureListener(new HmsFailureListener((e) =>
                {
                    TestTip.Inst.ShowText($"getAAID failed: {e.toString()}");
                }));
            }
            else
            {
                try {
                    HmsInstanceId.getInstance(new Context()).deleteAAID();
                    TestTip.Inst.ShowText("delete aaid and its generation timestamp success.");
                } catch (System.Exception e) {
                    TestTip.Inst.ShowText("deleteAAID failed. " + e);
                }
            }
        }
        
        public bool status = true;
        public void GetToken(){
            string appId = AGConnectServicesConfig.fromContext(new Context()).getString("client/app_id");
            string token = HmsInstanceId.getInstance(new Context()).getToken(appId, "HCM");
            TestTip.Inst.ShowText(token);
            GUIUtility.systemCopyBuffer = token;
        }
        public void DeleteToken(){
            string appId = AGConnectServicesConfig.fromContext(new Context()).getString("client/app_id");
            HmsInstanceId.getInstance(new Context()).deleteToken(appId,"HCM");
        }
        public void SetListener(){
            PushListenerRegister.RegisterListener(new PServiceListener());
        }

        public void GetAutoInitEnabled()
        {
            TestTip.Inst.ShowText($"isAutoInitEnabled: {HmsMessaging.getInstance(new Context()).isAutoInitEnabled()}");
        } 
            
        public void SetAutoInitEnabled(){
            status = !status;
            HmsMessaging.getInstance(new Context()).setAutoInitEnabled(status);
            TestTip.Inst.ShowText(status?"ENABLED":"DISABLED");
        }

        public void SubscribeTest(){
            HmsMessaging.getInstance(new Context()).subscribe("test").addOnCompleteListener(new clistener());
        }
        public void UnSubscribeTest(){
            HmsMessaging.getInstance(new Context()).unsubscribe("test").addOnCompleteListener(new clistener());
        }
        public void TurnOn(){
            HmsMessaging.getInstance(new Context()).turnOnPush().addOnCompleteListener(new clistener());
        }
        public void TurnOff(){
            HmsMessaging.getInstance(new Context()).turnOffPush().addOnCompleteListener(new clistener());
        }

        public void SendMessage()
        {
            string messageId = DateTime.Now.Millisecond.ToString();
            RemoteMessage remoteMessage = new RemoteMessage.Builder("push.hcm.upstream")
                .setMessageId(messageId)
                .addData("key1", "data1")
                .addData("key2", "data2")
                .build();
            try {
                HmsMessaging.getInstance(new Context()).send(remoteMessage);
                TestTip.Inst.ShowText("sending...");
            } catch (System.Exception e) {
                TestTip.Inst.ShowText( "send exception:" + e);
            }
        }
    }
    public class clistener:OnCompleteListener {
        public override void onComplete(Task task){
            if(task.isSuccessful()){
                TestTip.Inst.ShowText("success");
            }else{
                TestTip.Inst.ShowText("fail"+ task.Call<AndroidJavaObject>("getException").Call<string>("getMessage"));
            }
        }
    }
    public class PServiceListener:IPushServiceListener {
        public override void onNewToken(string var1) {
            TestTip.Inst.ShowText(var1);
        }

        public override void onMessageSent(string arg0)
        {
            TestTip.Inst.ShowText( "onMessageSent called, Message id:" + arg0);
        }

        public override void onSendError(string arg0, BaseException arg1)
        {
            TestTip.Inst.ShowText("onSendError called, message id:" + arg0 + "+ ErrCode:"
                       + arg1.getErrorCode() + ", description:" + arg1.getMessage());
        }

        public override void onTokenError(BaseException arg0)
        {
            TestTip.Inst.ShowText($"on Token Exception: {arg0.getMessage()}");
        }

        public override void onMessageReceived(RemoteMessage message){
            string s = "getCollapseKey: " + message.getCollapseKey()
            + "\n getData: " + message.getData()
            + "\n getFrom: " + message.getFrom()
            + "\n getTo: " + message.getTo()
            + "\n getMessageId: " + message.getMessageId()
            + "\n getOriginalUrgency: " + message.getOriginalUrgency()
            + "\n getUrgency: " + message.getUrgency()
            + "\n getSendTime: " + message.getSentTime()
            + "\n getMessageType: " + message.getMessageType()
            + "\n getTtl: " + message.getTtl();
            TestTip.Inst.ShowText(message.getMessageId());
            TestTip.Inst.ShowText(s);
        }
    }
}