using Mirror;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class LobbyChanger : NetworkBehaviour
{
    [TargetRpc]
    public void ChangeScene(NetworkConnection target, string gameName)
    {
        string filepath = Application.streamingAssetsPath + "/JsonFiles/" + gameName + ".json";
        string result = File.ReadAllText(filepath);

        GameSO game = JSONWriter.CreateGame(result);

        Process p = new Process();
        ProcessStartInfo info = new ProcessStartInfo();
        info.FileName = "cmd.exe";
        info.RedirectStandardInput = true;
        info.UseShellExecute = false;
        p.StartInfo = info;
        p.Start();

        using (StreamWriter sw = p.StandardInput)
        {
            if(sw.BaseStream.CanWrite)
            {
                sw.WriteLine("cd\\");
                sw.WriteLine($"{game.FileLocation[0]}{game.FileLocation[1]}");
                sw.WriteLine($"cd {game.FileLocation}");
                sw.WriteLine($"\"{game.ExecuteName}\""); 
            }
            p.WaitForExit();
        }
    }
}
