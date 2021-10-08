using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using SavePrefsName;

public class _ScriptAfterDeath : MonoBehaviour
{
    public TextMeshProUGUI _highScoreText, _ordinaryMoneyText, _scoreText, _enemyDeadText;
    private int _highscore, _ordinaryMoney, _score, _enemydead;

   

    // Start is called before the first frame update
    void Start()
    {
        _ordinaryMoney = PlayerPrefs.GetInt("SaveOrdinaryMoney");
        _score = PlayerPrefs.GetInt("Score");
        _highscore = PlayerPrefs.GetInt("Highscore");


        _scoreText.text = $"SCORE: {_score}".ToString();

        _highScoreText.text = $"HIGHSCORE: {_highscore}".ToString();

        _ordinaryMoneyText.text = $"You have earned ${_ordinaryMoney}".ToString();
    }

    public void OnBtnApply()
    {
        SavePrefs.AddMoney(_ordinaryMoney);
        SceneManager.LoadScene(0);
    }
    public void OnBtnWatchAD_AndMultiplyMoney() // встроить рекламу
    {
        _ordinaryMoney *= 2; // переделать в другой класс, сделать метод
        
        SceneManager.LoadScene(0);
    }

}
