using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject _notEnoughMoney;
    private int _towerHealthPlus;
    private int _plusUpgrade = 1;
    private int _towerShield = 1;
    private int _damageBulletPlus;
    private float _reloadDelayMinus;
    private float _speedBulletPlus;
    GUIUpdateScript gUIUpdateScript;
    public int[] shopCosts;
    public TextMeshProUGUI[] shopBtnText;
    [SerializeField] private GameObject _reloadBtn;
    [SerializeField] private GameObject _speedBtn;
    [SerializeField] private int maxUpgradeReload;
    [SerializeField] private int maxUpgradeSpeed;




    private void Start()
    {
        _notEnoughMoney.SetActive(false);
        gUIUpdateScript = GetComponent<GUIUpdateScript>();
        _towerHealthPlus = PlayerPrefs.GetInt("TowerHealth");
       
        _reloadDelayMinus = PlayerPrefs.GetFloat("ReloadDelay");
        _speedBulletPlus = PlayerPrefs.GetFloat("SpeedBullet");
        _damageBulletPlus = PlayerPrefs.GetInt("DamageBullet");
        maxUpgradeReload = PlayerPrefs.GetInt("MaxUpgrades");
        maxUpgradeSpeed = PlayerPrefs.GetInt("MaxUpgradeSpeed");

        if (PlayerPrefs.HasKey("max") == true)
        {
            _reloadBtn.GetComponent<Button>().interactable = false;

        }
        if (PlayerPrefs.HasKey("maxSpeed") == true)
        {
            _speedBtn.GetComponent<Button>().interactable = false;

        }
    }


    public void OnBtn_TowerHealthPlus(int index)
    {
        if (gUIUpdateScript.OrdinaryMoney >= shopCosts[index])
        {
            gUIUpdateScript.OrdinaryMoney -= shopCosts[index];
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
        if (gUIUpdateScript.OrdinaryMoney >= shopCosts[index])
        {
            gUIUpdateScript.OrdinaryMoney -= shopCosts[index];
            GlobalSettings.IsShieldActive = true;
            PlayerPrefs.SetInt("IsShieldActive", GlobalSettings.IsShieldActive ? 1 : 0);
            PlayerPrefs.SetInt("TowerShield", _towerShield);
            shopBtnText[index].text = "Buy\n" + "$" + shopCosts[index].ToString();
        }
        else
        {
            StartCoroutine(NotEM());
        }
    }
    public void OnBtn_ReloadDelayMinus(int index)
    {
        if (maxUpgradeReload <=3)
        {
            if (gUIUpdateScript.OrdinaryMoney >= shopCosts[index])
            {
                maxUpgradeReload++;
                PlayerPrefs.SetInt("MaxUpgrades", maxUpgradeReload);
                gUIUpdateScript.OrdinaryMoney -= shopCosts[index];
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
            PlayerPrefs.SetInt("max", 1);
        }
        
    

    }
    public void OnBtn_SpeedBulletPlus(int index)
    {
        if (maxUpgradeSpeed <= 18)
        { 
            if (gUIUpdateScript.OrdinaryMoney >= shopCosts[index])
            {
                maxUpgradeSpeed++;
                gUIUpdateScript.OrdinaryMoney -= shopCosts[index];
                _speedBulletPlus += 2.0f;
                PlayerPrefs.SetInt("MaxUpgradeSpeed", maxUpgradeSpeed);
                PlayerPrefs.SetFloat("SpeedBullet", _speedBulletPlus);
                shopBtnText[index].text = "Buy\n" + "$" + shopCosts[index].ToString();
            }
            else
            {
                StartCoroutine(NotEM());
            }
         }
        else
        {
            PlayerPrefs.SetInt("maxSpeed", 1);
        }
    }
    public void OnBtn_DamageBulletPlus(int index)
    {
        if (gUIUpdateScript.OrdinaryMoney >= shopCosts[index])
        {
            gUIUpdateScript.OrdinaryMoney -= shopCosts[index];
            _damageBulletPlus += _plusUpgrade;
            PlayerPrefs.SetInt("DamageBullet", _damageBulletPlus);
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
