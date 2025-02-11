using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyCountInventory : MonoBehaviour
{
    public TextMeshProUGUI keyCountText;
    void Update()
    {
        keyCountText.text = ""+GameObject.Find("Player").GetComponent<PlayerController>().keyCount;
    }
}
