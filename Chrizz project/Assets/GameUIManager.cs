using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    public LobbyChanger changer;
    private List<GameUI> games = new();
    public GameUI prefab;

    private void Awake()
    {
  
    }
    private void Start()
    {
        foreach (GameSO obj in GameManager.Instance.games)
        {
            CreateGameUI(obj);
        }
    }

    private void CreateGameUI(GameSO game)
    {
        GameUI newUI = Instantiate(prefab, transform);
        newUI.SetValues(game);
        newUI.changer = changer;
        games.Add(newUI);
    }

    public void AddPlayer(NetworkConnectionToClient conn)
    {
        foreach (GameUI UI in games)
        {
            UI.AddPlayer(conn);
        }
    }
}
