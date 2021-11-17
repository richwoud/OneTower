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
            "Upgrades", //2
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
            "Tower characteristics", //22
            "Maximum Tower Health", //23
            "Reload time", //24
            "Bullet speed", //25
            "Bullet Damage", //26
            "Watch AD and get $50", //27
            "Remove ads", //28
            "You get $400", //29
            "You get $2400\nFree $400", //30
            "You get $4200\nFree $600", //31
            "You get $10000\nFree $2000", //32
            "You get $25000\nFree $9000", //33
            "Get Free", //34
            "Buy", //35
            "Increases tower health by 1", //36
            "The tower will withstand 1 additional damage", //37
            "Reduces reload time", //38
            "Increases bullet speed by 2", //39
            "Increases bullet damage by 1", //40
            "Not enough money", //41
            "Congratulations! You have defeated all the enemies and saved this world from the invasion of cubes. Your tower is ready to destroy anyone who challenges! " +
            "Thank you for playing this game all this time. I hope you enjoyed it and had fun. Please rate the game on Google Play, " +
            "and you can also suggest improvements for the game." +
            "See you in the next updates and games!", //42
            "Speed Game" //43

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
              "Характеристики башни",
              "Максимальное здоровье башни",
              "Время перезарядки",
              "Скорость пули",
              "Урон пули",
              "Посмотрите рекламу и получите $50",
              "Убрать рекламу",
              "Вы получаете $400",
              "Вы получаете $2400\nБесплатно $400",
              "Вы получаете $4200\nБесплатно $600",
              "Вы получаете $10000\nБесплатно $2000",
              "Вы получаете $25000\nБесплатно $9000",
              "Получить бесплатно",
              "Купить",
              "Увеличивает здоровье башни на 1",
              "Башня выдержит 1 дополнительный урон",
              "Сокращает время перезарядки",
              "Увеличивает скорость пули на 2",
              "Увеличивает урон от пули на 1",
              "Не хватает денег",
               "Поздравляю! Вы победили всех врагов и спасли этот мир от нашествия кубиков. Ваша башня готова уничтожить любого, кто бросит вызов!" +
            "Благодарю вас за то что играли в эту игру всё это время. Надеюсь Вам понравилось и было весело. Оцените пожалуйста игру в Google Play," +
            " а также можете предложить улучшения для игры. Увидимся в следующих обновлениях и играх!",
               "Скорость игры"
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
