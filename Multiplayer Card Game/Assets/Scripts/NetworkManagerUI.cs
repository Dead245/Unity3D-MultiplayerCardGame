using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkManagerUI : MonoBehaviour
{
    public delegate void TurnOffButtons();
    public static event TurnOffButtons TurnOff;

    void OnEnable() {
        ButtonHandler.StartServer += ServerStart;
        ButtonHandler.StartHost += HostStart;
        ButtonHandler.StartClient += ClientStart;
    }

    private void OnDisable()
    {
        ButtonHandler.StartServer -= ServerStart;
        ButtonHandler.StartHost -= HostStart;
        ButtonHandler.StartClient -= ClientStart;
    }

    void ServerStart() { 
        TurnOff?.Invoke();
        NetworkManager.Singleton.StartServer();
    }
    void HostStart() { 
        TurnOff?.Invoke();
        NetworkManager.Singleton.StartHost();
    }
    void ClientStart() { 
        TurnOff?.Invoke();
        NetworkManager.Singleton.StartClient();

    }

}
