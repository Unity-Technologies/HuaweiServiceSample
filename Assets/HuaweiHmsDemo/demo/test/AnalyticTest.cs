using HuaweiHms;

namespace HuaweiHmsDemo
{
    public class AnalyticTest:Test<AnalyticTest>
    {
        private HiAnalyticsInstance instance;
        private bool enabled;
        public AnalyticTest()
        {
            instance = HiAnalytics.getInstance(new Context());
        }
        public override void RegistEvent(TestEvent registEvent){
            registEvent("SendProductId",SendProductId);
            registEvent("SendAnalyticEnable",SendAnalyticEnable);
            registEvent("CreateClearCache",CreateClearCache);
        }
        public void SendProductId()
        {
            Bundle b1 = new Bundle();
            b1.putString(HAParamType.PRODUCTID, "123456");
            instance.onEvent(HAEventType.ADDPRODUCT2CART, b1);
        }
        public void SendAnalyticEnable()
        {
            enabled = !enabled;
            instance.setAnalyticsEnabled(enabled);
            TestTip.Inst.ShowText(enabled?"ENABLED":"DISABLED");
        }
        public void CreateClearCache()
        {
            instance.clearCachedData();
        }
    }
}

