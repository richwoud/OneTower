using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SavePrefsName
{

    public class SavePrefs : MonoBehaviour
    {
        public TextMeshProUGUI _highScoreText, _ordinaryMoneyText, _recordWaveText;
        private static int _saveOrdinaryMoney;
        private int _saveHighscore, _saveRecordWave;
       

        private void Start()
        {
            if (PlayerPrefs.HasKey("OrdinaryMoney")) _saveOrdinaryMoney = PlayerPrefs.GetInt("OrdinaryMoney"); // �������� ���������� ����� � ��������� �������� � ����������
            if (PlayerPrefs.HasKey("Highscore")) _saveHighscore = PlayerPrefs.GetInt("Highscore");
            if (PlayerPrefs.HasKey("RecordWave")) _saveRecordWave = PlayerPrefs.GetInt("RecordWave");
            TextUIUpdate();
        }

        public static void AddMoney(int _addOrdMoney)
        {
            _saveOrdinaryMoney += _addOrdMoney;
            PlayerPrefs.SetInt("OrdinaryMoney", _saveOrdinaryMoney);
        }
        // ������� ��������� �����
        public static void MultiplyMoney(int _addOrdMoney)
        {
            _saveOrdinaryMoney += _addOrdMoney;
            PlayerPrefs.SetInt("OrdinaryMoney", _saveOrdinaryMoney);
        }

        void TextUIUpdate()
        {
            _ordinaryMoneyText.text =_saveOrdinaryMoney.ToString();
            _highScoreText.text =  _saveHighscore.ToString();
            _recordWaveText.text = _saveRecordWave.ToString();
        }
    }
}
