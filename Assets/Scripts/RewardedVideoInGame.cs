using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class RewardedVideoInGame : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private DeathMenu _deathMenu;

    [SerializeField] private bool _testMode = true;
    [SerializeField] private Button _adsButton;

    private string _gameId = "4425063";
    private string _rewardedVideo = "Rewarded_Android";

    private void Start()
    {
        _adsButton = GetComponent<Button>();
        _adsButton.interactable = Advertisement.IsReady(_rewardedVideo);

        if (_adsButton)
            _adsButton.onClick.AddListener(ShowRewardedVideo);

        Advertisement.AddListener(this);
        Advertisement.Initialize(_gameId, _testMode);
    }
    public void ShowRewardedVideo()
    {
        Advertisement.Show(_rewardedVideo);
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
        // ошибка рекламы
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // только запустили рекламу
        Time.timeScale = 0f;
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult) // обработка рекламы(тут определяем вознаграждение)
    {
        if (showResult == ShowResult.Finished)
        {
            _deathMenu.ContinueButton();
            
        }
        else if (showResult == ShowResult.Skipped)
        {
            _deathMenu.ExitMenu();
        }
        else if (showResult == ShowResult.Failed)
        {

        }
    }
}

