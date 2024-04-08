using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLobbyNetworkManager : NetworkManager
{
    [SerializeField] private GameUIManager GameManager;
    public override void OnStartServer()
    {
        Debug.Log("I am a server");
    }

    public override void OnStartClient()
    {
        Debug.Log("I am a cliuent");
    }

    public override void OnServerConnect(NetworkConnectionToClient conn)
    {
        GameManager.AddPlayer(conn);
    }
}
