using Mirror;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class LobbyChanger : NetworkBehaviour
{
    [TargetRpc]
    public void ChangeScene(NetworkConnection target, string fileLocation, string ExecuteName)
    {
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
                sw.WriteLine($"{fileLocation[0]}{fileLocation[1]}");
                sw.WriteLine($"cd {fileLocation}");
                sw.WriteLine($"\"{ExecuteName}\""); 
            }
            p.WaitForExit();
        }
    }
}
