using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Main_MenuText : MonoBehaviour
{
   
    void Start()
    {
        if (PlayerPrefs.HasKey("Language") == false)
        {
            if (Application.systemLanguage == SystemLanguage.Russian || Application.systemLanguage == SystemLanguage.Ukrainian
                || Application.systemLanguage == SystemLanguage.Belarusian) PlayerPrefs.SetInt("Language", 1);
            else PlayerPrefs.SetInt("Language", 0);
        }
        Translator.Select_Language(PlayerPrefs.GetInt("Language"));
    }
    public void Language_change(int languageID)
    {
        PlayerPrefs.SetInt("Language", languageID);
        Translator.Select_Language(PlayerPrefs.GetInt("Language"));
    }

   
}
