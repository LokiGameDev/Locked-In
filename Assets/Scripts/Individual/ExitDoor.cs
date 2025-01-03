using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    private bool isPlayerNear;
    void Start()
    {
        isPlayerNear=false;
    }
    void Update()
    {
        if(isPlayerNear)
        {
            if(Input.GetKeyDown(KeyCode.E) && GameObject.Find("Player").GetComponent<PlayerController>().keyCount>=3)
            {
                UIManager.Instance.GameWon();   // Triggering the game won screen
                Time.timeScale=0;               // Making the time scale to 0 for pausing the game
                Destroy(gameObject);            // Destroying the game object
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isPlayerNear=true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isPlayerNear=false;
        }
    }
}
