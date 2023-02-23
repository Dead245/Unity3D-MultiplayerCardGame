using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UIElements;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private UIDocument uiDoc;
    public Button serverBtn, hostBtn, clientBtn;

    public delegate void StartServerAction();
    public static event StartServerAction StartServer;

    public delegate void StartHostAction();
    public static event StartHostAction StartHost;

    public delegate void StartClientAction();
    public static event StartServerAction StartClient;

    public void Awake()
    {
        NetworkManagerUI.TurnOff += (() => { gameObject.SetActive(false); });

        var rootElement = uiDoc.rootVisualElement;
        serverBtn = rootElement.Query<Button>("Button2");
        hostBtn = rootElement.Query<Button>("Button1");
        clientBtn = rootElement.Query<Button>("Button3");

        serverBtn.clicked += (() => {
            if(StartServer != null)
               StartServer();
        });

        hostBtn.clicked += (() => {
            if (StartHost != null)
                StartHost();
        });

        clientBtn.clicked += (() => {
            if (StartClient != null)
                StartClient();
        });

    }
}
