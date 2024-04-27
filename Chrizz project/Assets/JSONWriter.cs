
using System;
using System.IO;
using UnityEngine;


public static class JSONWriter
{
    public static GameSO[] GenerateAllScriptableObjects()
    {
    
        string filepath = Application.streamingAssetsPath + "/JsonFiles";
        DirectoryInfo d = new DirectoryInfo(filepath);
        FileInfo[] files = d.GetFiles("*.json");

        GameSO[] objects = new GameSO[files.Length];

        int x = 0;
        foreach (var file in files)
        {
            string result = File.ReadAllText(file.FullName);
            Debug.Log(file.FullName);
            objects[x] = CreateGame(result);
            x++;
        }
        return objects;
    }

    public static GameSO CreateGame(string json)
    {
        GameSO so = ScriptableObject.CreateInstance<GameSO>();
        JsonUtility.FromJsonOverwrite(json, so);

        return so;
    }
}
