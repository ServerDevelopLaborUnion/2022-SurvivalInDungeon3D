using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public class BuildSettingToEnum
{
    private const string FILE_PATH = "/03.Scripts/00.Common/SceneLoading";
    [MenuItem("Custom/SceneLoader/RefreshBuildSettingToEnum")]
    private static void RefreshBuildSettingToEnum()
    {
        string tempFilePath = Path.Combine(Application.dataPath + FILE_PATH, "TempBuildingScenes.txt");
        string filePath = Path.Combine(Application.dataPath + FILE_PATH, "BuildingScenes.cs");

        string message = ReadTxt(tempFilePath);

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < EditorBuildSettings.scenes.Length; ++i)
        {
            Debug.Log(EditorBuildSettings.scenes[i].guid);
            Debug.Log(EditorBuildSettings.scenes[i].path);
            sb.Append(EditorBuildSettings.scenes[i].ToString());
            sb.AppendLine(",");
        }

        WriteTxt(filePath, message, sb);
        AssetDatabase.Refresh();
    }

    private static void WriteTxt(string filePath, string message, StringBuilder data)
    {
        if(message == string.Empty){
            Debug.LogError("Message is Empty");
            return;
        }

        string template = message;

        DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetDirectoryName(filePath));

        if (!directoryInfo.Exists)
        {
            directoryInfo.Create();
        }

        FileStream fileStream
            = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);

        StreamWriter writer = new StreamWriter(fileStream, System.Text.Encoding.Unicode);


        template = template.Replace("$DATA$", data.ToString());

        writer.Write(template);
        writer.Close();
    }

    private static string ReadTxt(string filePath)
    {

        if (File.Exists(filePath))
        {
            string value = "";
            // StreamReader reader = new StreamReader(filePath);
            // value = reader.ReadToEnd();
            // reader.Close();
            value = File.ReadAllText(filePath);
            return value;
        }
        else
        {
            Debug.LogError("File Is None");
            return string.Empty;
        }

    }
}
