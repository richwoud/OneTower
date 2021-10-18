using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using SavePrefsName;

public class _ScriptAfterDeath : MonoBehaviour
{
    public TextMeshProUGUI _highScoreText, _ordinaryMoneyText, _scoreText, _highWaveText;
    private int _highscore, _ordinaryMoney, _score, _currentWave;
    
    // Start is called before the first frame update
    void Start()
    {
        _currentWave = PlayerPrefs.GetInt("CurrentWaveIndex");
        _ordinaryMoney = PlayerPrefs.GetInt("SaveOrdinaryMoney");
        _score = PlayerPrefs.GetInt("Score");
        _highscore = PlayerPrefs.GetInt("Highscore");
        
     
        _scoreText.text = $"SCORE: {_score}".ToString();

        _highScoreText.text = $"HIGHSCORE: {_highscore}".ToString();

        _ordinaryMoneyText.text = $"You have earned ${_ordinaryMoney}".ToString();

        _highWaveText.text = $"Wave {_currentWave}".ToString();
    }

    public void OnBtnApply()
    {
        SavePrefs.AddMoney(_ordinaryMoney);
        SceneManager.LoadScene(0);
    }
    public void OnBtnWatchAD_AndMultiplyMoney() // встроить рекламу!!! Метод который позволяет увеличить кол-во денег на 2. Для этого необходимо посмотреть рекламу
    {
        _ordinaryMoney *= 2;
        SavePrefs.MultiplyMoney(_ordinaryMoney);
        SceneManager.LoadScene(0);
    }

}
