using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    public Transform[] movingSpots;
    private int movingSpotIndex;
    private float enemySpeed;
    private bool canMove;
    void Start()
    {
        movingSpotIndex=0;
        enemySpeed = 2.5f;
        canMove = true;
    }

    void Update()
    {
        if(canMove)
        {
            EnemyMovement();
        }
        float distanceBetween = Vector3.Distance(transform.position , movingSpots[movingSpotIndex].position);

        if(distanceBetween < 1)
        {
            canMove=false;
            StartCoroutine(EnemyWaitingCountDown());
            
            movingSpotIndex+=1;

            if(movingSpotIndex>=movingSpots.Length)
            {
                movingSpotIndex=0;
            }
        }
    }

    private void EnemyMovement()
    {
        transform.LookAt(movingSpots[movingSpotIndex]);

        Vector3 movPos = new Vector3(movingSpots[movingSpotIndex].position.x , transform.position.y , movingSpots[movingSpotIndex].position.z);

        transform.position = Vector3.MoveTowards(transform.position , movPos , Time.deltaTime * enemySpeed);

    }
    IEnumerator EnemyWaitingCountDown()
    {
        yield return new WaitForSeconds(3);
        canMove=true;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().GotHit();
        }
    }
}
