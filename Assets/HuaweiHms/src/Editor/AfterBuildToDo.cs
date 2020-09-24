using System;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEditor.Callbacks;
using UnityEditor.Android;

public class AfterBuildToDO : IPostGenerateGradleAndroidProject
{
    public int callbackOrder { get { return 0; } }

    private bool compareVersion(string version1, string version2)
    {
        string[] version1List = version1.Split('.');
        string[] version2List = version2.Split('.');
        int v1year = Int32.Parse(version1List[0]);
        int v2year = Int32.Parse(version2List[0]);
        if (v1year != v2year)
        {
            return v1year > v2year;
        }
        int v1sub = Int32.Parse(version1List[1]);
        int v2sub = Int32.Parse(version2List[1]);
        return v1sub > v2sub;
    }
    
    private string getOutputPath(string path){
        if(compareVersion("2019.3", Application.unityVersion)) {
            return path;
        }
        
        DirectoryInfo parent = new DirectoryInfo(path).Parent;
        return Path.Combine(parent.FullName, "launcher");
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