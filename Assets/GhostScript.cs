using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
    private TowerSettings _playerPosition; // позиция игрока
    private Rigidbody2D _enemyRb;
    private SpawnManager _spawnManager;
    private Vector2 _lookDirection;
    private float speed = 2f;

    private void Start()
    {
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _enemyRb = GetComponent<Rigidbody2D>();
        _playerPosition = GameObject.Find("Player").GetComponent<TowerSettings>();
        _lookDirection = (_playerPosition.transform.position - transform.position).normalized;
    }

    private void FixedUpdate()
    {
        _enemyRb.AddForce(_lookDirection * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            _spawnManager.VictoryGame();            
        }
    }

}
