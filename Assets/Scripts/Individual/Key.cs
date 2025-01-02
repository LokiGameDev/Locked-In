using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private float keyRotatingSpeed;
    void Start()
    {
        keyRotatingSpeed = 40;  // Rotation speed for the key
    }

    void Update()
    {
        transform.Rotate(Vector3.up * keyRotatingSpeed * Time.deltaTime);       // Rotating the key
    }

    // Trigger method for player collision
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameObject.Find("Player").GetComponent<PlayerController>().KeyClaimed();    // Player method triggering for key claiming
            Destroy(gameObject);                                                        // Destroying the key
        }
    }
}
