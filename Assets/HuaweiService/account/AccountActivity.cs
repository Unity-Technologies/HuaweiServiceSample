namespace HuaweiService.Account
{
    public class AccountActivity_Data : IHmsBaseClass
    {
        public string name => "com.unity.hms.account.HmsAccountActivity";
    }

    public class AccountActivity : HmsClass<AccountActivity_Data>
    {

        public AccountActivity() : base() { }

        public static void setAuthParam(AccountAuthParams AuthParam)
        {
            CallStatic("setAuthParam", AuthParam);
        }

        public static void setIntent(string intent)
        {
            CallStatic("setIntent", intent);
        }
        public static void setAccessToken(string token)
        {
            CallStatic("setAccessToken", token);
        }
        public static void setCallback(AccountCallback callback)
        {
            CallStatic("setCallback", callback);
        }
        public static void setRequestCode(int requestCode)
        {
            CallStatic("setRequestCode", requestCode);
        }
        public static void start(Activity activity)
        {
            CallStatic("start", activity);
        }

    }
}