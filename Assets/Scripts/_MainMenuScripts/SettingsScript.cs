using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public AudioMixerGroup Master;
    public AudioMixerGroup Music;
    public AudioMixerGroup Effects;
    public GameObject _settingsPanel;
    public GameObject _toggleMusic, _toggleEffects;
    public GameObject _sliderMaster, _sliderMusic, _sliderEffects;
    GUIUpdateScript gUIUpdateScript;
    private void Start()
    {
        //_toggleMusic.GetComponent<Toggle>().isOn = PlayerPrefs.GetInt("MusicEnabled", 1) == 1;
        //_toggleEffects.GetComponent<Toggle>().isOn = PlayerPrefs.GetInt("EffectsEnabled", 1) == 1;
        //_sliderMaster.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MasterVolume", 1);
        //_sliderMusic.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MusicVolume", 1);
        //_sliderEffects.GetComponent<Slider>().value = PlayerPrefs.GetFloat("EffectsVolume", 1);



        _settingsPanel.GetComponentInChildren<Toggle>(_toggleMusic).isOn = PlayerPrefs.GetInt("MusicEnabled", 1) == 1;
        _settingsPanel.GetComponentInChildren<Toggle>(_toggleEffects).isOn = PlayerPrefs.GetInt("EffectsEnabled", 1) == 1;
        _settingsPanel.GetComponentInChildren<Slider>(_sliderMaster).value = PlayerPrefs.GetFloat("MasterVolume", 1);
        _settingsPanel.GetComponentInChildren<Slider>(_sliderMusic).value = PlayerPrefs.GetFloat("MusicVolume", 1);
        _settingsPanel.GetComponentInChildren<Slider>(_sliderEffects).value = PlayerPrefs.GetFloat("EffectsVolume", 1);


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
            Music.audioMixer.SetFloat("MusicVolume", 0);
        else
            Music.audioMixer.SetFloat("MusicVolume", -80);
        PlayerPrefs.SetInt("MusicEnabled", enabled ? 1 : 0);
    }
    public void ToggleEffects(bool enabled)
    {
        if (enabled)
            Effects.audioMixer.SetFloat("EffectsVolume", 0);
        else
            Effects.audioMixer.SetFloat("EffectsVolume", -80);
        PlayerPrefs.SetInt("EffectsEnabled", enabled ? 1 : 0);
    }
    public void ChangeMasterVolume(float volume)
    {
        Master.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80, 0, volume));
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }
    public void ChangeMusicVolume(float volume)
    {
        Music.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, volume));
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
    public void ChangeEffectsVolume(float volume)
    {
        Effects.audioMixer.SetFloat("EffectsVolume", Mathf.Lerp(-80, 0, volume));
        PlayerPrefs.SetFloat("EffectsVolume", volume);
    }

}
