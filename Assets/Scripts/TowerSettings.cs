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
    [SerializeField] private GameObject _explosionPrefab;
    public int HealthTower { get { return _currentHealthTower; } set { _currentHealthTower = value; } }
    [SerializeField] private int _defenseTower;
    public int DefenseTower { get { return _defenseTower; }set { _defenseTower = value; }}
    private int _maxHealthTower;
    private EnemyProperty _enemyProperty;

    private void Start()
    {
        _maxHealthTower = PlayerPrefs.GetInt("TowerHealth");
        _currentHealthTower = _maxHealthTower;
        _enemyProperty = gameObject.GetComponent<EnemyProperty>();
    }

    void CheckHealth()
    {
        if (_currentHealthTower <= 0)
        {
            Debug.Log("GAMEOVER!!!!!!!!");
            var _destroyerParticle = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(_destroyerParticle, 2f);
            StartCoroutine(TwoSeconds());
        }
    }
   IEnumerator TwoSeconds()
    {
        yield return new WaitForSeconds(1.2f);
        _deathMenu.SetActive(true);

    }

    public void TakeDamageTower(int _enemyDamage)
    {
        _currentHealthTower -= _enemyDamage;
        _healthBarImage.fillAmount = (float)_currentHealthTower / _maxHealthTower;
        CheckHealth();
    }







}
