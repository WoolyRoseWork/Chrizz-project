using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    public readonly List<GameSO> games = new List<GameSO>();
    public void LoadGames()
    {
        foreach (GameSO game in JSONWriter.GenerateAllScriptableObjects())
        {
            games.Add(game);
        }
        Debug.Log("LOAD THE FUCKING GAMES");
    }
}
