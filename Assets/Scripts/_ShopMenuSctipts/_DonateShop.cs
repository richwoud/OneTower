using UnityEngine;

public class _DonateShop : MonoBehaviour
{
    GUIUpdateScript gUIUpdateScript;

    public static _DonateShop instance;

    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        gUIUpdateScript = GetComponent<GUIUpdateScript>();

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
