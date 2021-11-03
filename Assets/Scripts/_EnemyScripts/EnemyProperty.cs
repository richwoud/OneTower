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
   
    private int _addMoney;

    public int AddMoney
    {
        get { return _addMoney; }
        set { _addMoney = value; }
    }

    private int _addScore;
    public int AddScore
    {
        get { return _addScore; }
        set { _addScore = value; }
    }


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
                AddMoney = 1;
                AddScore = 100;
                break;
            case DifficultyEnemyType.fast:
                Speed = 2.3f;
                _maxHealthEnemy = 1;
                EnemyDamage = 1;
                AddMoney = 2;
                AddScore = 200;
                break;
            case DifficultyEnemyType.strong:
                Speed = 1.5f;
                _maxHealthEnemy = 2;
                EnemyDamage = 2;
                AddMoney = 3;
                AddScore = 300;
                break;
            case DifficultyEnemyType.ordinaryThreeLevel:
                Speed = 2.6f;
                _maxHealthEnemy = 3;
                EnemyDamage = 3;
                AddMoney = 3;
                AddScore = 300;
                break;
            case DifficultyEnemyType.fastThreeLevel:
                Speed = 3f;
                _maxHealthEnemy = 4;
                EnemyDamage = 4;
                AddMoney = 4;
                AddScore = 400;
                break;
            case DifficultyEnemyType.strongThreeLevel:
                Speed = 2.7f;
                _maxHealthEnemy = 5;
                EnemyDamage = 5;
                AddMoney = 5;
                AddScore = 500;
                break;
            case DifficultyEnemyType.killer:
                Speed = 4f;
                _maxHealthEnemy = 3;
                EnemyDamage = 6;
                AddMoney = 6;
                AddScore = 600;
                break;
            case DifficultyEnemyType.boss1:
                Speed = 2.5f;
                _maxHealthEnemy = 6;
                EnemyDamage = 10;
                AddMoney = 30;
                AddScore = 1000;
                break;
            case DifficultyEnemyType.boss2:
                Speed = 3f;
                _maxHealthEnemy = 5;
                EnemyDamage = 15;
                AddMoney = 50;
                AddScore = 1500;
                break;
            case DifficultyEnemyType.boss3:
                Speed = 3.1f;
                _maxHealthEnemy = 8;
                EnemyDamage = 18;
                AddMoney = 80;
                AddScore = 2000;
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
            _gameManager.AddMoneyAndScore(AddMoney, AddScore);
        }

    }
   
    public void TakeDamage(int _bulletDamage)
    {
        _currentHealthEnemy -= _bulletDamage;
        _healthBarImage.fillAmount = (float)_currentHealthEnemy / _maxHealthEnemy;
    }
  
}
