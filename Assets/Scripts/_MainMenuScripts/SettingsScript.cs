using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public AudioMixerGroup Master;
    public GameObject _settingsPanel;
    public GameObject _toggleMusic, _sliderMaster;
 
   
    private void Start()
    {
        _settingsPanel.GetComponentInChildren<Toggle>().isOn = PlayerPrefs.GetInt("MusicEnabled", 1) == 1;
        _settingsPanel.GetComponentInChildren<Slider>().value = PlayerPrefs.GetFloat("MasterVolume", 1);
  
    }
    
    public void Btn_OnSettings()
    {
        _settingsPanel.SetActive(true);
    }
    public void Btn_OnExitSettings()
    {
        _settingsPanel.SetActive(false);

    }

    public void ToggleMusic(bool enabled)
    { 
        if (enabled)
            Master.audioMixer.SetFloat("MusicVolume", 0);
        else
            Master.audioMixer.SetFloat("MusicVolume", -80);
        PlayerPrefs.SetInt("MusicEnabled", enabled ? 1 : 0);
    }
  
    public void ChangeMasterVolume(float volume)
    {
        Master.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80, 0, volume));
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }


}
