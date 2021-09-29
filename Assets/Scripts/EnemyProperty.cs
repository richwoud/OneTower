using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProperty : MonoBehaviour
{
    [SerializeField] private float _speedEnemy;
    [SerializeField] private int _healthEnemy;
    public float Speed { get { return _speedEnemy; } set { _speedEnemy = value; } }
    public int Health { get { return _healthEnemy; } set { _healthEnemy = value; } }
    private GameManager _gameManager;
    private EnemyController _enemyController;
    private int _addMoney = 1;
    private int _score = 100;
    

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
                Health = 1;
                
                break;
            case DifficultyEnemyType.fast:
                Speed = 2.5f;
                Health = 1;
                
                break;
            case DifficultyEnemyType.strong:
                Speed = 1.5f;
                Health = 2;
                
                break;
            default:
                break;
        }
    }

    public void TakeDamage(int _bulletDamage)
    {
        Health -= _bulletDamage;

        if (Health <= 0)
        {
            Destroy(gameObject);
            _gameManager.AddMoneyAndScore(_addMoney, _score);
        }
    }

}
