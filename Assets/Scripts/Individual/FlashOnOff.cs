using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashOnOff : MonoBehaviour
{
    private Light _light;
    private bool isRandomOn;
    void Start()
    {
        _light = GetComponent<Light>();
        _light.enabled = true;
        isRandomOn=true;
    }

    void Update()
    {
        if(isRandomOn)
        {
            StartCoroutine(FlashRandomDelay(Random.Range(10,20)));
            isRandomOn=false;
        }
    }

    IEnumerator FlashRandomDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        _light.enabled = false;
        StartCoroutine(FlashOffDelay());

    }

    IEnumerator FlashOffDelay()
    {
        yield return new WaitForSeconds(0.3f);
        _light.enabled = true;
        isRandomOn=true;
    }
}
