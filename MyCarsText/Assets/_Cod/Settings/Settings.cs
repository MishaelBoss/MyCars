using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class Settings : MonoBehaviour
{
    public Dropdown resolutiondropdown;
    public Dropdown qualityDropdown;

    Resolution[] resolutions;
    void Start()
    {
        resolutiondropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int curretResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                curretResolutionIndex = i;
        }

        resolutiondropdown.AddOptions(options);
        resolutiondropdown.RefreshShownValue();
        LoadSettings(curretResolutionIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("QualitySettingsPreference", qualityDropdown.value);
        PlayerPrefs.SetInt("ResolutionPreference", resolutiondropdown.value);
        PlayerPrefs.SetInt("FullscreenPreference", System.Convert.ToInt32(Screen.fullScreen));
    }

    public void LoadSettings(int currenResolutionIndex)
    {
        if (PlayerPrefs.HasKey("QualitySettingsPreference"))
            qualityDropdown.value = PlayerPrefs.GetInt("QualitySettingsPreference");
        else qualityDropdown.value = 1;

        if (PlayerPrefs.HasKey("ResolutionPreference"))
            resolutiondropdown.value = PlayerPrefs.GetInt("ResolutionPreference");
        else resolutiondropdown.value = currenResolutionIndex;

        if (PlayerPrefs.HasKey("FullscreenPreference"))
            Screen.fullScreen = System.Convert.ToBoolean (PlayerPrefs.GetInt("FullscreenPreference"));
        else Screen.fullScreen = true;
    }
}
