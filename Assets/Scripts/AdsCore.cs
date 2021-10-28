using UnityEngine;
using UnityEngine.Advertisements;

public class AdsCore : MonoBehaviour, IUnityAdsListener
{
    public static AdsCore S;

    [SerializeField] private GameObject _buttonNoAds;
    [SerializeField] private bool _testMode = true;

    private string _gameId = "4425063";

    private string _video = "Interstitial_Android";
    private string _rewardedVideo = "Rewarded_Android";

    private void Awake()
    {
        S = this;
    }
    private void Start() // инициализация сервисов
    {
        if (PlayerPrefs.HasKey("ads") == false)
        {
            Advertisement.AddListener(this);
            Advertisement.Initialize(_gameId, _testMode);
        }
        else
        {
            _buttonNoAds.SetActive(false);
        }


    }

    public static void ShowAdsVideo(string placementId) // инициализация рекламы по типу
    {
        if (PlayerPrefs.HasKey("ads") == false)
        { 
            if (Advertisement.IsReady())
            {
            Advertisement.Show(placementId);
            }
            else
            {
            Debug.Log("Advertisment not Ready!");
            }
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == _rewardedVideo)
        {
            // действие, если реклама доступна
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
            // действия, если игрок посмотрел рекламу до конца
        }
        else if (showResult == ShowResult.Skipped)
        {

        }
        else if (showResult == ShowResult.Failed)
        {

        }
    }
}
