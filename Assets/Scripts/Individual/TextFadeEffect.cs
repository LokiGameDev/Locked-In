using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextFadeEffect : MonoBehaviour
{
    private TextMeshProUGUI text;
    private Color col;
    private bool fadeIn;
    void Start()
    {
        text=GetComponent<TextMeshProUGUI>();
        col=text.color;
        fadeIn=true;
    }
    void Update()
    {
        if(fadeIn)
        {
            TextFadeIn();
        }
        else{
            TextFadeOut();
        }
    }
    private void TextFadeIn()
    {
        if(col.a>0)
        {
            col.a-=Time.deltaTime;
            text.color=col;
        }
        else{
            fadeIn=false;
        }
    }
    private void TextFadeOut()
    {
        if(col.a<1)
        {
            col.a+=Time.deltaTime;
            text.color=col;
        }
        else{
            fadeIn=true;
        }
    }
}
