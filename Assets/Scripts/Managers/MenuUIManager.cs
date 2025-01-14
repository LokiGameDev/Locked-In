using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIManager : MonoBehaviour
{
    public GameObject creditScreen , titleScreen;
    public CanvasGroup creditBackGround;
    private bool fadeOut;
    void Start()
    {
        fadeOut=false;
        creditScreen.SetActive(true);
        titleScreen.SetActive(false);
        StartCoroutine(CreditScreenDelay());
    }

    IEnumerator CreditScreenDelay()
    {
        yield return new WaitForSeconds(2.5f);
        titleScreen.SetActive(true);
        creditScreen.SetActive(false);
        fadeOut=true;
    }
    void Update()
    {
        if(fadeOut)
        {
            if(creditBackGround.alpha > 0)
            {
                creditBackGround.alpha -= Time.deltaTime;
                if(creditBackGround.alpha <= 0)
                {
                    fadeOut=false;
                }
            }
        }
    }
}
