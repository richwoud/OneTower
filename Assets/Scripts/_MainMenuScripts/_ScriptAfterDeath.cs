
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using SavePrefsName;
using UnityEngine.UI;

public class _ScriptAfterDeath : MonoBehaviour
{
    public TextMeshProUGUI  _ordinaryMoneyText, _currentWaveText, _recordWaveText;
    private int _ordinaryMoney, _currentWave, _recordWave;

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
        
        _recordWave = PlayerPrefs.GetInt("RecordWave");

        _currentWaveText.text = _currentWave.ToString();
        _recordWaveText.text = _recordWave.ToString();
        
        _ordinaryMoneyText.text = $"${_ordinaryMoney}".ToString();

    }
    public void OnBtnApply()
    {
        SavePrefs.AddMoney(_ordinaryMoney);
        SceneManager.LoadScene(0);
    }
    public void OnBtnWatchAD_AndMultiplyMoney() // ???????? ???????!!! ????? ??????? ????????? ????????? ???-?? ????? ?? 2. ??? ????? ?????????? ?????????? ???????
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
