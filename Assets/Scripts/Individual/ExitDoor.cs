using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    // Trigger for final door
    private void OnTriggerStay(Collider other)
    {
        // Check if the trigger was the player

        if(other.CompareTag("Player"))
        {
            // Check if the Key is pressed and key count

            if(Input.GetKeyDown(KeyCode.E) && other.GetComponent<PlayerController>().keyCount>=3)
            {
                UIManager.Instance.GameWon();   // Triggering the game won screen
                Time.timeScale=0;               // Making the time scale to 0 for pausing the game
                Destroy(gameObject);            // Destroying the door
            }
        }
    }
}
