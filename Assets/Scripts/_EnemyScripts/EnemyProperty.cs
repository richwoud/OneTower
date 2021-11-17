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
    private GameManager_Classic _gameManager;
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
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager_Classic>();
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
            case DifficultyEnemyType.ordinaryTwoLevel:
                Speed = 2.6f;
                _maxHealthEnemy = 3;
                EnemyDamage = 3;
                AddMoney = 3;
                AddScore = 300;
                break;
            case DifficultyEnemyType.fastTwoLevel:
                Speed = 3f;
                _maxHealthEnemy = 4;
                EnemyDamage = 4;
                AddMoney = 4;
                AddScore = 400;
                break;
            case DifficultyEnemyType.strongTwoLevel:
                Speed = 2.7f;
                _maxHealthEnemy = 5;
                EnemyDamage = 5;
                AddMoney = 5;
                AddScore = 500;
                break;
            case DifficultyEnemyType.ordinaryThreeLevel:
                Speed = 2.8f;
                _maxHealthEnemy = 5;
                EnemyDamage = 5;
                AddMoney = 4;
                AddScore = 400;
                break;
            case DifficultyEnemyType.fastThreeLevel:
                Speed = 3.2f;
                _maxHealthEnemy = 6;
                EnemyDamage = 6;
                AddMoney = 5;
                AddScore = 500;
                break;
            case DifficultyEnemyType.strongThreeLevel:
                Speed = 2.9f;
                _maxHealthEnemy = 7;
                EnemyDamage = 7;
                AddMoney = 6;
                AddScore = 600;
                break;
            case DifficultyEnemyType.ordinaryFourLevel:
                Speed = 2.8f;
                _maxHealthEnemy = 7;
                EnemyDamage = 7;
                AddMoney = 5;
                AddScore = 500;
                break;
            case DifficultyEnemyType.fastFourLevel:
                Speed = 3.3f;
                _maxHealthEnemy = 8;
                EnemyDamage = 8;
                AddMoney = 6;
                AddScore = 600;
                break;
            case DifficultyEnemyType.strongFourLevel:
                Speed = 2.9f;
                _maxHealthEnemy = 9;
                EnemyDamage = 9;
                AddMoney = 7;
                AddScore = 700;
                break;
            case DifficultyEnemyType.ordinaryFiveLevel:
                Speed = 2.9f;
                _maxHealthEnemy = 9;
                EnemyDamage = 9;
                AddMoney = 6;
                AddScore = 600;
                break;
            case DifficultyEnemyType.fastFiveLevel:
                Speed = 3.5f;
                _maxHealthEnemy = 10;
                EnemyDamage = 10;
                AddMoney = 7;
                AddScore = 700;
                break;
            case DifficultyEnemyType.strongFiveLevel:
                Speed = 2.9f;
                _maxHealthEnemy = 11;
                EnemyDamage = 11;
                AddMoney = 8;
                AddScore = 800;
                break;
            case DifficultyEnemyType.ordinarySixLevel:
                Speed = 2.9f;
                _maxHealthEnemy = 11;
                EnemyDamage = 11;
                AddMoney = 7;
                AddScore = 700;
                break;
            case DifficultyEnemyType.fastSixLevel:
                Speed = 3.5f;
                _maxHealthEnemy = 12;
                EnemyDamage = 12;
                AddMoney = 8;
                AddScore = 800;
                break;
            case DifficultyEnemyType.strongSixLevel:
                Speed = 2.9f;
                _maxHealthEnemy = 13;
                EnemyDamage = 13;
                AddMoney = 9;
                AddScore = 900;
                break;
            case DifficultyEnemyType.ordinarySevenLevel:
                Speed = 2.9f;
                _maxHealthEnemy = 13;
                EnemyDamage = 13;
                AddMoney = 8;
                AddScore = 800;
                break;
            case DifficultyEnemyType.fastSevenLevel:
                Speed = 3.5f;
                _maxHealthEnemy = 14;
                EnemyDamage = 14;
                AddMoney = 9;
                AddScore = 900;
                break;
            case DifficultyEnemyType.strongSevenLevel:
                Speed = 2.9f;
                _maxHealthEnemy = 15;
                EnemyDamage = 15;
                AddMoney = 10;
                AddScore = 1000;
                break;
            case DifficultyEnemyType.ordinaryEightLevel:
                Speed = 2.9f;
                _maxHealthEnemy = 15;
                EnemyDamage = 15;
                AddMoney = 9;
                AddScore = 900;
                break;
            case DifficultyEnemyType.fastEightLevel:
                Speed = 3.6f;
                _maxHealthEnemy = 16;
                EnemyDamage = 16;
                AddMoney = 10;
                AddScore = 1000;
                break;
            case DifficultyEnemyType.strongEightLevel:
                Speed = 2.9f;
                _maxHealthEnemy = 17;
                EnemyDamage = 17;
                AddMoney = 11;
                AddScore = 1100;
                break;
            case DifficultyEnemyType.ordinaryNineLevel:
                Speed = 2.9f;
                _maxHealthEnemy = 17;
                EnemyDamage = 17;
                AddMoney = 10;
                AddScore = 1000;
                break;
            case DifficultyEnemyType.fastNineLevel:
                Speed = 3.6f;
                _maxHealthEnemy = 18;
                EnemyDamage = 18;
                AddMoney = 11;
                AddScore = 1100;
                break;
            case DifficultyEnemyType.strongNineLevel:
                Speed = 2.9f;
                _maxHealthEnemy = 19;
                EnemyDamage = 19;
                AddMoney = 12;
                AddScore = 1200;
                break;
            case DifficultyEnemyType.ordinaryTenLevel:
                Speed = 2.9f;
                _maxHealthEnemy = 19;
                EnemyDamage = 11;
                AddMoney = 11;
                AddScore = 1100;
                break;
            case DifficultyEnemyType.fastTenLevel:
                Speed = 4f;
                _maxHealthEnemy = 20;
                EnemyDamage = 12;
                AddMoney = 12;
                AddScore = 1200;
                break;
            case DifficultyEnemyType.strongTenLevel:
                Speed = 3f;
                _maxHealthEnemy = 22;
                EnemyDamage = 22;
                AddMoney = 15;
                AddScore = 1500;
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
                _maxHealthEnemy = 7;
                EnemyDamage = 12;
                AddMoney = 50;
                AddScore = 1500;
                break;
            case DifficultyEnemyType.boss3:
                Speed = 3.2f;
                _maxHealthEnemy = 8;
                EnemyDamage = 14;
                AddMoney = 70;
                AddScore = 2000;
                break;
            case DifficultyEnemyType.boss4:
                Speed = 3.2f;
                _maxHealthEnemy = 9;
                EnemyDamage = 16;
                AddMoney = 90;
                AddScore = 2500;
                break;
            case DifficultyEnemyType.boss5:
                Speed = 3.2f;
                _maxHealthEnemy = 10;
                EnemyDamage = 18;
                AddMoney = 110;
                AddScore = 3000;
                break;
            case DifficultyEnemyType.boss6:
                Speed = 3.2f;
                _maxHealthEnemy = 11;
                EnemyDamage = 20;
                AddMoney = 140;
                AddScore = 3500;
                break;
            case DifficultyEnemyType.boss7:
                Speed = 3.2f;
                _maxHealthEnemy = 12;
                EnemyDamage = 22;
                AddMoney = 160;
                AddScore = 4000;
                break;
            case DifficultyEnemyType.boss8:
                Speed = 3.2f;
                _maxHealthEnemy = 13;
                EnemyDamage = 24;
                AddMoney = 180;
                AddScore = 4500;
                break;
            case DifficultyEnemyType.boss9:
                Speed = 3.2f;
                _maxHealthEnemy = 14;
                EnemyDamage = 26;
                AddMoney = 200;
                AddScore = 5000;
                break;
            case DifficultyEnemyType.boss10:
                Speed = 3.2f;
                _maxHealthEnemy = 20;
                EnemyDamage = 30;
                AddMoney = 500;
                AddScore = 7000;
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
