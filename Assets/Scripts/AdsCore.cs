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
    private void Start() // ������������� ��������
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

    public static void ShowAdsVideo(string placementId) // ������������� ������� �� ����
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
            // ��������, ���� ������� ��������
        }
    }

    public void OnUnityAdsDidError(string message)
    {
       // ������ �������
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // ������ ��������� �������
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult) // ��������� �������(��� ���������� ��������������)
    {
        if (showResult == ShowResult.Finished)
        {
            // ��������, ���� ����� ��������� ������� �� �����
        }
        else if (showResult == ShowResult.Skipped)
        {

        }
        else if (showResult == ShowResult.Failed)
        {

        }
    }
}
