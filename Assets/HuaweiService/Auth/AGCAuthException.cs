using UnityEngine;
using System.Collections.Generic;
using HuaweiService;

namespace HuaweiService.Auth
{
    public class AGCAuthException_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.auth.AGCAuthException";
    }
    public class AGCAuthException :HmsClass<AGCAuthException_Data>
    {
        public const int NULL_TOKEN = 1;
        public const int NOT_SIGN_IN = 2;
        public const int USER_LINKED = 3;
        public const int USER_UNLINKED = 4;
        public const int ALREADY_SIGN_IN_USER = 5;
        public const int EMAIL_VERIFICATION_IS_EMPTY = 6;
        public const int PHONE_VERIFICATION_IS_EMPTY = 7;
        public const int INVALID_EMAIL = 203817223;
        public const int INVALID_PHONE = 203817224;
        public const int GET_UID_ERROR = 203817728;
        public const int UID_PRODUCTID_NOT_MATCH = 203817729;
        public const int GET_USER_INFO_ERROR = 203817730;
        public const int AUTH_METHOD_NOT_SUPPORT = 203817732;
        public const int PRODUCT_STATUS_ERROR = 203817744;
        public const int PASSWORD_VERIFICATION_CODE_OVER_LIMIT = 203817811;
        public const int INVALID_TOKEN = 203817984;
        public const int INVALID_ACCESS_TOKEN = 203817985;
        public const int INVALID_REFRESH_TOKEN = 203817986;
        public const int TOKEN_AND_PRODUCTID_NOT_MATCH = 203817987;
        public const int AUTH_METHOD_IS_DISABLED = 203817988;
        public const int FAIL_TO_GET_THIRD_USER_INFO = 203817989;
        public const int FAIL_TO_GET_THIRD_USER_UNION_ID = 203817990;
        public const int ACCESS_TOKEN_OVER_LIMIT = 203817991;
        public const int FAIL_TO_USER_LINK = 203817992;
        public const int FAIL_TO_USER_UNLINK = 203817993;
        public const int ANONYMOUS_SIGNIN_OVER_LIMIT = 203818019;
        public const int INVALID_APPID = 203818020;
        public const int INVALID_APPSECRET = 203818021;
        public const int GET_QQ_USERINFO_ERROR = 203818023;
        public const int QQINFO_RESPONSE_IS_NULL = 203818024;
        public const int GET_QQ_UID_ERROR = 203818025;
        public const int PASSWORD_VERIFY_CODE_ERROR = 203818032;
        public const int GOOGLE_RESPONSE_NOT_EQUAL_APPID = 203818033;
        public const int SIGNIN_USER_STATUS_ERROR = 203818036;
        public const int SIGNIN_USER_PASSWORD_ERROR = 203818037;
        public const int PROVIDER_USER_HAVE_BEEN_LINKED = 203818038;
        public const int PROVIDER_HAVE_LINKED_ONE_USER = 203818039;
        public const int FAIL_GET_PROVIDER_USER = 203818040;
        public const int CANNOT_UNLINK_ONE_PROVIDER_USER = 203818041;
        public const int VERIFY_CODE_INTERVAL_LIMIT = 203818048;
        public const int VERIFY_CODE_EMPTY = 203818049;
        public const int VERIFY_CODE_LANGUAGE_EMPTY = 203818050;
        public const int VERIFY_CODE_RECEIVER_EMPTY = 203818051;
        public const int VERIFY_CODE_ACTION_ERROR = 203818052;
        public const int VERIFY_CODE_TIME_LIMIT = 203818053;
        public const int ACCOUNT_PASSWORD_SAME = 203818064;
        public const int PASSWORD_STRENGTH_LOW = 203818065;
        public const int UPDATE_PASSWORD_ERROR = 203818066;
        public const int PASSWORD_SAME_AS_BEFORE = 203818067;
        public const int PASSWORD_IS_EMPTY = 203818068;
        public const int PASSWORD_TOO_LONG = 203818071;
        public const int SENSITIVE_OPERATION_TIMEOUT = 203818081;
        public const int ACCOUNT_HAVE_BEEN_REGISTERED = 203818082;
        public const int UPDATE_ACCOUNT_ERROR = 203818084;
        public const int USER_NOT_REGISTERED = 203818087;
        public const int VERIFY_CODE_ERROR = 203818129;
        public const int USER_HAVE_BEEN_REGISTERED = 203818130;
        public const int REGISTER_ACCOUNT_IS_EMPTY = 203818132;
        public const int VERIFY_CODE_FORMAT_ERROR = 203818134;
        public const int VERIFY_CODE_AND_PASSWORD_BOTH_NULL = 203818135;
        public const int SEND_EMAIL_FAIL = 203818240;
        public const int SEND_MESSAGE_FAIL = 203818241;
        public const int CONFIG_LOCK_TIME_ERROR = 203818261;
        public AGCAuthException (string arg0, int arg1): base(arg0, arg1) { }
        public AGCAuthException (): base() { }
    }
}