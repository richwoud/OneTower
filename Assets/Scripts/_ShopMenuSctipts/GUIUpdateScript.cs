using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GUIUpdateScript : MonoBehaviour
{
    public TextMeshProUGUI _ordinaryMoneyText, _goldText;
    
    public int ordinaryMoney;
    public int gold;
    


    // Start is called before the first frame update
    void Start()
    {
       
        ordinaryMoney = PlayerPrefs.GetInt("OrdinaryMoney");
        gold = PlayerPrefs.GetInt("Gold");

        TextUIUpdate();
    }



    // Update is called once per frame
    void Update()
    {
        TextUIUpdate();
    }
    void TextUIUpdate()
    {
        _ordinaryMoneyText.text = "$ " + ordinaryMoney.ToString();
        PlayerPrefs.SetInt("OrdinaryMoney", ordinaryMoney);
        _goldText.text = "" + gold.ToString();
        PlayerPrefs.SetInt("Gold", gold);

    }
}
