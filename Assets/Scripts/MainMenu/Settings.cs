using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using NUnit.Framework;
using UnityEngine.Rendering;
using System.Collections.Generic;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public Dropdown resolutionDropdown;

    public Slider masterVol, musicVol, sfxVol;
    public AudioMixer mainAudioMixer;

    Resolution[] resolutions;

    void Start()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++) 
        { 
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRateRatio + "Hz";
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();
        LoadSettings(currentResolutionIndex);
    }

    public void SetFillscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SaveSettings()
    {
        // Сохранение настроек разрешение и полноэкранного режима
        PlayerPrefs.SetInt("ResolutionPreference", resolutionDropdown.value);
        PlayerPrefs.SetInt("FullscreenPreference", System.Convert.ToInt32(Screen.fullScreen));

        // Сохранение настроек громкости
        PlayerPrefs.SetFloat("MasterVolume", masterVol.value);
        PlayerPrefs.SetFloat("MusicVolume", musicVol.value);
        PlayerPrefs.SetFloat("SFXVolume", sfxVol.value);

        PlayerPrefs.Save();
    }

    public void LoadSettings(int currentResolutionIndex)
    {
        // Загрузка настроек разрешения
        resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionPreference", currentResolutionIndex);

        // Загрузка полноэкранного режима
        Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference", System.Convert.ToInt32(Screen.fullScreen)));

        // Загрузка значений громкости
        masterVol.value = PlayerPrefs.GetFloat("MasterVolume", masterVol.value);
        musicVol.value = PlayerPrefs.GetFloat("MusicVolume", musicVol.value);
        sfxVol.value = PlayerPrefs.GetFloat("SFXVolume", sfxVol.value);

        // Применяем настройки громкости
        ChangeMasterVolume();
        ChangeMusicVolume();
        ChangeSFXVolume();
    }

    public void ChangeMasterVolume()
    {
        mainAudioMixer.SetFloat("MasterVol", masterVol.value);
    }

    public void ChangeMusicVolume()
    {
        mainAudioMixer.SetFloat("MusicVol", musicVol.value);
    }

    public void ChangeSFXVolume()
    {
        mainAudioMixer.SetFloat("SFXVol", sfxVol.value);
    }


}
