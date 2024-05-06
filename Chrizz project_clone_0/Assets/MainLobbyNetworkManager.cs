using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLobbyNetworkManager : NetworkManager
{
    [SerializeField] private GameUIManager GameUIManager;
    [SerializeField] private PlayerGamesSelector playerSelector;
   
    public override void OnStartServer()
    {
        GameManager.Instance.LoadGames();
        Debug.Log("I am a server");
    }

    public override void OnStartClient()
    {
        GameManager.Instance.LoadGames();
        playerSelector.OnPlayerJoin();
    }

    public override void OnServerConnect(NetworkConnectionToClient conn)
    {
        GameUIManager.AddPlayer(conn);
    
    }
}
