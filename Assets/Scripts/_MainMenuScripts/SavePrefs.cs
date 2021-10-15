using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SavePrefsName
{

    public class SavePrefs : MonoBehaviour
    {
        public TextMeshProUGUI _highScoreText, _ordinaryMoneyText, _goldText;
        private static int _saveOrdinaryMoney;
        private int _saveHighscore;
        private int _gold;

        private void Start()
        {
            if (PlayerPrefs.HasKey("OrdinaryMoney")) _saveOrdinaryMoney = PlayerPrefs.GetInt("OrdinaryMoney"); // проверка указанного ключа и установка значения в переменную
            if (PlayerPrefs.HasKey("Highscore")) _saveHighscore = PlayerPrefs.GetInt("Highscore");
            if (PlayerPrefs.HasKey("Gold")) _gold = PlayerPrefs.GetInt("Gold");
            TextUIUpdate();
        }

        public static void AddMoney(int _addOrdMoney)
        {
            _saveOrdinaryMoney += _addOrdMoney;
            PlayerPrefs.SetInt("OrdinaryMoney", _saveOrdinaryMoney);
        }
        // сделать умножение денег
        public static void MultiplyMoney(int _addOrdMoney)
        {
            _saveOrdinaryMoney += _addOrdMoney;
            PlayerPrefs.SetInt("OrdinaryMoney", _saveOrdinaryMoney);
        }

        void TextUIUpdate()
        {
            _ordinaryMoneyText.text = "$ " + _saveOrdinaryMoney.ToString();
            _highScoreText.text = "Highscore\n " + _saveHighscore.ToString();
            _goldText.text = _gold.ToString();
        }
    }
}
