using TMPro;
using UnityEngine;

public class GUIUpdateScript : MonoBehaviour
{
    public TextMeshProUGUI _ordinaryMoneyText;
    
   [SerializeField] private int _ordinaryMoney;
  
    public int OrdinaryMoney
    {
        get { return _ordinaryMoney; }
        set { _ordinaryMoney = value; }
    }


    // Start is called before the first frame update
    void Start()
    {
        _ordinaryMoney = PlayerPrefs.GetInt("OrdinaryMoney");
        TextUIUpdate();
    }



    // Update is called once per frame
    void Update()
    {
        TextUIUpdate();
    }
    void TextUIUpdate()
    {
        _ordinaryMoneyText.text = "$" + _ordinaryMoney.ToString();
        PlayerPrefs.SetInt("OrdinaryMoney", _ordinaryMoney);
    }
}
