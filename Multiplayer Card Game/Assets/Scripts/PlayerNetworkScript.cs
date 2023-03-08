using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using Unity.Netcode;
public class PlayerNetworkScript : NetworkBehaviour
{

    private NetworkVariable<int> playerLabelID = new NetworkVariable<int>(-1, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    public override void OnNetworkSpawn() //Do subscribe events on this function instead of Awake()
    {
        playerLabelID.OnValueChanged += (int prevValue, int newValue) => { 
            Debug.Log("!!!!! " + OwnerClientId + ": " + playerLabelID.Value);
        };
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return;

        if (Input.GetKeyDown(KeyCode.H))
        {
            playerLabelID.Value = Random.Range(0, 10);
        }
    }
}
