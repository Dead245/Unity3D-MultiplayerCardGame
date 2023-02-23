using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkManagerUI : MonoBehaviour
{

    public void Awake() {
        ButtonHandler.StartServer += ServerStart;
        ButtonHandler.StartHost += HostStart;
        ButtonHandler.StartClient += ClientStart;
    }

    void ServerStart() { 
        NetworkManager.Singleton.StartServer();
    }
    void HostStart() { 
        NetworkManager.Singleton.StartHost();
    }
    void ClientStart() { 
        NetworkManager.Singleton.StartClient();

    }

}
