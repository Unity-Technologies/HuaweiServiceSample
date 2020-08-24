using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEditor.Callbacks;
using UnityEditor.Android;

public class AfterBuildToDO : IPostGenerateGradleAndroidProject
{
    public int callbackOrder { get { return 0; } }

    private string getOutputPath(string path){
        if(Application.unityVersion.StartsWith("2018")){
            return path;
        }
        string[] s = path.Split('/');
        s[s.Length - 1] = "launcher";
        return string.Join("/", s);
    }

    public void OnPostGenerateGradleAndroidProject(string path)
    {
        Debug.Log(path);
        string launcherPath = getOutputPath(path);
        Debug.Log(launcherPath);
        //读取源文件路径
        string sourceParh = Application.dataPath + "/Plugins/Android/agconnect-services.json";
        //拷贝文件(源路径及文件名, 拷贝路径及文件名, 若该文件名已存在,是否替换)
        File.Copy(sourceParh, launcherPath + "/agconnect-services.json", true);
    }
}