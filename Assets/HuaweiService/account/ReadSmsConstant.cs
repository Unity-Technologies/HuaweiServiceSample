using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.Account
{
    public class ReadSmsConstant
    {
        public const string READ_SMS_BROADCAST_ACTION = "com.huawei.hms.auth.api.phone.SMS_RETRIEVED";
        public const string EXTRA_SMS_MESSAGE = "com.huawei.hms.auth.api.phone.EXTRA_SMS_MESSAGE";
        public const string EXTRA_STATUS = "com.huawei.hms.auth.api.phone.EXTRA_STATUS";
        public const int FAIL = 2022;
        public const int TIMEOUT = 15;
        public const int SUCCESS = 0;
    }
}