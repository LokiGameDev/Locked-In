using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float _rotationSpeed;
    private float camerPitch;
    void Start()
    {
        _rotationSpeed = 5f;
        camerPitch = 0;
    }
    void Update()
    {
        PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();
        // Checking if the player is alive
        if(player.isPlayerAlive && !player.isPlayerNeedToPause && !UIManager.Instance.isGamePaused)
        {
            CamMovement();
        }
    }

    // Camera Movement
    private void CamMovement()
    {
        // Reading the mouse input value

        float mouseY = _rotationSpeed * Input.GetAxis("Mouse Y");

        camerPitch+=mouseY;

        // Checking for the rotation
        
        if((camerPitch < 30) && (camerPitch>-45))
        {
            transform.Rotate( -mouseY , 0 , 0);
        }
        else
        {
            camerPitch-=mouseY;
        }
    }
}
