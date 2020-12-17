using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class Activity_Data : IHmsBaseClass{
        public string name => "android.app.Activity";
    }
    public class Activity :HmsClass<Activity_Data>
    {
        public const int DEFAULT_KEYS_DIALER = 1;
        public const int DEFAULT_KEYS_DISABLE = 0;
        public const int DEFAULT_KEYS_SEARCH_GLOBAL = 4;
        public const int DEFAULT_KEYS_SEARCH_LOCAL = 3;
        public const int DEFAULT_KEYS_SHORTCUT = 2;
        public const int RESULT_CANCELED = 0;
        public const int RESULT_FIRST_USER = 1;
        public const int RESULT_OK = -1;
        public Activity (): base() { }
        public Intent getIntent() {
            return Call<Intent>("getIntent");
        }
        public void startActivity(Intent arg0, Bundle arg1) {
            Call("startActivity", arg0, arg1);
        }
        public void startActivity(Intent arg0) {
            Call("startActivity", arg0);
        }
    }
}