using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class RevardedFreeMoney : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private _DonateShop _donateShop;

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
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult) // обработка рекламы(тут определяем вознаграждение)
    {
        if (showResult == ShowResult.Finished)
        {
            _donateShop.On_BtnWatchAD();
        }
        else if (showResult == ShowResult.Skipped)
        {
            
        }
        else if (showResult == ShowResult.Failed)
        {

        }
    }
}

