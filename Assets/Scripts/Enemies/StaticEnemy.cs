using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemy : MonoBehaviour
{
    private AudioSource enemyAudio;
    private bool isAudioOn;
    void Start()
    {
        enemyAudio = GetComponent<AudioSource>();
        StartCoroutine(RandomEnemySound(Random.Range(5,10)));
        isAudioOn=true;
    }

    IEnumerator RandomEnemySound(float delay)
    {
        yield return new WaitForSeconds(delay);
        isAudioOn=false;
        enemyAudio.Play();
    }
    void Update()
    {
        if(!isAudioOn)
        {
            StartCoroutine(RandomEnemySound(Random.Range(5,10)));
            isAudioOn=true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().GotHit();
        }
    }
}
