using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class _DonateShop : MonoBehaviour
{
    GUIUpdateScript gUIUpdateScript;

    public static _DonateShop instance;

    [SerializeField] private bool _testMode = true;
    private string _gameId = "4425063";
    private string _rewardedVideo = "Rewarded_Android";
    [SerializeField] private Button _adsButton;
    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        gUIUpdateScript = GetComponent<GUIUpdateScript>();
        _adsButton.interactable = Advertisement.IsReady(_rewardedVideo);

        Advertisement.Initialize(_gameId, _testMode);
    }
    public void On_BtnFreeMoney()
    {
        if (_adsButton)
        {
            Advertisement.Show(_rewardedVideo);
            gUIUpdateScript.OrdinaryMoney += 50;
        }
        else
        {
            _adsButton.interactable = false;
            Debug.Log("Advertisment not Ready!");
        }
    }

    public void On_BtnLot1()
    {
        gUIUpdateScript.OrdinaryMoney += 400;

    }
    public void On_BtnLot2()
    {
        gUIUpdateScript.OrdinaryMoney += 2400;

    }
    public void On_BtnLot3()
    {
        gUIUpdateScript.OrdinaryMoney += 4200;

    }
    public void On_BtnLot4()
    {
        gUIUpdateScript.OrdinaryMoney += 10000;

    }
    public void On_BtnLot5()
    {
        gUIUpdateScript.OrdinaryMoney += 25000;
    }

}
