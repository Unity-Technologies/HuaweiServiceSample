using UnityEngine;
using HuaweiHms;

namespace HuaweiHmsDemo
{
    public class PushTest:Test<PushTest>
    {
        public PushTest(){
            SetListener();
        }
        public override void RegistEvent(TestEvent registEvent){
            registEvent("get token",GetToken);
            registEvent("delete token",DeleteToken);
            registEvent("set auto init enabled",SetAutoInitEnabled);
            registEvent("SubscribeTest",SubscribeTest);
            registEvent("UnSubscribeTest",UnSubscribeTest);
            registEvent("TurnOn",TurnOn);
            registEvent("TurnOff",TurnOff);
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