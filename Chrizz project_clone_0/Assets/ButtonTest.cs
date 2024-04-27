using Mirror;
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]  
public class ButtonTest : NetworkBehaviour
{
    public LobbyChanger lobbyChanger;
    public NetworkConnectionToClient conn;
    private Button btn;



}
