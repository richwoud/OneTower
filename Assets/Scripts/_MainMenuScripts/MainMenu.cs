using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
   private GlobalSettings _globalSettings;

    private void Start()
    {
        _globalSettings = GetComponent<GlobalSettings>();

        if (PlayerPrefs.HasKey("OrdinaryMoney") && PlayerPrefs.HasKey("Gold") && PlayerPrefs.HasKey("TowerHealth") &&
           PlayerPrefs.HasKey("TowerShield") && PlayerPrefs.HasKey("ReloadDelay"))
        {
            _globalSettings.OrdinaryMoney = PlayerPrefs.GetInt("OrdinaryMoney");
            _globalSettings.Gold = PlayerPrefs.GetInt("Gold");
            _globalSettings.TowerHealth = PlayerPrefs.GetInt("TowerHealth");
            _globalSettings.TowerShield = PlayerPrefs.GetInt("TowerShield");
            _globalSettings.ReloadDelay = PlayerPrefs.GetFloat("ReloadDelay");
            GlobalSettings.IsShieldActive = PlayerPrefs.GetInt("IsShieldActive") == 1 ? true : false;
        }
        else
        {
            DeffaultSettings();
        }

    }
    void DeffaultSettings()
    {
        _globalSettings.OrdinaryMoney = 0;
        PlayerPrefs.SetInt("OrdinaryMoney", _globalSettings.OrdinaryMoney);
        _globalSettings.Gold = 0;
        PlayerPrefs.SetInt("Gold", _globalSettings.Gold);
        _globalSettings.TowerHealth = 3;
        PlayerPrefs.SetInt("TowerHealth", _globalSettings.TowerHealth);
        _globalSettings.TowerShield = 0;
        PlayerPrefs.SetInt("TowerShield", _globalSettings.TowerShield);
        _globalSettings.ReloadDelay = 0.7f;
        PlayerPrefs.SetFloat("ReloadDelay", _globalSettings.ReloadDelay);
        GlobalSettings.IsShieldActive = false;
         PlayerPrefs.SetInt("IsShieldActive", GlobalSettings.IsShieldActive ? 1 : 0);
        PlayerPrefs.Save();

    }
}
