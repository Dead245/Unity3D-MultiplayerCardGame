using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LobbyList : NetworkBehaviour, INetworkSerializable
{
    [SerializeField] UIDocument lobbyDoc;

    public VisualElement playerLabelHolder;
    List<Label> playerLabelList = new();
    Label playerLabel;

    private NetworkVariable<int> playerLabelName = new NetworkVariable<int>(-1,NetworkVariableReadPermission.Everyone,NetworkVariableWritePermission.Owner);

    

    private void Awake()
    {
        playerLabel = new Label();
        playerLabel.style.fontSize = 18;
        playerLabel.style.color = Color.white;

        ButtonHandler.StartClient += (() => JoinLobby(playerLabel));
        ButtonHandler.StartHost += (() => StartLobby(playerLabel));
        ButtonHandler.StartServer += StartServer;

        var rootElement = lobbyDoc.rootVisualElement;
        playerLabelHolder = rootElement.Query<VisualElement>("PlayerListHolder");

    }

    private void Update()
    {
        if (!IsOwner) return;

        if (Input.GetKeyDown(KeyCode.H))
        {
            playerLabelHolder.Clear();
            Debug.Log(playerLabelName);
            playerLabelList.ForEach(item => {
                playerLabelHolder.Add(item);
            });
        }
    }

    private void StartServer()
    {
        throw new System.NotImplementedException();
    }

    private void StartLobby(Label playerName)
    {
        playerLabelName.Value = 1;
        playerName.text = "Host: " + playerLabelName.Value;
        playerLabelList.Add(playerName);
    }
    private void JoinLobby(Label playerName)
    {
        playerLabelName.Value = 2;
        playerName.text = "Client: " + playerLabelName.Value;
        playerLabelList.Add(playerName);
    }

    private void UpdateList()  {
        
    }

    public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
    {
        throw new System.NotImplementedException();
    }
}
