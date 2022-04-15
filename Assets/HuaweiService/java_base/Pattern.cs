using UnityEngine;
using System.Collections.Generic;

namespace HuaweiService
{
    public class Pattern_Data : IHmsBaseClass{
        public string name => "java.util.regex.Pattern";
    }
    public class Pattern :HmsClass<Pattern_Data>
    {
        public const int UNIX_LINES = 1;
        public const int CASE_INSENSITIVE = 2;
        public const int COMMENTS = 4;
        public const int MULTILINE = 8;
        public const int LITERAL = 16;
        public const int DOTALL = 32;
        public const int UNICODE_CASE = 64;
        public const int CANON_EQ = 128;
        public const int UNICODE_CHARACTER_CLASS = 256;
        public Pattern (): base() { }
    }
}