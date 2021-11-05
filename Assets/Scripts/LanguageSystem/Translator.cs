using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Translator : MonoBehaviour
{
    private static int LanguageId;
    private static List<Translatable_text> listId = new List<Translatable_text>();


    private static string[,] LineText =
    {
         #region ENGLISH
        {
            "Highscore", // 0
            "Battle", //1
            "Upgrade", //2
            "Shop", //3
            "Exit", //4
            "Settings", //5
            "Audio Volume", //6
            "Music", //7
            "Language", //8
            "Sources", //9
            "Icons", //10
            "Score", //11
            "Wave", //12
            "Resume", //13
            "Your tower is destroyed. After watching the advertisement, another chance will be given. Do you want to continue?", //14
            "Menu", //15
            "Continue", //16
            "Defeat", //17
            "Wave", //18
            "Record wave", //19
            "You have earned", //20
            "Apply", //21
            ""
            
        },
        #endregion
         #region RUSSIAN
          {
              "Лучший счёт",
              "Битва",
              "Улучшения",
              "Магазин",
              "Выход",
              "Настройки",
              "Громкость звука",
              "Музыка",
              "Язык",
              "Источники",
              "Иконки",
              "Счёт",
              "Волна",
              "Продолжить",
              "Ваша башня разрушена. После просмотра рекламы вам будет предоставлен еще один шанс. Вы хотите продолжить?",
              "Меню",
              "Продолжить",
              "Поражение",
              "Волна",
              "Рекордная волна",
              "Вы заработали",
              "Применить",
              ""
          },
        #endregion
    };
    public static void Select_Language(int id) // Выбор языка - Вызывается в скрипте стартового меню при старте и в функции выбора языка в настройках
    {
        LanguageId = id;
        Update_texts();
    }
    public static string Get_text(int textkey)
    {
        return LineText[LanguageId, textkey];
    }
    public static void Add(Translatable_text idText)
    {
        listId.Add(idText);
    }
    public static void Delete(Translatable_text idtext)
    {
        listId.Remove(idtext);
    }
    public static void Update_texts()
    {
        for (int i = 0; i < listId.Count; i++)
        {
            listId[i].UIText.text = LineText[LanguageId, listId[i].textID];
           
        }
    }
}
