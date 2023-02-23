using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkManagerUI : MonoBehaviour
{
    public delegate void TurnOffButtons();
    public static event TurnOffButtons TurnOff;

    public void Awake() {
        ButtonHandler.StartServer += ServerStart;
        ButtonHandler.StartHost += HostStart;
        ButtonHandler.StartClient += ClientStart;
    }

    void ServerStart() { 
        TurnOff();
        NetworkManager.Singleton.StartServer();
    }
    void HostStart() { 
        TurnOff();
        NetworkManager.Singleton.StartHost();
    }
    void ClientStart() { 
        TurnOff();
        NetworkManager.Singleton.StartClient();

    }

}
