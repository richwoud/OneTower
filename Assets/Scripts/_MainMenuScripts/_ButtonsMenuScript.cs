using UnityEngine;
using UnityEngine.SceneManagement;


public class _ButtonsMenuScript : MonoBehaviour
{
    [SerializeField] private float _pesentShowAds;
    float tempPersent;
    private string _video = "Interstitial_Android";

    public void OnBtn_Play()
    {
        SceneManager.LoadScene(1);
    }
    public void OnBtn_Upgrades()
    {
        tempPersent = Random.Range(0, 1f);
        if (tempPersent < _pesentShowAds)
        {
            AdsCore.ShowAdsVideo(_video);
        }

        SceneManager.LoadScene(3);
    }
    public void OnBtn_Shop()
    {
        tempPersent = Random.Range(0, 1f);
        if (tempPersent < _pesentShowAds)
        {
            AdsCore.ShowAdsVideo(_video);
        }
        SceneManager.LoadScene(5);
    }
    public void OnBtn_Stats()
    {
        tempPersent = Random.Range(0, 1f);
        if (tempPersent < _pesentShowAds)
        {
            AdsCore.ShowAdsVideo(_video);
        }
        SceneManager.LoadScene(4);
    }
    public void OnBtn_Exit()
    {
        PlayerPrefs.Save();
        Application.Quit();
    }
}
