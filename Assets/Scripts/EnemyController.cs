using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    private GameObject _playerPosition;
    private Rigidbody2D _enemyRb;
    private SpawnManager _spawnManager;
  //  private EnemyProperty _enemyProperty;

  
    private void Start()
    {
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
     //   _enemyProperty = GameObject.Find("EnemyProperty").GetComponent<EnemyProperty>();
        _enemyRb = GetComponent<Rigidbody2D>();
        _playerPosition = GameObject.Find("Player");

    }
    private void OnDestroy()
    {
        int enemiesLeft = 0;
        enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemiesLeft == 0)
        {
            _spawnManager.LaunchWave();
        }
    }

    private void FixedUpdate()
    {
        Vector2 lookDirection = (_playerPosition.transform.position - transform.position).normalized;
        _enemyRb.AddForce(lookDirection * /*_enemyProperty.*/Speed);
        DifficultyEnemy(currentEnemyType);

    } // попробовать без двух апдейтов

    [SerializeField] public DifficultyEnemyType currentEnemyType = DifficultyEnemyType.ordinary; // type difficulty
[SerializeField] private float _speedEnemy;
[SerializeField] private float _healthEnemy;
public float Speed { get { return _speedEnemy; } set { _speedEnemy = value; } }
internal float Health { get { return _healthEnemy; } set { _healthEnemy = value; } }
private GameManager _gameManager;

public void DifficultyEnemy(DifficultyEnemyType _currentEnemyType)
{
    switch (_currentEnemyType)
    {
        case DifficultyEnemyType.ordinary:
            Speed = 2f;
            Health = 1f;
            CheckHealth();
            break;
        case DifficultyEnemyType.fast:
            Speed = 3f;
            Health = 1f;
            CheckHealth();
            break;
        case DifficultyEnemyType.strong:
            Speed = 1.5f;
            Health = 2f;
            CheckHealth();
            break;
        default:
            break;
    }
}
void CheckHealth() // проверка здоровья
{
    if (Health == 0)
    {
        //Destroy(GameObject.);
        _gameManager._ordinaryMoney += 1;
        _gameManager._score += 100;
    }
}

//private void FixedUpdate()
//{
//    DifficultyEnemy(currentEnemyType);


//}

}
