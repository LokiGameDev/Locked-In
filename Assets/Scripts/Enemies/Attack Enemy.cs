using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackEnemy : MonoBehaviour
{
    private NavMeshAgent enemyNavMesh;
    void Start()
    {
        enemyNavMesh = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        enemyNavMesh.SetDestination(GameObject.Find("Player").transform.position);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().GotHit();
        }
    }
}
