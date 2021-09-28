using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _bulletRb;
    private GameObject _target;
    [SerializeField] private BulletProperty _bulletProperty;
   

    public void Awake()
    {
        _target = GameObject.FindGameObjectWithTag("Enemy");


        if (_target == null)
        {
            Destroy(gameObject);
        }
        Destroy(gameObject, _bulletProperty.AliveTime);
    }


    private void FixedUpdate()
    {
        Vector2 moveDirection = (_target.transform.position - transform.position).normalized;
        _bulletRb.AddForce(_bulletProperty.SpeedBullet * moveDirection);
    }

    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == _target)
        {
            Destroy(gameObject);
            EnemyProperty _enemyProperty = collision.gameObject.GetComponent<EnemyProperty>();
            _enemyProperty.TakeDamage(_bulletProperty.DamageBullet);
        }

    }
}
