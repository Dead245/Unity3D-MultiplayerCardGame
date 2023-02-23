using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UIElements;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private UIDocument uiDoc;
    public Button serverBtn, hostBtn, clientBtn;

    public void Awake()
    {
        var rootElement = uiDoc.rootVisualElement;
        serverBtn = rootElement.Query<Button>("Button2");
        hostBtn = rootElement.Query<Button>("Button1");
        clientBtn = rootElement.Query<Button>("Button3");

        serverBtn.clicked += (() => {
            NetworkManager.Singleton.StartServer();
            print("Server Started");
        });

        hostBtn.clicked += (() => {
            NetworkManager.Singleton.StartHost();
            print("Host Started");
        });

        clientBtn.clicked += (() => {
            NetworkManager.Singleton.StartClient();
            print("Client Started");
        });

    }
}
