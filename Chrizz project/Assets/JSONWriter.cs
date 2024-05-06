
using System;
using System.IO;
using UnityEngine;


public static class JSONWriter
{
    public static GameSO[] GenerateAllScriptableObjects()
    {
    
        string filepath = Application.streamingAssetsPath + "/JsonFiles";
        DirectoryInfo d = new DirectoryInfo(filepath);

        DirectoryInfo[] directories = d.GetDirectories();
        GameSO[] objects = new GameSO[directories.Length];

        int x = 0;

        foreach (DirectoryInfo dir in directories)
        {
            FileInfo[] files = dir.GetFiles("*.json");
            FileInfo[] image = dir.GetFiles("*.png");

            

            foreach (var file in files)
            {
                string result = File.ReadAllText(file.FullName);
                objects[x] = CreateGame(result);
                objects[x].GameImage = ImageLoader(image[0].FullName);
                x++;
            }
        }    
        return objects;
    }

    public static GameSO CreateGame(string json)
    {
        GameSO so = ScriptableObject.CreateInstance<GameSO>();
        JsonUtility.FromJsonOverwrite(json, so);

        return so;
    }

    public static Sprite ImageLoader(string filePath)
    {
        Debug.Log(filePath);
        byte[] pngBytes = File.ReadAllBytes(filePath);

        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(pngBytes);

        Sprite fromTex = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);

        return fromTex;
    }
}
