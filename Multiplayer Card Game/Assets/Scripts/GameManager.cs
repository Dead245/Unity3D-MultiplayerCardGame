using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject mainHand;
    private void OnEnable()
    {
        NetworkManagerUI.StartGame += toggleMainHand;
    }

    //Would the main Game Manager ever be disabled?
    private void OnDisable()
    {
        NetworkManagerUI.StartGame -= toggleMainHand;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void toggleMainHand() { 
        mainHand.SetActive(!mainHand.activeInHierarchy);
    }
}
