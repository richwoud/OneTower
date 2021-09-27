using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private GameObject _target;
    [SerializeField] private Rigidbody2D _bulletRb;
    [SerializeField] private float _speedBullet = 10.0f;
    private float _aliveTimer = 3.0f;
    private float _damage = 1f;
   // private EnemyController _enemyController;

    private void Awake()
    {
        _target = GameObject.FindGameObjectWithTag("Enemy");
       // _enemyController = GameObject.Find("EnemyController").GetComponent<EnemyController>();

        if (_target == null)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Destroy(gameObject, _aliveTimer);
    }

    // Update is called once per frame
    void Update()
    {
            Vector2 moveDirection = (_target.transform.position - transform.position).normalized;
            _bulletRb.AddForce(_speedBullet * moveDirection);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyController>() !=null)
        {
            //Rigidbody2D _enemyRb = collision.gameObject.GetComponent<Rigidbody2D>();
            //_enemyController.Health -= _damage; 

            //Destroy(collision.gameObject);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
