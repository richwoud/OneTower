using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject _notEnoughMoney;
    private int _towerHealthPlus;
    private int _plusUpgrade = 1;
    private int _towerShieldPlus;
    private float _reloadDelayMinus;
    GUIUpdateScript gUIUpdateScript;
    public int[] shopCosts;
    public TextMeshProUGUI[] shopBtnText;


    private void Start()
    {
        _notEnoughMoney.SetActive(false);
        gUIUpdateScript = GetComponent<GUIUpdateScript>();
        _towerHealthPlus = PlayerPrefs.GetInt("TowerHealth");
        _towerShieldPlus = PlayerPrefs.GetInt("TowerShield");
        _reloadDelayMinus = PlayerPrefs.GetFloat("ReloadDelay");
    }


    public void OnBtn_TowerHealthPlus(int index)
    {
        if (gUIUpdateScript.ordinaryMoney>=shopCosts[index])
        {
            gUIUpdateScript.ordinaryMoney -= shopCosts[index];
            _towerHealthPlus += _plusUpgrade;
            shopCosts[index] *= 2;
            PlayerPrefs.SetInt("TowerHealth", _towerHealthPlus);
            shopBtnText[index].text = "Buy\n" + "$" + shopCosts[index];
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
