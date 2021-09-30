using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI _scoreText, /*_highScoreText*/ _ordinaryMoneyText;

   [SerializeField] private int _ordinaryMoney = 0;
    private int _gold;
   [SerializeField] private int _score = 0;
    private float _highScore;

    /// <summary>OrdinaryMoney - обычная валюта </summary>
    public int OrdinaryMoney { get { return _ordinaryMoney; } set { _ordinaryMoney = value; } }
    /// <summary>  Gold - платная валюта </summary>
    public int Gold { get { return _gold; } set { _gold = value; } }
    /// <summary> Score - счёт  </summary>
    public int Score { get { return _score; } set { _score = value; } }
    /// <summary>  HighScore - лучший счёт </summary>
    public float HighScore { get { return _highScore; } set { _highScore = value; } }


    private void Start()
    {
        TextUIUpdate();
    }
    public void AddMoneyAndScore(int _addMoney, int _addScore)
    {
        OrdinaryMoney += _addMoney;
        Score += _addScore;
    }
    public void FixedUpdate()
    {
        TextUIUpdate();
    }

    void TextUIUpdate()
    {
        _ordinaryMoneyText.text = "$ " + OrdinaryMoney.ToString();
        _scoreText.text = "Score: " + Score.ToString();
        //_highScoreText.text = "Highscore: " + _highScore;
    }


}
