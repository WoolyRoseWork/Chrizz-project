using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerSelectorManager : NetworkBehaviour
{
    public readonly SyncList<int> votes = new();
    public List<GameSO> games = new();



    public void Update()
    {
    }


}
