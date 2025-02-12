using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    private GameObject _player;
    void Start()
    {
        _player=GameObject.Find("Player");
    }
    void Update()
    {
        Vector3 playerPos = _player.transform.position + new Vector3(0,10,0);
        transform.position=playerPos;
    }
}
