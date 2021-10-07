using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    
    public DifficultyEnemyType currentEnemyType; // type difficulty
    private TowerSettings _playerPosition; // позиция игрока
    private Rigidbody2D _enemyRb; 
    private SpawnManager _spawnManager;
    private EnemyProperty _enemyProperty;
    private Vector2 _lookDirection;


    private void Start()
    {
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _enemyProperty = GetComponent<EnemyProperty>();
        _enemyRb = GetComponent<Rigidbody2D>();
        _playerPosition = GameObject.Find("Player").GetComponent<TowerSettings>();
        _enemyProperty.DifficultyEnemy(currentEnemyType);
        _lookDirection = (_playerPosition.transform.position - transform.position).normalized;
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

        _enemyRb.AddForce(_lookDirection * _enemyProperty.Speed);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject != null)
        {
             _playerPosition.TakeDamageTower(_enemyProperty.EnemyDamage);
            Destroy(gameObject);
        }
    }





}
