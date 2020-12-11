using UnityEngine;
using System.Collections.Generic;
using HuaweiService;

namespace HuaweiService.Auth
{
    public class Parcelable_Data : IHmsBaseClass{
        public string name => "android.os.Parcelable";
    }
    public class Parcelable :HmsClass<Parcelable_Data>
    {
        public const int CONTENTS_FILE_DESCRIPTOR = 1;
        public const int PARCELABLE_WRITE_RETURN_VALUE = 1;
        public Parcelable (): base() { }
    
        public class Creator_Data : IHmsBaseClass{
            public string name => "android.os.Parcelable$Creator";
        }
        public class Creator :HmsClass<Creator_Data>
        {
            public Creator (): base() { }
            public AndroidJavaObject createFromParcel(Parcel arg0) {
                return Call<AndroidJavaObject>("createFromParcel", arg0);
            }
            public AndroidJavaObject[] newArray(int arg0) {
                return Call<AndroidJavaObject[]>("newArray", arg0);
            }
        }
    }
}