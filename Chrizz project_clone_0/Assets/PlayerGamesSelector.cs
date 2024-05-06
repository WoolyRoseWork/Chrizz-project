using Mirror;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGamesSelector : MonoBehaviour
{
    public PlayerSelectorManager manager;
    public GameObject gameUI;


    public void OnPlayerJoin()
    {
        GameSO[] so = JSONWriter.GenerateAllScriptableObjects();

        foreach (GameSO game in GameManager.Instance.games)
        {
            GameObject newUI = Instantiate(gameUI, transform);
            newUI.GetComponent<Image>().sprite = game.GameImage;
        }
        Debug.Log("LOAD THE IMAGES");
    }

}
