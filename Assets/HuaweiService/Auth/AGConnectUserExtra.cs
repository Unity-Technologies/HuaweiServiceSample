using HuaweiService;
namespace HuaweiService.Auth
{
      public class AGConnectUserExtra_Data : IHmsBaseClass{
            public string name => "com.huawei.agconnect.auth.AGConnectUserExtra";
        }
        public class AGConnectUserExtra :HmsClass<AGConnectUserExtra_Data>
        {
            public AGConnectUserExtra (): base() { }
            public string getCreateTime() {
                return Call<string>("getCreateTime");
            }
            public string getLastSignInTime() {
                return Call<string>("getLastSignInTime");
            }
        }
        
    }
