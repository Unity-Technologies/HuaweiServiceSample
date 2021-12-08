using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.version
{
    public class LibraryInfos_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.version.LibraryInfos";
    }
    public class LibraryInfos :HmsClass<LibraryInfos_Data>
    {
        public LibraryInfos (): base() { }
        public static LibraryInfos getInstance() {
            return CallStatic<LibraryInfos>("getInstance");
        }
        public void registerLibraryType(string arg0) {
            Call("registerLibraryType", arg0);
        }
    }
}