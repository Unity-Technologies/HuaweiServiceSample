using System;
using UnityEditor;
using UnityEngine;

namespace HuaweiService.CloudDB.Editor {
    public class CloudDBSetting : EditorWindow {
        public string javaPackageName = "";
        public string objectTypeFilePath = "";
        public string namespaceName = "";
        public string exportDir = "";

        CloudDBSetting () {
            this.titleContent = new GUIContent ("CloudDB Setting");
        }

        [MenuItem ("CloudDB Kit/CloudDB Setting")]
        static void showWindow () {
            EditorWindow.GetWindow (typeof (CloudDBSetting));
        }
        void OnGUI () {
            GUILayout.BeginVertical ();

            GUILayout.Space (10);
            GUI.skin.label.fontSize = 24;
            GUI.skin.label.alignment = TextAnchor.MiddleCenter;
            GUILayout.Label ("CloudDB Setting");

            GUILayout.Space (10);
            javaPackageName = EditorGUILayout.TextField ("JavaCode Package Name", javaPackageName);
            GUILayout.Space (10);
            objectTypeFilePath = EditorGUILayout.TextField ("ObjectType JsonFile Path", objectTypeFilePath);
            GUILayout.Space (10);
            namespaceName = EditorGUILayout.TextField ("Namespace", namespaceName);
            GUILayout.Space (10);
            exportDir = EditorGUILayout.TextField ("Export Path", exportDir);
            GUILayout.Space (20);
            if (GUILayout.Button ("Choose ObjectType File")) {
                chooseFile ();
            }
            GUILayout.Space (10);
            if (GUILayout.Button ("Choose Export Directory")) {
                chooseModelDir ();
            }
            GUILayout.Space (10);
            if (GUILayout.Button ("Generate Code")) {
                genCode ();
            }
            GUILayout.EndVertical ();
        }

        //用于保存当前信息
        void genCode () {
            GenCode gen = new GenCode ();
            gen.Init (javaPackageName, objectTypeFilePath, namespaceName, exportDir);
        }

        void chooseFile () {
            string path = EditorUtility.OpenFilePanel ("Choose ObjectType JSON file", "", "json");
            if (path.Length != 0) {
                objectTypeFilePath = path;
            }
        }

        void chooseModelDir () {
            string path = EditorUtility.OpenFolderPanel ("Choose Model Directory", "", "model");
            if (path.Length != 0) {
                exportDir = path+"/model";
            }
        }
    }
}