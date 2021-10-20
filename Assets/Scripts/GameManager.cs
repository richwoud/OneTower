using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI _scoreText, _ordinaryMoneyText, _currentWaveText, _buttonPause;
   [SerializeField] private int _ordinaryMoney = 0;
    private int _gold;
   [SerializeField] private int _score = 0;
    private int _highScore;
    private SpawnManager _spawnManager;

    /// <summary>OrdinaryMoney - обычная валюта </summary>
    public int OrdinaryMoney { get { return _ordinaryMoney; } set { _ordinaryMoney = value; } }
    /// <summary>  Gold - платная валюта </summary>
    public int Gold { get { return _gold; } set { _gold = value; } }
    /// <summary> Score - счёт  </summary>
    public int Score { get { return _score; } set { _score = value; } }
    /// <summary>  HighScore - лучший счёт </summary>
    public int HighScore { get { return _highScore; } set { _highScore = value; } }

    private void Awake()
    {
        
        if (PlayerPrefs.HasKey("Highscore"))
        {
            HighScore = PlayerPrefs.GetInt("Highscore");
        }
    }
    private void Start()
    {
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
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
        _ordinaryMoneyText.text = "$ " + OrdinaryMoney.ToString();
        _scoreText.text = "Score\n" + Score.ToString();
        _currentWaveText.text = "Wave\n" + _spawnManager.CurrentWaveIndex.ToString();
    }
    void Save()
    {
        PlayerPrefs.SetInt("Score", Score);
        PlayerPrefs.SetInt("SaveOrdinaryMoney", OrdinaryMoney); // передаётся значение для экрана поражение
        PlayerPrefs.SetInt("Highscore", HighScore);
    }


}
