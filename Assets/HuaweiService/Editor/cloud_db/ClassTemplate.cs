using System;
using UnityEngine;

namespace HuaweiService.CloudDB.Editor {
    public class ClassTemplate {
        public System.Collections.Generic.List<Permissions> permissions;
        public System.Collections.Generic.List<ObjectType> objectTypes;
    }
    [Serializable]
    public class Permissions {
        public System.Collections.Generic.List<PermissionInfo> permissions;
        public string objectTypeName;
    }
    [Serializable]
    public class PermissionInfo {
        public string role;
        public string[] rights;
    }
    [Serializable]
    public class ObjectType {
        public string[] indexs;
        public string objectTypeName;
        public System.Collections.Generic.List<Field> fields;
    }

    [Serializable]
    public class Field {
        public bool isNeedEncrypt;
        public string fieldName;
        public bool notNull;
        public bool belongPrimaryKey;
        public string fieldType;
        public string defaultValue = "";
        public string getFieldName () { return fieldName.Substring (0, 1).ToUpper () + fieldName.Substring (1); }
        public string getFieldType () {
            string typeStr = "string";
            switch (fieldType) {
                case "Integer":
                    typeStr = "int";
                    break;
                case "Long":
                    typeStr = "long";
                    break;
                case "Text":
                    typeStr = "Text";
                    break;
                case "Date":
                    typeStr = "Date";
                    break;
                case "String":
                    typeStr = "string";
                    if(defaultValue.Length > 0) defaultValue = $"\"{defaultValue}\"";
                    break;
                case "Double":
                    typeStr = "double";
                    break;
                case "Float":
                    typeStr = "float";
                    break;
                case "Short":
                    typeStr = "short";
                    break;
                case "Byte":
                    typeStr = "byte";
                    break;
                case "Boolean":
                    typeStr = "bool";
                    break;
                case "ByteArray":
                    typeStr = "sbyte[]";
                    break;
            }
            return typeStr;
        }

        public string getInitializer () {
            string typeStr = "value";
            switch (fieldType) {
                case "Integer":
                    typeStr = "new Integer(value)";
                    break;
                case "Long":
                    typeStr = "new Long(value)";
                    break;
                case "Date":
                    break;
                case "String":
                    break;
                case "Double":
                    typeStr = "new Double(value)";
                    break;
                case "Text":
                    typeStr = "new Text()";
                    break;
                case "Float":
                    typeStr = "new Float(value)";
                    break;
                case "Short":
                    typeStr = "new Short(value)";
                    break;
                case "Byte":
                    typeStr = "new Byte(value)";
                    break;
                case "Boolean":
                    typeStr = "new Boolean(value)";
                    break;
                case "ByteArray":
                    break;
            }
            return typeStr;
        }
    }
}