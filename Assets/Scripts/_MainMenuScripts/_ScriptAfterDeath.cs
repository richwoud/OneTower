
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using SavePrefsName;
using UnityEngine.UI;

public class _ScriptAfterDeath : MonoBehaviour
{
    public TextMeshProUGUI _highScoreText, _ordinaryMoneyText, _scoreText, _highWaveText;
    private int _highscore, _ordinaryMoney, _score, _currentWave;

    [SerializeField] private Button _adsButton;
    [SerializeField] private bool _testMode = true;
    private string _gameId = "4425063";
    private string _rewardedVideo = "Rewarded_Android";
    // Start is called before the first frame update
    void Start()
    {
        _adsButton.interactable = Advertisement.IsReady(_rewardedVideo);
        Advertisement.Initialize(_gameId, _testMode);

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
        if (_adsButton)
        {
            Advertisement.Show(_rewardedVideo);
            _ordinaryMoney *= 2;
            SavePrefs.MultiplyMoney(_ordinaryMoney);
            SceneManager.LoadScene(0);
        }
        else
        {
            _adsButton.interactable = false;
            Debug.Log("Advertisment not Ready!");
        }
        
        
    }

}
