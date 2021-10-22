using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject _notEnoughMoney;
    private int _towerHealthPlus;
    private int _plusUpgrade = 1;
    private int _towerShieldPlus;
    private float _reloadDelayMinus;
    private float _speedBulletPlus;
    GUIUpdateScript gUIUpdateScript;
    public int[] shopCosts;
    public TextMeshProUGUI[] shopBtnText;
    [SerializeField] private GameObject _reloadBtn;
    [SerializeField] private int maxUpgrade;


    private void Start()
    {
        _notEnoughMoney.SetActive(false);
        gUIUpdateScript = GetComponent<GUIUpdateScript>();
        _towerHealthPlus = PlayerPrefs.GetInt("TowerHealth");
        _towerShieldPlus = PlayerPrefs.GetInt("TowerShield");
        _reloadDelayMinus = PlayerPrefs.GetFloat("ReloadDelay");
        _speedBulletPlus = PlayerPrefs.GetFloat("SpeedBullet");
        maxUpgrade = PlayerPrefs.GetInt("MaxUpgrades");
    }


    public void OnBtn_TowerHealthPlus(int index)
    {
        if (gUIUpdateScript.ordinaryMoney>=shopCosts[index])
        {
            gUIUpdateScript.ordinaryMoney -= shopCosts[index];
            _towerHealthPlus += _plusUpgrade;
            PlayerPrefs.SetInt("TowerHealth", _towerHealthPlus);
            shopBtnText[index].text = "Buy\n" + "$" + shopCosts[index].ToString();
           
        }
        else
        {
            StartCoroutine(NotEM());  
        }
    }
    public void OnBtn_TowerShieldPlus(int index)
    {
        if (gUIUpdateScript.ordinaryMoney >= shopCosts[index])
        {
            gUIUpdateScript.ordinaryMoney -= shopCosts[index];
            _towerShieldPlus += _plusUpgrade;
            GlobalSettings.IsShieldActive = true;
            PlayerPrefs.SetInt("IsShieldActive", GlobalSettings.IsShieldActive ? 1 : 0);
            PlayerPrefs.SetInt("TowerShield", _towerShieldPlus);
            shopBtnText[index].text = "Buy\n" + "$" + shopCosts[index].ToString();
        }
        else
        {
            StartCoroutine(NotEM());
        }
    }
    public void OnBtn_ReloadDelayMinus(int index)
    {

        if (maxUpgrade <= 3)
        { 
            if (gUIUpdateScript.ordinaryMoney >= shopCosts[index])
            {
                maxUpgrade++;
                PlayerPrefs.SetInt("MaxUpgrades", maxUpgrade);
                gUIUpdateScript.ordinaryMoney -= shopCosts[index];
                _reloadDelayMinus -= 0.1f;
                PlayerPrefs.SetFloat("ReloadDelay", _reloadDelayMinus);
                shopBtnText[index].text = "Buy\n" + "$" + shopCosts[index].ToString();
            }
            else
            {
                StartCoroutine(NotEM());
            }
        }
        else
        {
            _reloadBtn.GetComponent<Button>().interactable = false;
        }

    }
    public void OnBtn_SpeedBulletPlus(int index)
    {
        if (gUIUpdateScript.ordinaryMoney >= shopCosts[index])
        {
            gUIUpdateScript.ordinaryMoney -= shopCosts[index];
            _speedBulletPlus += 1.0f;
            PlayerPrefs.SetFloat("SpeedBullet", _speedBulletPlus);
            shopBtnText[index].text = "Buy\n" + "$" + shopCosts[index].ToString();
        }
        else
        {
            StartCoroutine(NotEM());
        }
    }


    IEnumerator NotEM()
    {
        _notEnoughMoney.SetActive(true);
        yield return new WaitForSeconds(1f);
        _notEnoughMoney.SetActive(false);
    }
  

    


}
