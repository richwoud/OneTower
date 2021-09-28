using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProperty : MonoBehaviour
{
    [SerializeField] private float _speedEnemy;
    [SerializeField] private float _healthEnemy;
    public float Speed { get { return _speedEnemy; } set { _speedEnemy = value; } }
    internal float Health { get { return _healthEnemy; } set { _healthEnemy = value; } }
    private GameManager _gameManager;
    private EnemyController _enemyController;

    private void Start()
    {
         _enemyController = GameObject.Find("EnemyController").GetComponent<EnemyController>();

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
            Destroy(gameObject);
            _gameManager._ordinaryMoney += 1;
            _gameManager._score += 100;
        }
    }

    private void Update()
    {
        DifficultyEnemy(_enemyController.currentEnemyType);
    }

}
