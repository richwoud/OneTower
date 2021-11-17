using UnityEngine;
using TMPro;


public class GameManager_Classic : MonoBehaviour
{
    public TextMeshProUGUI _ordinaryMoneyText, _currentWaveText, _buttonPause;
   [SerializeField] private int _ordinaryMoney = 0;
    private int _currentWave;
    private int  _recordWave;
    private SpawnManager _spawnManager;

    /// <summary>OrdinaryMoney - обычная валюта </summary>
    public int OrdinaryMoney { get { return _ordinaryMoney; } set { _ordinaryMoney = value; } }
    /// <summary> Score - счёт  </summary>
    public int RecordWave { get { return _recordWave; } set { _recordWave = value; } }


    private void Awake()
    {
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        if (PlayerPrefs.HasKey("RecordWave"))
        {
          
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
        _currentWaveText.text = _spawnManager.CurrentWaveIndex.ToString();
        _currentWave = _spawnManager.CurrentWaveIndex;
    }
    void Save()
    {
        PlayerPrefs.SetInt("SaveOrdinaryMoney", OrdinaryMoney); // передаётся значение для экрана поражени
        PlayerPrefs.SetInt("RecordWave", RecordWave);
    }

    public void TimeSpeedGamePlus()
    {
        Time.timeScale = 2f;
    }
    public void TimeSpeedGameNorm()
    {
        Time.timeScale = 1f;
    }

}
