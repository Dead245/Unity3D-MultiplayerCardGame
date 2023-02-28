using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class LobbyList : MonoBehaviour
{
    [SerializeField] UIDocument lobbyDoc;

    public VisualElement playerList;
    private void Awake()
    {
        var rootElement = lobbyDoc.rootVisualElement;
        playerList = rootElement.Query<VisualElement>("PlayerListHolder");

        Label playerLabel = new Label("Test Player on List");
        playerLabel.style.fontSize = 18;
        playerLabel.style.color= Color.white;


        //Temporary
        playerList.Add(playerLabel);
    }


}
