using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProperty : MonoBehaviour
{
    [SerializeField] private float _speedEnemy;
    [SerializeField] private float _healthEnemy;
    public float Speed { get { return _speedEnemy; } set { _speedEnemy = value; } }
    public float Health { get { return _healthEnemy; } set { _healthEnemy = value; } }
    private GameManager _gameManager;
    private EnemyController _enemyController;
    private BulletProperty _bulletProperty;

    private void Start()
    {
        _enemyController = GetComponent<EnemyController>();
    }

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
                Speed = 2.5f;
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
            Destroy(gameObject);
            _gameManager._ordinaryMoney += 1;
            _gameManager._score += 100;

        }
    }

    private void Update()
    {
        DifficultyEnemy(_enemyController.currentEnemyType);
    }
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<BulletMove>() != null)
        {
            
            Health -= _bulletProperty.DamageBullet;
        }
    }
}
