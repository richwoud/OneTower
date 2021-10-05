using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    
    public DifficultyEnemyType currentEnemyType; // type difficulty
    private TowerSettings _playerPosition; // ������� ������
    private Rigidbody2D _enemyRb; 
    private SpawnManager _spawnManager;
    private EnemyProperty _enemyProperty;


    private void Start()
    {
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _enemyProperty = GetComponent<EnemyProperty>();
        _enemyRb = GetComponent<Rigidbody2D>();
        _playerPosition = GameObject.Find("Player").GetComponent<TowerSettings>();
        _enemyProperty.DifficultyEnemy(currentEnemyType);
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
        _enemyRb.AddForce(lookDirection * _enemyProperty.Speed);
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
