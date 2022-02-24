
using HuaweiServiceDemo;

namespace HuaweiService.Account
{
    public class AccountActivity_Data : IHmsBaseClass{
        public string name => "com.hms.hms_account_activity.HmsAccountActivity";
    }

    public class AccountActivity :HmsClass<AccountActivity_Data>
    {

        public AccountActivity (): base() { }
        
        public static void setAuthParam(AccountAuthParams AuthParam){
            CallStatic("setAuthParam",AuthParam);
        }
        
        public static void setIntent(string intent){
            CallStatic("setIntent",intent);
        }
        public static void setAccessToken(string token){
            CallStatic("setAccessToken",token);
        }
        public static void setPhoneNumber(string phoneNumber){
            CallStatic("setPhoneNumber",phoneNumber);
        }
        public static void setCallback(AccountCallback callback){
            TestTip.Inst.ShowText($"AccountActivity setCallback");
            CallStatic("setCallback",callback);
        }
        public static void start(){
            CallStatic("start");
        }
        public static AuthAccount getAuthAccount(){
            return CallStatic<AuthAccount>("getAuthAccount");
        }

    }
}