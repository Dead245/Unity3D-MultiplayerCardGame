using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
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

    private void StartServer()
    {
        throw new System.NotImplementedException();
    }

    private void StartLobby(Label playerName)
    {
        playerName.text = "Host: ";
        playerLabelList.Add(playerName);
    }
    private void JoinLobby(Label playerName)
    {
        playerName.text = "Client: ";
        playerLabelList.Add(playerName);
    }

    public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
    {
        throw new System.NotImplementedException();
    }
}
