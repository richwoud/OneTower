using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI _scoreText, _ordinaryMoneyText, _currentWaveText, _buttonPause;
   [SerializeField] private int _ordinaryMoney = 0;
   [SerializeField] private int _score = 0;
    private int _currentWave;
    private int _highScore, _recordWave;
    private SpawnManager _spawnManager;

    /// <summary>OrdinaryMoney - ������� ������ </summary>
    public int OrdinaryMoney { get { return _ordinaryMoney; } set { _ordinaryMoney = value; } }
    /// <summary> Score - ����  </summary>
    public int Score { get { return _score; } set { _score = value; } }
    /// <summary>  HighScore - ������ ���� </summary>
    public int HighScore { get { return _highScore; } set { _highScore = value; } }
    public int RecordWave { get { return _recordWave; } set { _recordWave = value; } }


    private void Awake()
    {
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        if (PlayerPrefs.HasKey("Highscore") && PlayerPrefs.HasKey("RecordWave"))
        {
            HighScore = PlayerPrefs.GetInt("Highscore");
            RecordWave = PlayerPrefs.GetInt("RecordWave");
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
    void AddRecordWave()
    {
        if (_currentWave > RecordWave)
        {
            RecordWave = _currentWave;
        }
    }
    public void FixedUpdate()
    {
        AddRecordWave();
        TextUIUpdate();
        Save(); 
    }

    void TextUIUpdate()
    {
        _ordinaryMoneyText.text = OrdinaryMoney.ToString();
        _scoreText.text = Score.ToString();
        _currentWaveText.text = _spawnManager.CurrentWaveIndex.ToString();
        _currentWave = _spawnManager.CurrentWaveIndex;
    }
    void Save()
    {
        PlayerPrefs.SetInt("Score", Score);
        PlayerPrefs.SetInt("SaveOrdinaryMoney", OrdinaryMoney); // ��������� �������� ��� ������ ���������
        PlayerPrefs.SetInt("Highscore", HighScore);
        PlayerPrefs.SetInt("RecordWave", RecordWave);
    }


}
