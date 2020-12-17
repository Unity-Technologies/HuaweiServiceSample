using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService.CloudStorage
{
    public class ListResult_Data : IHmsBaseClass{
        public string name => "com.huawei.agconnect.cloud.storage.core.ListResult";
    }
    public class ListResult :HmsClass<ListResult_Data>
    {
        public ListResult (): base() { }
        public List getFileList() {
            return Call<List>("getFileList");
        }
        public List getDirList() {
            return Call<List>("getDirList");
        }
        public string getPageMarker() {
            return Call<string>("getPageMarker");
        }
    }
}