using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour, IUnityAdsListener
{
    public static bool _gameIsPaused;
    [SerializeField] PauseMenu _pauseMenu;
    [SerializeField] private GameObject _deathMenuUI;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private GameObject _player;
    [SerializeField] private TowerSettings _towerSettings;

    [SerializeField] private bool _testMode = true;
    private string _gameId = "4425063";
    private string _rewardedVideo = "Rewarded_Android";
    [SerializeField] private Button _adsButton;

    private void Start()
    {
        Advertisement.Initialize(_gameId, _testMode);
        _adsButton.interactable = Advertisement.IsReady(_rewardedVideo);

        Pause();
        PlayerPrefs.Save();
        _pauseButton.SetActive(false);

    }

    public void Pause()
    {
        _player.SetActive(false);
        _deathMenuUI.SetActive(true);
        Time.timeScale = 0f;
        _gameIsPaused = true;
    }


    public void ContinueButton()
    {
        if (_adsButton)
        {
            Advertisement.Show(_rewardedVideo);
          
            _gameIsPaused = false;
            _pauseButton.SetActive(true);
            _player.SetActive(true);
            _towerSettings.CurrentTowerHealth += _towerSettings.MaxHealthTower;
            _towerSettings._healthBarImage.fillAmount = _towerSettings.MaxHealthTower;
            _deathMenuUI.SetActive(false);
            _pauseMenu.Pause_Button();
        }
        else
        {
            _adsButton.interactable = false;
            Debug.Log("Advertisment not Ready!");
        }
    }

    public void ExitMenu()
    {
        SceneManager.LoadScene(2);
        _gameIsPaused = false;
        Time.timeScale = 1f;

    }

    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == _rewardedVideo)
        {
            _adsButton.interactable = true;
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        

    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            
        }
        else if (showResult == ShowResult.Skipped)
        {
        }
        else if (showResult == ShowResult.Failed)
        {
        }
    }
}
