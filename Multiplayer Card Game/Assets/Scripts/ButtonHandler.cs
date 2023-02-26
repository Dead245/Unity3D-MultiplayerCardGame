using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private UIDocument uiDoc;
    public Button serverBtn, hostBtn, clientBtn;

    public delegate void doStartServer();
    public static event doStartServer StartServer;

    public delegate void doStartHost();
    public static event doStartHost StartHost;

    public delegate void doStartClient();
    public static event doStartClient StartClient;

    private void OnEnable()
    {
        NetworkManagerUI.StartGame += toggleNetworkButtons;
    }
    private void OnDisable()
    {
        NetworkManagerUI.StartGame -= toggleNetworkButtons;

    }
    public void Awake()
    {
        var rootElement = uiDoc.rootVisualElement;
        serverBtn = rootElement.Query<Button>("Button2"); //Horrible names, I know
        hostBtn = rootElement.Query<Button>("Button1");
        clientBtn = rootElement.Query<Button>("Button3");

        serverBtn.clicked += (() => {
            StartServer?.Invoke();
        });

        hostBtn.clicked += (() => {
            StartHost?.Invoke();
        });

        clientBtn.clicked += (() => {
            StartClient?.Invoke();
        });

    }

    void toggleNetworkButtons() {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }
}
