using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class TowerSettings : MonoBehaviour
{
    private EnemyProperty _enemyProperty;
    [SerializeField] private GameObject _healthBar;
    [SerializeField] internal Image _healthBarImage;
    [SerializeField] private GameObject _shieldBar;
    [SerializeField] private Image _shieldBarImage;
    [SerializeField] private GameObject _deathMenu;

    [SerializeField] private int _currentHealthTower;
    public int CurrentTowerHealth { get { return _currentHealthTower; } set { _currentHealthTower = value; } }
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private int _maxTowerShield;
    [SerializeField] private int _currentTowerShield;
    [SerializeField] private AudioSource _damageTower;
 

    private int _maxHealthTower;
    public int MaxHealthTower { get { return _maxHealthTower; } set { _maxHealthTower = value; } }

    private int _count;
    private bool isActiveShield;

    private void Awake()
    {
        isActiveShield = PlayerPrefs.GetInt("IsShieldActive") == 1 ? true : false;
    }
    private void Start()
    {
   
        if (isActiveShield)
        {
            _shieldBar.SetActive(true);
            _maxTowerShield = PlayerPrefs.GetInt("TowerShield");
            _currentTowerShield = _maxTowerShield;
        }

        _maxHealthTower = PlayerPrefs.GetInt("TowerHealth");
        _currentHealthTower = _maxHealthTower;
        _enemyProperty = gameObject.GetComponent<EnemyProperty>();
    }

    void CheckHealth()
    {
        if (_currentHealthTower <= 0)
        {
            Debug.Log("GAMEOVER!");
            _count++;
            var _destroyerParticle = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(_destroyerParticle, 2f);
            StartCoroutine(TwoSeconds());
        }
    }

  

    IEnumerator TwoSeconds()
    {
        yield return new WaitForSeconds(1.1f);
        if (_count == 1)
        {
            _deathMenu.SetActive(true);
        }
        else
        {
            _count =0;
            _deathMenu.GetComponent<DeathMenu>().ExitMenu();
        }
    }

    public void TakeDamageTower(int _enemyDamage)
    {
        if (isActiveShield)
        {
            _damageTower.Play();
            _currentTowerShield -= _enemyDamage;
            _shieldBarImage.fillAmount = (float)_currentTowerShield / _maxTowerShield;
            
        }
        else
        {
            _damageTower.Play();
            _currentHealthTower -= _enemyDamage;
            _healthBarImage.fillAmount = (float)_currentHealthTower / _maxHealthTower;
            CheckHealth();
        }
        if (_currentTowerShield <= 0)
        {
            _shieldBar.SetActive(false);
            isActiveShield = false;
        }
           
        

    }
}


