using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SettingsManager : MonoBehaviour
{
    public GameObject[] individualSettings;
    
    public TMP_Dropdown resolutionDropdown;
    private int _activeSettingIndex;
    public AudioMixer audioMixer;
    public Resolution[] resolutions;
    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> resOptions = new List<string>();

        int currentResolutionIndex = 0;

        for(int i=0;i<resolutions.Length;i++)
        {
            string option = resolutions[i].width + "X" + resolutions[i].height;
            resOptions.Add(option);

            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(resOptions);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    // Fullscreen enable/disable function
    public void SetFullScreen(bool isFullScreenOn)
    {
        Screen.fullScreen=isFullScreenOn;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width , res.height , Screen.fullScreen);
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
