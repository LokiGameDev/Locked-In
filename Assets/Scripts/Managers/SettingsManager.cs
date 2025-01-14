using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{
    public GameObject[] individualSettings;
    private int _activeSettingIndex;
    public AudioMixer audioMixer;

    // Fullscreen enable/disable function
    public void SetFullScreen(bool isFullScreenOn)
    {
        Screen.fullScreen=isFullScreenOn;
    }

    // Individual settings panel activator
    public void IndividualSettingMenu(int index)
    {
        individualSettings[_activeSettingIndex].SetActive(false);
        _activeSettingIndex=index;
        individualSettings[index].SetActive(true);
    }

    // Volume level controller
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume",volume);
    }

    // Quality setting function
    public void SetQualityLevel(int qualityLevel)
    {
        QualitySettings.SetQualityLevel(qualityLevel);
    }
}
