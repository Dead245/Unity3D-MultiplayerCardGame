using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkManagerUI : NetworkBehaviour
{
    public delegate void doStartGame();
    public static event doStartGame StartGame;

    void OnEnable() {
        ButtonHandler.StartServer += ServerStart;
        ButtonHandler.StartHost += HostStart;
        ButtonHandler.StartClient += ClientStart;
    }

    private void OnDisable() {
        ButtonHandler.StartServer -= ServerStart;
        ButtonHandler.StartHost -= HostStart;
        ButtonHandler.StartClient -= ClientStart;
    }


    void ServerStart() {
        StartGame?.Invoke();
        NetworkManager.Singleton.StartServer();
    }
    void HostStart() { 
        StartGame?.Invoke();
        NetworkManager.Singleton.StartHost();
    }
    void ClientStart() { 
        StartGame?.Invoke();
        NetworkManager.Singleton.StartClient();

    }

}
