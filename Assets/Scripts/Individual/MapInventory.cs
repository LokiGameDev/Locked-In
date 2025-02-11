using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInventory : MonoBehaviour
{
    void OnEnable()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().PlayerNeedToPause(true);
    }
}
