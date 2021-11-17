using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager_Infinity : MonoBehaviour
{
    public TextMeshProUGUI _scoreText, _ordinaryMoneyText, _buttonPause;
    [SerializeField] private int _ordinaryMoney = 0;
    [SerializeField] private int _score = 0;
 
    private int _highScore, _recordWave;
    private SpawnManager _spawnManager;

    /// <summary>OrdinaryMoney - обычная валюта </summary>
    public int OrdinaryMoney { get { return _ordinaryMoney; } set { _ordinaryMoney = value; } }
    /// <summary> Score - счёт  </summary>
    public int Score { get { return _score; } set { _score = value; } }
    /// <summary>  HighScore - лучший счёт </summary>
    public int HighScore { get { return _highScore; } set { _highScore = value; } }
  


    private void Awake()
    {
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        if (PlayerPrefs.HasKey("Highscore"))
        {
            HighScore = PlayerPrefs.GetInt("Highscore");
       
        }
    }
    private void Start()
    {

        TextUIUpdate();
    }
    public void AddMoneyAndScore(int _addMoney, int _addScore)
    {
        OrdinaryMoney += _addMoney;
        Score += _addScore;
        AddHighscore();
    }
    void AddHighscore()
    {
        if (Score > HighScore)
        {
            HighScore = Score;
        }
    }
  
    public void FixedUpdate()
    {
      
        TextUIUpdate();
        Save();
    }

    void TextUIUpdate()
    {
        _ordinaryMoneyText.text = OrdinaryMoney.ToString();
        _scoreText.text = Score.ToString();
      
    }
    void Save()
    {
        PlayerPrefs.SetInt("Score", Score);
        PlayerPrefs.SetInt("SaveOrdinaryMoney", OrdinaryMoney); // передаётся значение для экрана поражение
        PlayerPrefs.SetInt("Highscore", HighScore);
       
    }
    
}
