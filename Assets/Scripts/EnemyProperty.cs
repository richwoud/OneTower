using UnityEngine;
using UnityEngine.UI;

public class EnemyProperty : MonoBehaviour
{
    [SerializeField] private float _speedEnemy;
    [SerializeField] private int _maxHealthEnemy;
    [SerializeField] private int _currentHealthEnemy;
    [SerializeField] private int _enemyDamage;
    [SerializeField] private GameObject _healthBar;
    [SerializeField] private Image _healthBarImage;
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private GameObject _outgoingText;
    public float Speed { get { return _speedEnemy; } set { _speedEnemy = value; } }
    public int EnemyDamage { get { return _enemyDamage; } set { _enemyDamage = value; } }
    private GameManager _gameManager;
    private EnemyController _enemyController;
    private int _addMoney = 1;
    private int _score = 100;

  
    private void Start()
    { 
        _enemyController = GetComponent<EnemyController>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _currentHealthEnemy = _maxHealthEnemy;

    }

    public void DifficultyEnemy(DifficultyEnemyType _currentEnemyType)
    {
        switch (_currentEnemyType)
        {
            case DifficultyEnemyType.ordinary:
                Speed = 2f;
                _maxHealthEnemy = 1;
                EnemyDamage = 1;
                break;
            case DifficultyEnemyType.fast:
                Speed = 2.5f;
                _maxHealthEnemy = 1;
                EnemyDamage = 1;
                break;
            case DifficultyEnemyType.strong:
                Speed = 1.5f;
                _maxHealthEnemy = 2;
                EnemyDamage = 2;
                break;
            default:
                break;
        }
    }

    private void Update()
    {

        if (_currentHealthEnemy <= 0)
        {
            Destroy(gameObject);
            var _destroyerParticle = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(_destroyerParticle, 1f);
            var _destroyerOutgoingText = Instantiate(_outgoingText, transform.position, Quaternion.identity);
            Destroy(_destroyerOutgoingText, 1f);
            _gameManager.AddMoneyAndScore(_addMoney, _score);
        }

    }




    public void TakeDamage(int _bulletDamage)
    {
        _currentHealthEnemy -= _bulletDamage;
        _healthBarImage.fillAmount = (float)_currentHealthEnemy / _maxHealthEnemy;
    }
  
}
