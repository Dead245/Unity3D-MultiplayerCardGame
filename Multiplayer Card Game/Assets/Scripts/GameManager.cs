using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject mainHand, enemyHand;
    private void OnEnable()
    {
        
    }

    //Would the main Game Manager ever be disabled?
    private void OnDisable()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void toggleMainHand() { 
        mainHand.SetActive(!mainHand.activeInHierarchy);
    }

    void toggleEnemyHand() { 
        enemyHand.SetActive(!enemyHand.activeInHierarchy);
    }
}
