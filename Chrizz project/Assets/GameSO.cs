using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Game", menuName = "Create Game", order = 1)]
public class GameSO : ScriptableObject
{
    public string GameName;
    public string ExecuteName;
    public Sprite GameImage;
    public string FileLocation;

    public int minPlayers;
    public int maxPlayers;
}
