using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class GameUI : MonoBehaviour
{
    public LobbyChanger changer;

    [Header("SelectedPlayers")]
    public NetworkConnectionToClient Host;
    public List<NetworkConnectionToClient> Clients = new();

    [Header("GameInfo")]
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI GameName;

    [Header("Toggles")]
    [SerializeField] private Toggle togglePrefab;
    [SerializeField] private Transform togleParent;

    [Header("DropDown")]
    [SerializeField] private TMP_Dropdown dropDown;

    [Header("Stop/Start")]
    [SerializeField] private Button startBtn;
    [SerializeField] private Button stopBtn;

    private Dictionary<int, NetworkConnectionToClient> connections = new();
    private Dictionary<int, Toggle> toggles = new();
    private int PlayerCount = 0;

    private GameSO game;

    private void Start()
    {
        dropDown.onValueChanged.AddListener(SetHost);
        startBtn.onClick.AddListener(StartGame);
    }

    public void SetValues(GameSO gameStats)
    {
        //image.sprite = gameStats?.GameImage;
        GameName.text = gameStats?.GameName;

        game = gameStats;
    }

    public void AddPlayer(NetworkConnectionToClient conn)
    {
        PlayerCount++;
        Toggle newToggle = Instantiate(togglePrefab, togleParent);
        newToggle.onValueChanged.AddListener(delegate { SetPlayerToggleValue(conn, newToggle.isOn); });
        toggles.Add(PlayerCount,newToggle);


        connections.Add(PlayerCount, conn);

        dropDown.options.Add(new TMP_Dropdown.OptionData($"{PlayerCount}", null));
        dropDown.RefreshShownValue();
    }

    public void SetPlayerToggleValue(NetworkConnectionToClient conn, bool enabled)
    {
        //TODO return a warning to first select a host.
        if (Host == null) return;

        //Removes the Host
        if(!enabled && Host == conn) { Host = null; }
        //Remove the host from the host tab

        //if value changed to enabled cause host got selected we dont want to add it to the clients list else it will do two calls to the game
        if (enabled && Host == conn) return;

        //remove or add depending on if they were added
        if (enabled && Host != conn) Clients.Add(conn);
        if (!enabled && Host != conn) Clients.Remove(conn);

        Debug.Log($"this enabled value is {enabled} the client count is {Clients.Count} The host is {Host}");
    }

    public void SetHost(int selectedIndex)
    {
        if (Host != null) Clients.Add(Host);
        Host = connections[selectedIndex];
        toggles[selectedIndex].SetIsOnWithoutNotify(true);
    }

    private void StartGame()
    {
        changer.ChangeScene(Host, game.GameName);

        foreach (NetworkConnectionToClient client in Clients)
        {
            changer.ChangeScene(client, game.GameName);
        }

    }

    private void EndGame()
    {

    }
}
