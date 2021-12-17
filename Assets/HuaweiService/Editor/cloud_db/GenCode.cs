using System.IO;
using UnityEngine;

namespace HuaweiService.CloudDB.Editor {
    public class GenCode {
        public string ObjectTypeFilePath;
        public string PackageName;
        public string NamespaceName;
        public string ExportFileDir;
        public ClassTemplate template;

        public void Init (string arg0, string arg1, string arg2, string arg3) {
            PackageName = arg0;
            ObjectTypeFilePath = arg1;
            NamespaceName = arg2;
            ExportFileDir = arg3;
            LoadJson ();
        }
        public void LoadJson () {
            try {
                if (Directory.Exists (ExportFileDir)) {
                    Directory.Delete (ExportFileDir, true);
                }
                Directory.CreateDirectory (ExportFileDir);
                using (StreamReader r = new StreamReader (ObjectTypeFilePath)) {
                    string json = r.ReadToEnd ();
                    template = JsonUtility.FromJson<ClassTemplate> (json);
                    GenerateObjectTypeInfoHelper ();
                    foreach (ObjectType objectType in template.objectTypes) {
                        GenerateModels (objectType);
                    }
                }
            } catch (System.Exception e) {
                Debug.Log ("Parse Json File Error: " + e.Message);
            }
        }

        public void GenerateObjectTypeInfoHelper () {
            string objectTypeName = "ObjectTypeInfoHelper";
            string path = ExportFileDir + $"/{objectTypeName}.cs";
            if (System.IO.File.Exists (path) == false) { // do not overwrite
                try {
                    using (StreamWriter fs = new StreamWriter (path)) {
                        GenerateHeader (fs);
                        fs.WriteLine ($"\tpublic class {objectTypeName}_Data : IHmsBaseClass" + " {");
                        fs.WriteLine ($"\t\tpublic string name => \"{PackageName}.{objectTypeName}\";");
                        fs.WriteLine ("\t}");
                        fs.WriteLine ($"\tpublic class {objectTypeName} : HmsClass<{objectTypeName}_Data>" + " {");
                        GenerateInitializer (fs, objectTypeName);
                        fs.WriteLine ($"\t\tpublic static ObjectTypeInfo getObjectTypeInfo() {{");
                        fs.WriteLine ($"\t\treturn CallStatic<ObjectTypeInfo>(\"getObjectTypeInfo\");");
                        fs.WriteLine ("\t\t}");
                        fs.WriteLine ("\t}");
                        fs.WriteLine ("}");
                    }
                } catch (System.Exception e) {
                    Debug.Log ("Generate Error: " + e.Message);
                }
            }
        }

        public void GenerateModels (ObjectType objectType) {
            string objectTypeName = objectType.objectTypeName;
            Field[] fields = objectType.fields.ToArray();

            string path = ExportFileDir + $"/{objectTypeName}.cs";
            Debug.LogFormat ("Generating Class: {0}.", objectTypeName);
            if (System.IO.File.Exists (path) == false) { // do not overwrite
                try {
                    using (StreamWriter fs = new StreamWriter (path)) {
                        GenerateHeader (fs);
                        GenerateClass (fs, objectTypeName);
                        foreach (Field field in fields) {
                            GenerateField (fs, field);
                        }
                        GenerateInitializer (fs, objectTypeName);
                        foreach (Field field in fields) {
                            GenerateMethod (fs, field);
                        }
                        GenerateBottom (fs);
                    }
                } catch (System.Exception e) {
                    Debug.Log ("Generate Error: " + e.Message);
                }
            }
        }

        public void GenerateHeader (StreamWriter fs) {
            fs.WriteLine ("using HuaweiService;");
            fs.WriteLine ("using HuaweiService.CloudDB;");
            fs.WriteLine ("using UnityEngine;");
            fs.WriteLine ($"\rnamespace {NamespaceName} " + "{");
        }

        public void GenerateClass (StreamWriter fs, string className) {
            fs.WriteLine ($"\tpublic class {className}_Data : IHmsBaseClass" + " {");
            fs.WriteLine ($"\t\tpublic string name => \"{PackageName}.{className}\";");
            fs.WriteLine ("\t}");
            fs.WriteLine ($"\tpublic class {className} : HmsClass<{className}_Data>, IDatabaseModel" + " {");
        }

        public void GenerateField (StreamWriter fs, Field field) {
            string fieldName = field.fieldName;
            string fieldType = field.getFieldType ();
            string defaultValue = field.defaultValue;
            if (defaultValue.Length > 0) {
                fs.WriteLine ($"\t\tprivate {fieldType} _{fieldName} = {defaultValue};");
            } else {
                fs.WriteLine ($"\t\tprivate {fieldType} _{fieldName};");
            }
        }

        public void GenerateInitializer (StreamWriter fs, string className) {
            fs.WriteLine ($"\t\tpublic {className} () : base () {{ }}");
        }

        public void GenerateMethod (StreamWriter fs, Field field) {
            string fieldName = field.getFieldName ();
            string fieldType = field.getFieldType ();
            string initialzer = field.getInitializer ();
            fs.WriteLine ($"\t\tpublic {fieldType} {fieldName}" + " {");
            if (!fieldType.Equals ("Text")) {
                fs.WriteLine ($"\t\t\tget {{ return Call<{fieldType}> (\"get{fieldName}\");}}");
                fs.WriteLine ($"\t\t\tset {{ Call (\"set{fieldName}\" , {initialzer}); }}");
            } else {
                fs.WriteLine ($"\t\t\tget; set;");
            }
            fs.WriteLine ("\t\t}");
        }

        public void GenerateBottom (StreamWriter fs) {
            fs.WriteLine ($"\t\tpublic AndroidJavaObject GetObj()" + " {");
            fs.WriteLine ("\t\t\treturn obj;");
            fs.WriteLine ("\t\t}");
            fs.WriteLine ($"\t\tpublic void SetObj(AndroidJavaObject obj)" + " {");
            fs.WriteLine ("\t\t\tthis.obj = obj;");
            fs.WriteLine ("\t\t}");
            fs.WriteLine ($"\t\tpublic string getObjectTypeName()" + " {");
            fs.WriteLine ("\t\t\treturn Call<string>(\"getObjectTypeName\");");
            fs.WriteLine ("\t\t}");
            fs.WriteLine ($"\t\tpublic string getPackageName()" + " {");
            fs.WriteLine ("\t\t\treturn Call<string>(\"getPackageName\");");
            fs.WriteLine ("\t\t}");
            fs.WriteLine ("\t}");
            fs.WriteLine ("}");
        }
    }

}