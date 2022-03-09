
namespace HuaweiService.IAP
{
    public class IapActivity_Data : IHmsBaseClass{
        public string name => "com.unity.hms.iap.HmsIapActivity";
    }
    public class IapActivity :HmsClass<IapActivity_Data>
    {
        public IapActivity (): base() { }
        public static void setCallback(IapCallback callback){
            CallStatic("setCallback",callback);
        }
    }
}