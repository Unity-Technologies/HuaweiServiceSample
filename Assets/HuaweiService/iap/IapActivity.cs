
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
        public static void setIntent(string intent){
            CallStatic("setIntent",intent);
        }
        public static void setConProductId(string id){
            CallStatic("setConProductId",id);
        }
        public static void setPriceType(int type){
            CallStatic("setPriceType",type);
        }
        public static void start(Activity activity){
            CallStatic("start",activity);
        }
    }
}