using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    private Rigidbody2D _bulletRb;
    private GameObject _target;
    private BulletProperty _bulletProperty;
    private Vector2 _moveDirection;


    public void Awake()
    {
        _bulletRb = GetComponent<Rigidbody2D>();
        _bulletProperty = GetComponent<BulletProperty>();

        if (Target.S.currentTarget == null)
        {
            Destroy(gameObject);
        }
        else
        {
            _target = Target.S.currentTarget;

        }

        if (_target == null)
        {
            Destroy(gameObject);
        }
        else
        {
            _moveDirection = (_target.transform.position - transform.position).normalized;

        }
        
        Destroy(gameObject, _bulletProperty.AliveTime);
    }

    private void FixedUpdate()
    {
        _bulletRb.AddForce(_bulletProperty.SpeedBullet * _moveDirection);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<EnemyController>() !=null)
        {
            other.GetComponent<EnemyProperty>().TakeDamage(_bulletProperty.DamageBullet);
            this.gameObject.SetActive(false);
        }
    }

    

}
