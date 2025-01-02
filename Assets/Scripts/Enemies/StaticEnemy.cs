using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemy : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.LookAt(GameObject.Find("Player").transform);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().GotHit();
        }
    }
}
