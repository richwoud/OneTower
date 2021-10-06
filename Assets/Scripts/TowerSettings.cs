using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSettings : MonoBehaviour
{
    [SerializeField] private GameObject _healthBar;
    [SerializeField] private Image _healthBarImage;
    [SerializeField] private GameObject _deathMenu;
    [SerializeField] private int _currentHealthTower;
    public int HealthTower { get { return _currentHealthTower; } set { _currentHealthTower = value; } }
    [SerializeField] private int _defenseTower;
    public int DefenseTower { get { return _defenseTower; }set { _defenseTower = value; }}
    private int _maxHealthTower = 3;
    private EnemyProperty _enemyProperty;

    private void Start()
    {
        _currentHealthTower = _maxHealthTower;
        _enemyProperty = gameObject.GetComponent<EnemyProperty>();
    }

    void CheckHealth()
    {
        if (_currentHealthTower <= 0)
        {
            Debug.Log("GAMEOVER!!!!!!!!");
            _deathMenu.SetActive(true);
        }
    }
   

    public void TakeDamageTower(int _enemyDamage)
    {
        _currentHealthTower -= _enemyDamage;
        _healthBarImage.fillAmount = (float)_currentHealthTower / _maxHealthTower;
        CheckHealth();
    }







}
