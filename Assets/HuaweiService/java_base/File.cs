using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class File_Data : IHmsBaseClass{
        public string name => "java.io.File";
    }
    public class File :HmsClass<File_Data>
    {
        public const string separator = "/";
        public const string pathSeparator = ":";
        public File (string arg0, string arg1): base(arg0, arg1) { }
        public File (string arg0): base(arg0) { }
        public File (File arg0, string arg1): base(arg0, arg1) { }
        public File (URI arg0): base(arg0) { }
        public File (): base() { }
    }
}