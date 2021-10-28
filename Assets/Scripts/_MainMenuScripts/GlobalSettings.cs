
using UnityEngine;

public class GlobalSettings : MonoBehaviour
{
    private static int _towerHealth;
    private static int _towerShield;
    private static float _reloadDelay;
    private static float _speedBullet;
    private static int _ordinaryMoney;
    private static int _damageBullet;
   
    private static bool isShieldActive;

    public float ReloadDelay{get { return _reloadDelay; }set { _reloadDelay = value; }   }
    public int OrdinaryMoney { get { return _ordinaryMoney; } set { _ordinaryMoney = value; } }
    public int TowerHealth { get { return _towerHealth; } set { _towerHealth = value; } }
    public int TowerShield { get { return _towerShield; } set { _towerShield = value; } }
    public static bool IsShieldActive { get { return isShieldActive; } set { isShieldActive = value; } }
    public float SpeedBullet { get { return _speedBullet; } set { _speedBullet = value; } }
    public int DamageBullet { get { return _damageBullet; } set { _damageBullet = value; } }




}
